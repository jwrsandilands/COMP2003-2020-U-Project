using UnityEngine;

public class Fish : MonoBehaviour
{
    public Flock flock;
    public int level = 0;

    void Awake()
    {
        this.level = flock.fishLevel;
    }

    void Start()
    {
        switch (level)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
