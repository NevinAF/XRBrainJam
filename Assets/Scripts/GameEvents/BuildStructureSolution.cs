using System.Collections;
using UnityEngine;

public abstract class BuildStructureSolution : GameEventSolution
{
    public GameObject structurePrefab;

    public override IEnumerator OnCompleted()
    {
        var instance = Instantiate(structurePrefab);
        
        return base.OnCompleted();
    }
}