using UnityEngine;

public class GameEventController : MonoBehaviour
{
    public GameEvent gameEvent;


    
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

