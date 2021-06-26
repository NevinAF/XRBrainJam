using UnityEngine;

[RequireComponent(typeof(GameEventManager))]
public class GameTimeline : MonoBehaviour
{
    private GameEventManager em;

    private void Awake()
    {
        em = GetComponent<GameEventManager>();
    }

    private void Update()
    {
       
    }
}