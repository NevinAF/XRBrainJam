using UnityEngine;

public class GameEventController : MonoBehaviour
{
    public GameEvent gameEvent;


    private float spawnTime;
    
    /// <summary>
    /// called when the game event is spawned on the map
    /// </summary>
    void InitializeGameEvent()
    {
        spawnTime = Time.time;
    }

    
    /// <summary>
    /// called when the event scene is loaded 
    /// </summary>
    void OnPlayerEnteredGameEventScene()
    {
        
    }
    
    
    void OnPlayerExitedGameEventScene()
    {
        
    }
    
    void OnGameEventCompleted(bool failed)
    {
        
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
        if (instance.TryGetComponent<GameEventController>(out GameEventController controller)==false)
        {
            controller = instance.AddComponent<GameEventController>();    
        }
        controller.gameEvent = gameEvent;
        return controller;
    }
}

