using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public static LevelManagerScript Instance {get; private set;}
    public int currentLevel = 1; 

    void Awake()
    {
            Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        if (HexManagerScript.Instance.allHexes.Count == 0){
            setLevel(currentLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLevel(int level)
    {
        switch (level)
        {
            case 1:
                MapMakerScript.Instance.makeMap(level, 3);
                currentLevel = level;
                break;
            case 2:
                MapMakerScript.Instance.makeMap(level, 2);
                currentLevel = level;
                break;
            case 3:

                break;
            default:
                Debug.LogWarning("Level not implemented.");
                break;
        }
    }
}
