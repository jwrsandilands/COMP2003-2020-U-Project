using UnityEngine;

public class Fish : MonoBehaviour
{
    public FlockAgent flockagent;
    public int level = 0;

    void Start()
    {
        this.level = flockagent.fishLevel;
    }
}
