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

        allColorArraysLevel1 = new (int, int)[][]{
            whiteTilesLevel1, greenTilesLevel1, 
        };
        allColorArraysLevel2 = new (int, int)[][]{
            whiteTilesLevel2, blueTilesLevel2, greenTilesLevel2,
        };
        allColorArraysLevel3 = new (int, int)[][]{
            whiteTilesLevel3, blueTilesLevel3, greenTilesLevel3, purpleTilesLevel3
        };
        allColorArraysLevel4 = new (int, int)[][]{
            whiteTilesLevel4, blueTilesLevel4, greenTilesLevel4, purpleTilesLevel4
        };
        allColorArraysLevel5 = new (int, int)[][]{
            whiteTilesLevel5, blueTilesLevel5, greenTilesLevel5, purpleTilesLevel5
        };
        allColorArraysLevel6 = new (int, int)[][]{
            whiteTilesLevel6, blueTilesLevel6, greenTilesLevel6, purpleTilesLevel6
        };


        allColorArraysLevel21 = new (int, int)[][]{
            whiteTilesLevel21, blueTilesOnLevel21, greenTilesLevel21, yellowTilesOnLevel21, yellowTilesOffLevel21, purpleTilesLevel21, pinkTilesOnLevel21, pinkTilesOffLevel21, redTilesLevel21,
        };
    }
    //Level1
    public (int, int)[][] allColorArraysLevel1;
    public Color[] colorsUsedLevel1 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.green
    };
    public (int, int)[] whiteTilesLevel1 = new (int, int)[]{
        (2, 3), (4, 3), (1, 4), (3, 4), 
        (2, 5), (4, 5), (1, 6), (3, 6), (5, 6),  
        (2, 7), (4, 7), (3, 8), (2, 9), 
        (4, 9)
    };
    public (int, int)[] greenTilesLevel1 = new (int, int)[] {
        (3,2), (5,4), (3,10), (1,8), (5,8)
    };

    //Level2
    public (int, int)[][] allColorArraysLevel2;
    public Color[] colorsUsedLevel2 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green
    };
    public (int, int)[] whiteTilesLevel2 = new (int, int)[]{
        (2, 3), (1, 4), (4, 5), (3, 6), (5, 6),  
        (4, 7), (2,9), (3,10), (5,8)
    };
    public (int, int)[] blueTilesLevel2 = new (int, int)[] {
        (1,6), (2,5), (3,4), (4,3), (2,7), (3, 8), (4, 9)
    };
    public (int, int)[] greenTilesLevel2 = new (int, int)[] {
        (3,2), (5,4), (1,8)
    };

    //Level3
    public (int, int)[][] allColorArraysLevel3;
    public Color[] colorsUsedLevel3 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesLevel3 = new (int, int)[]{
        (1, 4), (2, 5), 
        (4, 7), (1,8), (3,10), (5,8)
    };
    public (int, int)[] blueTilesLevel3 = new (int, int)[] {
        (1,6), (2,7), (3, 8), (4, 9), (3, 6)
    };
    public (int, int)[] greenTilesLevel3 = new (int, int)[] {
        (3,2), (5,4), (2,9)
    };
    public (int, int)[] purpleTilesLevel3 = new (int, int)[] {
        (2,3), (5, 6)
    };

    //Level4
    public (int, int)[][] allColorArraysLevel4;
    public Color[] colorsUsedLevel4 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesLevel4 = new (int, int)[]{
        (1,4), (0,7), (4,3),
    };
    public (int, int)[] blueTilesLevel4 = new (int, int)[] {
        (2,5), (3,6), (4,7), (5,8), (0,5), (2,9)
    };
    public (int, int)[] greenTilesLevel4 = new (int, int)[] {
        (3,2), (3,10)
    };
    public (int, int)[] purpleTilesLevel4 = new (int, int)[] {
        (1,8), (5,4)
    };

    //Level5
    public (int, int)[][] allColorArraysLevel5;
    public Color[] colorsUsedLevel5 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesLevel5 = new (int, int)[]{
        (3,2), (6,5), (1,10)
    };
    public (int, int)[] blueTilesLevel5 = new (int, int)[] {
        
    };
    public (int, int)[] greenTilesLevel5 = new (int, int)[] {
        (2,1), (5,8), (4,11), (0,7), (5,4)
    };
    public (int, int)[] purpleTilesLevel5 = new (int, int)[] {
        (0,3), (0,9), (6,3), (3,12), (6,9), (3,0)
    };

    //Level6
    public (int, int)[][] allColorArraysLevel6;
    public Color[] colorsUsedLevel6 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesLevel6 = new (int, int)[]{
        (0, 3), (0,5), (4,9)
    };
    public (int, int)[] blueTilesLevel6 = new (int, int)[] {
        (0,7), (1,4), (1,6), (2,7), (2,9), (3,4), (3,6), (3,10), (4,7), (2,3), (5,6)
    };
    public (int, int)[] greenTilesLevel6 = new (int, int)[] {
        (0,9), (3,2), (3,12)
    };
    public (int, int)[] purpleTilesLevel6 = new (int, int)[] {
        (1,2), (1,10), (4,3), (4,11), (6,7)
    };


    //Level21 Playground
    public (int, int)[][] allColorArraysLevel21;
    public Color[] colorsUsedLevel21 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.purple, MapMakerScript.pink, MapMakerScript.pink, MapMakerScript.red
    };
    public (int, int)[] whiteTilesLevel21 = new (int, int)[]{
        (0,3), (1,2), (1,6), (4,11), (6,5), (6,3)
    };
    public (int, int)[] blueTilesOnLevel21 = new (int, int)[] {
        (2,3), (2,1), (3,0), (1,4), (0,7),
        (1,8), (2,9), (1,10), (6,5), (5,6),
        (4,7), (4,9),
    };
    public (int, int)[] greenTilesLevel21 = new (int, int)[] {
        (4,3), (0,9), (6,9)
    };
    public (int, int)[] yellowTilesOnLevel21 = new (int, int)[] {
        (3,6), (4,1)
    };
    public (int, int)[] yellowTilesOffLevel21 = new (int, int)[] {
        (6,7), (5,8), (5,10), (3,12), (3,4)
    };
    public (int, int)[] purpleTilesLevel21 = new (int, int)[] {
        (3,2), (2,7), (0,5), (5,4)
    };
    public (int, int)[] pinkTilesOnLevel21 = new (int, int)[] {
        (2,5), 
    };
    public (int, int)[] pinkTilesOffLevel21 = new (int, int)[] {
        (4,5), (2,11), (3,10)
    };
    public (int, int)[] redTilesLevel21 = new (int, int)[] {
        (3,8), (5,2)
    };

    /*
    public (int, int)[] whiteTilesLevel1 = new (int, int)[]{     --complexity 2
        (1, 2), (5, 2), (2, 3), (4, 3), (1, 4), (3, 4), 
        (5, 4),  (2, 5), (4, 5), (1, 6), (3, 6), (5, 6),  
        (2, 7), (4, 7), (1, 8), (3, 8), (5, 8), (2, 9), 
        (4, 9), (1, 10),  (5, 10), 
    };

     public (int, int)[] whiteTilesLevel1 = new (int, int)[]{ --complexity 3
        (3, 0), (2, 1), (4, 1), (1, 2), (3, 2), (5, 2),
        (0, 3), (2, 3), (4, 3), (6, 3), (1, 4), (3, 4), 
        (5, 4), (0, 5), (2, 5), (4, 5), (6, 5), (1, 6), 
        (3, 6), (5, 6), (0, 7), (2, 7), (4, 7), (6, 7),
        (1, 8), (3, 8), (5, 8), (0, 9), (2, 9), (4, 9), 
        (6, 9), (1, 10), (3, 10), (5, 10), (2, 11), (4, 11), (3, 12)
    };


    */
    
}
