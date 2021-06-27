using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    public TimelineEvent[] Events;
    public GameObject globe;
    public int seed;

    public UnityEvent OnEventSpawn;
    public UnityEvent OnTransition;
    public UnityEvent OnEventComplete;
    public UnityEvent OnGameComplete;

    private float startTime;
    private int index;
    private List<GameEventController> currentEvents;
    private List<GameEventController> queueRemove;



    private void Start()
    {
        Debug.Assert(instance == null, "There should only be one GameManager script active on all scenes.", this);
        instance = this;

        UnityEngine.Random.InitState(seed);

        Array.Sort(Events, (TimelineEvent one, TimelineEvent two) => (one.GetRandomTime() < two.GetRandomTime() ? -1 : 1));

        startTime = Time.time;
        index = 0;
        currentEvents = new List<GameEventController>();
        queueRemove = new List<GameEventController>();
    }

    private void Update()
    {
        if (index >= Events.Length)
        {
            // Check for game ending::
            if (currentEvents.Count <= 0)
            {
                // Game Won!!
                ResolveGameEnding();
                this.enabled = false;
            }

        }
        else
            while (index < Events.Length && Events[index].GetRandomTime() <= Time.time - startTime)
            {
                bool doubleSpawn = false;
                foreach (var gameController in currentEvents)
                {
                    if (gameController.gameEvent == Events[index].Event)
                    {
                        OnEventSpawn.Invoke();
                        gameController.OnDoubleSpawn();
                        doubleSpawn = true;
                        break;
                    }
                }

                if (!doubleSpawn)
                {
                    OnEventSpawn.Invoke();
                    currentEvents.Add(GameEventController.SpawnGameEventOnMap(Events[index].Event, globe));
                    if (SceneTransition.instance.loadedScene.name == Events[index].Event.sceneName)
                    {
                        currentEvents[currentEvents.Count - 1].OnPlayerEnteredGameEventScene();
                        currentEvents[currentEvents.Count - 1].isActive = true;
                    }
                }
                index++;

            }

        foreach (var item in currentEvents)
        {
            changedScene = false;
            if (!changedScene)
                if (item.isActive)
                    item.UpdateController();
                else
                    item.IdleUpdateController();
        }
        foreach (var item in queueRemove)
        {
            currentEvents.Remove(item);
        }
    }

    bool changedScene;

    internal void ChangeScene(string sceneName)
    {
        changedScene = true;
        globe.GetComponentInParent<GlobeReset>().WorldFadeOut();

        foreach (var item in currentEvents)
        {
            bool newActive = sceneName == item.gameEvent.sceneName;

            if (item.isActive && !newActive)
                SceneTransition.instance.OnMidPoint.AddListener(() => {

                    Debug.Log("Calling exit on: " + item.gameEvent.sceneName);
                    item.isActive = newActive;
                    item.OnPlayerExitedGameEventScene();


                });
            else if (!item.isActive && newActive)
                SceneTransition.instance.OnMidPoint.AddListener(() => {

                    Debug.Log("Calling enter on: " + item.gameEvent.sceneName);
                    item.OnPlayerEnteredGameEventScene();
                    item.isActive = newActive;

                });


        }

        SceneTransition.instance.OnMidPoint.AddListener(() => {

            StartCoroutine(RemoveMids()); SceneTransition.instance.OnMidPoint.RemoveAllListeners();

        });

        SceneTransition.instance.ChangeScene(sceneName);
        OnTransition.Invoke();
    }

    private IEnumerator RemoveMids()
    {
        yield return new WaitForSeconds(1f);
        SceneTransition.instance.OnMidPoint.RemoveAllListeners();
    }

    private void ResolveGameEnding()
    {
        Debug.Log("Game is Over! You won!");

        OnGameComplete.Invoke();
    }

    public void Restart()
    {
        startTime = Time.time;
        index = 0;
        this.enabled = true;
    }

    public void GameEventControllerCompleted(GameEventController gameEventController)
    {
        Debug.Assert(currentEvents.Contains(gameEventController), "Could not fine gameEventController apart of the GameManager. Trying to ");
        queueRemove.Add(gameEventController);

        OnEventComplete.Invoke();
    }



    [Serializable]
    public class TimelineEvent
    {
        public GameEvent Event;

        public float averageTime;
        public float range;

        private float randomTime = -1;
        public float GetRandomTime()
        {
            if (randomTime < 0)
                randomTime = (0.5f - UnityEngine.Random.value) * range + averageTime;
            return randomTime;
        }
    }

}
