using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VacuumGameController : GameEventController
{
    public GameObject[] garbagePrefabs;
    public int startNumberObjects = 20;
    public int failureNumber = 100;
    public int solveNumber = 3;
    public AnimationCurve capacityImapctCurve;
    public float spawnInterval;
    public float spawnIntervalRange;

    public float spawnInnerRadius;
    public float spawnOuterRadius;

    private float nextSpawnTime;
    private Transform garbageCollection;
    private System.Random random;

    private int objectCountNumber;

    public override void OnDoubleSpawn()
    {
        Debug.Log("Extra event is ignored by this controller", this);
    }

    public override void OnPlayerEnteredGameEventScene()
    {
        garbageCollection = new GameObject("GarbageCollection").transform;
        SceneManager.MoveGameObjectToScene(garbageCollection.gameObject, SceneTransition.instance.loadedScene);

        for (int i = 0; i < objectCountNumber; i++)
            SpawnGarbageObject();

        UpdateController();
    }

    public override void OnPlayerExitedGameEventScene()
    {
        objectCountNumber = garbageCollection.childCount;
        Destroy(garbageCollection.gameObject);
    }

    protected override void OnInitializeGameEvent()
    {
        random = new System.Random();
        nextSpawnTime = SpawnTime;
        objectCountNumber = startNumberObjects;
    }

    public override void UpdateController()
    {
        if (garbageCollection.childCount <= solveNumber)
        {
            OnGameEventCompleted();

        }
        else
        {
            while (nextSpawnTime < Time.time)
            {
                SpawnGarbageObject();

                nextSpawnTime += spawnInterval + (float)((0.5 - random.NextDouble()) * spawnIntervalRange);
            }

            UpdateGlobleState();
        }
    }

    public override void IdleUpdateController()
    {
        while (nextSpawnTime < Time.time)
        {
            objectCountNumber++;

            nextSpawnTime += spawnInterval + (float)((0.5 - random.NextDouble()) * spawnIntervalRange);
        }

        UpdateGlobleState();
    }

    public void UpdateGlobleState()
    {
        int objCount = (isActive) ? garbageCollection.childCount : objectCountNumber;



        Debug.Log("This is the Impact Value: " + capacityImapctCurve.Evaluate(objCount / (float)failureNumber));
    }

    private void SpawnGarbageObject()
    {

        GameObject garbage = Instantiate(garbagePrefabs[random.Next(0, garbagePrefabs.Length)], garbageCollection);
        garbage.transform.position = 
            Vector3.up + 
            (Quaternion.AngleAxis(random.Next(0,360), Vector3.up) * Vector3.forward) * (float)(random.NextDouble() * (spawnOuterRadius - spawnInnerRadius) + spawnInnerRadius);
        garbage.transform.rotation = Random.rotation;
        garbage.layer = LayerMask.NameToLayer("Scene Objects");

        Debug.Assert(garbage.GetComponent<Rigidbody>(), "Garbage Objects MUST have a rigidbody such that they can be interacted with.");
    }
}
