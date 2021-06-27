using UnityEngine;

public abstract class GameEventController : MonoBehaviour
{
    [HideInInspector]
    public GameEvent gameEvent;
    public bool isActive = false;


    public float SpawnTime { get; private set; }

    /// <summary>
    /// called when the game event is spawned on the map
    /// </summary>
    protected abstract void OnInitializeGameEvent();
    public abstract void UpdateController();
    public abstract void IdleUpdateController();
    public abstract void OnPlayerEnteredGameEventScene();
    public abstract void OnPlayerExitedGameEventScene();

    public abstract void OnDoubleSpawn();

    protected void OnGameEventCompleted()
    {
        GameEventManager.instance.GameEventControllerCompleted(this);
    }
    
    
    public static GameEventController SpawnGameEventOnMap(GameEvent gameEvent, GameObject globe)
    {
        var instance = Instantiate(gameEvent.mapPrefab);
        instance.transform.parent = globe.transform;
        if (instance.TryGetComponent<PolarPosition>(out PolarPosition polarPos) == false)
        {
            polarPos = instance.AddComponent<PolarPosition>();
        }
        polarPos.position = gameEvent.globeLocation;

        bool assert = instance.TryGetComponent<GameEventController>(out GameEventController controller);
        Debug.Assert(assert);
        controller.gameEvent = gameEvent;
        controller.SpawnTime = Time.time;
        controller.OnInitializeGameEvent();

        return controller;
    }

    public void ChangeSceneToThisEvent()
    {
        GameEventManager.instance.ChangeScene(gameEvent.sceneName);
    }
}

