using UnityEngine;

[CreateAssetMenu(menuName = "New Scene")]
public class WorldScene : ScriptableObject
{
    public string sceneName;
    public PolarCoordinate coordinate;
}