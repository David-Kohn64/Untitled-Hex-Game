using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        allColorsLevel1 = new (int, int)[][]{
             whiteTilesLevel1, blueTilesLevel1, greenTilesLevel1, yellowTilesOnLevel1, yellowTilesOffLevel1, orangeTilesLevel1, blackTilesLevel1
        };
    }

    // Data for Level 1
    public (int, int)[][] allColorsLevel1;
    
    public Color[] colorsUsedLevel1 = new Color[]{
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange, MapMakerScript.black
    };
    public (int, int)[] whiteTilesLevel1 = new (int, int)[]{
        (0,3), (0,5), (1,2), (1,6), (2,5), 
        (2,9), (2,11), (3,2), (3,4), (3,6), (3,8), 
        (3,10), (4,5), (5,2), (5,4), (4, 11)
    };
    public (int, int)[] blueTilesLevel1 = new (int, int)[] {
        (2, 3), (2, 1), (3, 0), (1, 4), (0, 7),
        (1, 8), (2, 7), (1, 10), (6, 5), (5, 6),
        (4, 7), (4, 9),
    };
    public (int, int)[] greenTilesLevel1 = new (int, int)[] {
        (4,3), (0,9)
    };
    public (int, int)[] yellowTilesOnLevel1 = new (int, int)[] {
        (4,1)
    };
    public (int, int)[] yellowTilesOffLevel1 = new (int, int)[] {
        (6,7), (5,8), (5,10)
    };
    public (int, int)[] orangeTilesLevel1 = new (int, int)[] {
        (6,3), (3,12)
    };
    public (int, int)[] blackTilesLevel1 = new (int, int)[]{
        (6,9)
    };

    
}
