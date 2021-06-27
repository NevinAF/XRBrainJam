using System.Collections;
using UnityEngine;

public abstract class GameEventSolution : MonoBehaviour
{
    public string solutionName;
    public abstract float SolutionPercentage { get; }
    
    public abstract bool IsSolved();
    
    public virtual IEnumerator OnCompleted()
    {
        yield break;
    }
}