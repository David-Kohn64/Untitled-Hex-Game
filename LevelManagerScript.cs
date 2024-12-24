using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public static LevelManagerScript Instance {get; private set;}
    public int currentLevel = 1; //Maybe make 0 if responsible for main menu?

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setupLevel(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:


            break;
            case 2:

            break;
            case 3:

            break;
            default:
                Debug.LogWarning("Level not implemented.");
                break;
        }
    }
}
