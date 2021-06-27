using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    public TimelineEvent[] Events;
    public GameObject globe;
    public int seed;

    private float startTime;
    private int index;
    private List<GameEventController> currentEvents;



    private void Start()
    {
        Debug.Assert(instance == null, "There should only be one GameManager script active on all scenes.", this);
        instance = this;

        UnityEngine.Random.InitState(seed);

        Array.Sort(Events, (TimelineEvent one, TimelineEvent two) => (one.GetRandomTime() < two.GetRandomTime() ? -1 : 1));

        startTime = Time.time;
        index = 0;
        currentEvents = new List<GameEventController>();
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
                        gameController.OnDoubleSpawn();
                        doubleSpawn = true;
                        break;
                    }
                }
                    
                if (!doubleSpawn)
                    currentEvents.Add(GameEventController.SpawnGameEventOnMap(Events[index].Event, globe));
                index++;

            }

        foreach (var item in currentEvents)
        {
            if (item.isActive)
                item.UpdateController();
            else
                item.IdleUpdateController();
        }
    }

    internal void ChangeScene(string sceneName)
    {
        foreach (var item in currentEvents)
        {
            bool newActive = sceneName == item.gameEvent.sceneName;

            if (item.isActive && !newActive)
                SceneTransition.instance.OnMidPoint.AddListener(() => {

                    item.isActive = newActive;
                    item.OnPlayerExitedGameEventScene();

                });
            else if (!item.isActive && newActive)
                SceneTransition.instance.OnMidPoint.AddListener(() => {

                    item.OnPlayerEnteredGameEventScene();
                    item.isActive = newActive;

                });

            
        }

        SceneTransition.instance.OnMidPoint.AddListener(() => {

            SceneTransition.instance.OnMidPoint.RemoveAllListeners();

        });

        SceneTransition.instance.ChangeScene(sceneName);
    }

    private void ResolveGameEnding()
    {
        Debug.Log("Game is Over! You won!");

        throw new NotImplementedException();
    }

    public void GameEventControllerCompleted(GameEventController gameEventController)
    {
        Debug.Assert(currentEvents.Remove(gameEventController), "Could not fine gameEventController apart of the GameManager. Trying to ");
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