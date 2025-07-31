using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public static LevelManagerScript Instance {get; private set;}
    public int currentLevel;
    public (int x, int y) spawnPoint;

    void Awake()
    {
            Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        if (HexManagerScript.Instance.allHexes.Count == 0){
            SetLevel(currentLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel(int level)
    {
        switch (level)
        {
            case 1:
                currentLevel = level;
                spawnPoint = (1, 4);
                MapMakerScript.Instance.MakeMap(2);
                break;
            case 2:
                currentLevel = level;
                spawnPoint = (1, 4);
                MapMakerScript.Instance.MakeMap(2);
                break;
            case 3:
                currentLevel = level;
                spawnPoint = (1, 4);
                MapMakerScript.Instance.MakeMap(2);
                break;
            case 4:
                currentLevel = level;
                spawnPoint = (1,4);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 5:
                currentLevel = level;
                spawnPoint = (0, 3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 6: 
                currentLevel = level;
                spawnPoint = (0, 3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 7:
                currentLevel = level;
                spawnPoint = (1, 4);
                MapMakerScript.Instance.MakeMap(2);
                break;
            case 8:
                currentLevel = level;
                spawnPoint = (0, 3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 9:
                currentLevel = level;
                spawnPoint = (0, 3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 10:
                currentLevel = level;
                spawnPoint = (0, 3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 11:
                currentLevel = level;
                spawnPoint = (1,4);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 12:
                currentLevel = level;
                spawnPoint = (1,4);
                MapMakerScript.Instance.MakeMap(2);
                break;
            case 13:
                currentLevel = level;
                spawnPoint = (0,3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 14:
                currentLevel = level;
                spawnPoint = (0,3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 15:
                currentLevel = level;
                spawnPoint = (1,4);
                MapMakerScript.Instance.MakeMap(2);
                break;
            case 16:
            currentLevel = level;
                spawnPoint = (1,4);
                MapMakerScript.Instance.MakeMap(2);
                break;
            case 17:
                currentLevel = level;
                spawnPoint = (0,3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 18:
                currentLevel = level;
                spawnPoint = (0,3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            /*
            case 19:
                currentLevel = level;
                spawnPoint = (0,3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            case 20:
                currentLevel = level;
                spawnPoint = (0,3);
                MapMakerScript.Instance.MakeMap(3);
                break;
            */
            case 21:
                currentLevel = level;
                spawnPoint = (0,5);
                MapMakerScript.Instance.MakeMap(3);
                break;
            default:
                Debug.LogWarning("Level not implemented.");
                break;
        }
    }
}
