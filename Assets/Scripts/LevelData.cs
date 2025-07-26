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

        allColorArraysBuddingPath = new (int, int)[][]{
            whiteTilesBuddingPath, greenTilesBuddingPath, 
        };
        allColorArraysCeruleanStep = new (int, int)[][]{
            whiteTilesCeruleanStep, blueTilesCeruleanStep, greenTilesCeruleanStep,
        };
        allColorArraysVioletLaunch = new (int, int)[][]{
            whiteTilesVioletLaunch, blueTilesVioletLaunch, greenTilesVioletLaunch, purpleTilesVioletLaunch
        };
        allColorArraysInterception = new (int, int)[][]{
            whiteTilesInterception, blueTilesInterception, greenTilesInterception, purpleTilesInterception
        };
        allColorArraysIslandHopping = new (int, int)[][]{
            whiteTilesIslandHopping, blueTilesIslandHopping, greenTilesIslandHopping, purpleTilesIslandHopping
        };
        allColorArraysChainingCommand = new (int, int)[][]{
            whiteTilesChainingCommand, blueTilesChainingCommand, greenTilesChainingCommand, purpleTilesChainingCommand
        };
        allColorArraysChainingCollapse = new (int, int)[][]{
            whiteTilesChainingCollapse, blueTilesChainingCollapse, greenTilesChainingCollapse, purpleTilesChainingCollapse
        };
        allColorArraysGoldenToggle = new (int, int)[][]{
            whiteTilesGoldenToggle, blueTilesGoldenToggle, greenTilesGoldenToggle, purpleTilesGoldenToggle, yellowTilesOnGoldenToggle, yellowTilesOffGoldenToggle
        };
        allColorArraysCrissCross = new (int, int)[][]{
            whiteTilesCrissCross, blueTilesCrissCross, greenTilesCrissCross, purpleTilesCrissCross, yellowTilesOnCrissCross, yellowTilesOffCrissCross
        };
        allColorArraysCaptainsWheel = new (int, int)[][]{
            whiteTilesCaptainsWheel, blueTilesCaptainsWheel, greenTilesCaptainsWheel, purpleTilesCaptainsWheel, yellowTilesOnCaptainsWheel, yellowTilesOffCaptainsWheel
        };
        allColorArraysBurnout = new (int, int)[][]{
            whiteTilesBurnout, blueTilesBurnout, greenTilesBurnout, purpleTilesBurnout, yellowTilesOnBurnout, yellowTilesOffBurnout
        };
        allColorArraysLevel12 = new (int, int)[][]{
            whiteTilesLevel12, blueTilesLevel12, greenTilesLevel12, purpleTilesLevel12, yellowTilesOnLevel12, yellowTilesOffLevel12, orangeTilesLevel12
        };
        



        allColorArraysLevel21 = new (int, int)[][]{
            whiteTilesLevel21, blueTilesOnLevel21, greenTilesLevel21, yellowTilesOnLevel21, yellowTilesOffLevel21, purpleTilesLevel21, orangeTilesLevel21, pinkTilesOnLevel21, pinkTilesOffLevel21, redTilesLevel21,
        };
    }
    //Level1
    public (int, int)[][] allColorArraysBuddingPath;
    public Color[] colorsUsedBuddingPath = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.green
    };
    public (int, int)[] whiteTilesBuddingPath = new (int, int)[]{
        (2, 3), (4, 3), (1, 4), (3, 4), 
        (2, 5), (4, 5), (1, 6), (3, 6), (5, 6),  
        (2, 7), (4, 7), (3, 8), (2, 9), 
        (4, 9)
    };
    public (int, int)[] greenTilesBuddingPath = new (int, int)[] {
        (3,2), (5,4), (3,10), (1,8), (5,8)
    };

    //Level2
    public (int, int)[][] allColorArraysCeruleanStep;
    public Color[] colorsUsedCeruleanStep = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green
    };
    public (int, int)[] whiteTilesCeruleanStep = new (int, int)[]{
        (2, 3), (1, 4), (4, 5), (3, 6), (5, 6),  
        (4, 7), (2,9), (3,10), (5,8)
    };
    public (int, int)[] blueTilesCeruleanStep = new (int, int)[] {
        (1,6), (2,5), (3,4), (4,3), (2,7), (3, 8), (4, 9)
    };
    public (int, int)[] greenTilesCeruleanStep = new (int, int)[] {
        (3,2), (5,4), (1,8)
    };

    //Level3
    public (int, int)[][] allColorArraysVioletLaunch;
    public Color[] colorsUsedVioletLaunch = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesVioletLaunch = new (int, int)[]{
        (1, 4), (2, 5), 
        (4, 7), (1,8), (3,10), (5,8)
    };
    public (int, int)[] blueTilesVioletLaunch = new (int, int)[] {
        (1,6), (2,7), (3, 8), (4, 9), (3, 6)
    };
    public (int, int)[] greenTilesVioletLaunch = new (int, int)[] {
        (3,2), (5,4), (2,9)
    };
    public (int, int)[] purpleTilesVioletLaunch = new (int, int)[] {
        (2,3), (5, 6)
    };

    //Level4
    public (int, int)[][] allColorArraysInterception;
    public Color[] colorsUsedInterception = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesInterception = new (int, int)[]{
        (1,4), (0,7), (4,3),
    };
    public (int, int)[] blueTilesInterception = new (int, int)[] {
        (2,5), (3,6), (4,7), (5,8), (0,5), (2,9)
    };
    public (int, int)[] greenTilesInterception = new (int, int)[] {
        (3,2), (3,10)
    };
    public (int, int)[] purpleTilesInterception = new (int, int)[] {
        (1,8), (5,4)
    };

    //Level5
    public (int, int)[][] allColorArraysIslandHopping;
    public Color[] colorsUsedIslandHopping = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesIslandHopping = new (int, int)[]{
        (3,2), (6,5), (1,10)
    };
    public (int, int)[] blueTilesIslandHopping = new (int, int)[] {
        
    };
    public (int, int)[] greenTilesIslandHopping = new (int, int)[] {
        (2,1), (5,8), (4,11), (0,7), (5,4)
    };
    public (int, int)[] purpleTilesIslandHopping = new (int, int)[] {
        (0,3), (0,9), (6,3), (3,12), (6,9), (3,0)
    };

    //Level6
    public (int, int)[][] allColorArraysChainingCommand;
    public Color[] colorsUsedChainingCommand = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesChainingCommand = new (int, int)[]{
        (0,3), (0,5), (0,7), (1,8), (2,9), (1,2), (2,1), (6,7)
    };
    public (int, int)[] blueTilesChainingCommand = new (int, int)[] {
        (3,2), (2,3), (1,4), (1,6), (3,6), (4,5), (5,6), (5,8), (6,9), (2,7), (3,0)
    };
    public (int, int)[] greenTilesChainingCommand = new (int, int)[] {
        (5,10), (6,5), 
    };
    public (int, int)[] purpleTilesChainingCommand = new (int, int)[] {
        (4,1), (4,11)
    };

    //Level7
    public (int, int)[][] allColorArraysChainingCollapse;
    public Color[] colorsUsedChainingCollapse = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple
    };
    public (int, int)[] whiteTilesChainingCollapse = new (int, int)[]{
        (0, 3), (0,5), (4,9)
    };
    public (int, int)[] blueTilesChainingCollapse = new (int, int)[] {
        (0,7), (1,4), (1,6), (2,7), (2,9), (3,4), (3,6), (3,10), (4,7), (2,3), (5,6)
    };
    public (int, int)[] greenTilesChainingCollapse = new (int, int)[] {
        (0,9), (3,2), (3,12)
    };
    public (int, int)[] purpleTilesChainingCollapse = new (int, int)[] {
        (1,2), (1,10), (4,3), (4,11), (6,7)
    };

    //Level8
    public (int, int)[][] allColorArraysGoldenToggle;
    public Color[] colorsUsedGoldenToggle = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow
    };
    public (int, int)[] whiteTilesGoldenToggle = new (int, int)[]{
        (1,4), (1,6), (2,5), (4,5), (5,6)
    };
    public (int, int)[] blueTilesGoldenToggle = new (int, int)[] {
        (3,4), (3,6), (3,8), (3,10), 
    };
    public (int, int)[] greenTilesGoldenToggle = new (int, int)[] {
        (3,2), (5,4), (4,9), (2,9)
    };
    public (int, int)[] purpleTilesGoldenToggle = new (int, int)[] {
        
    };
    public (int, int)[] yellowTilesOnGoldenToggle = new (int, int)[] {
        (2,3), (4,3),
    };
    public (int, int)[] yellowTilesOffGoldenToggle = new (int, int)[] {
        (1,8), (2,7), (4,7), (5,8)
    };

    //Level9
    public (int, int)[][] allColorArraysCrissCross;
    public Color[] colorsUsedCrissCross = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow
    };
    public (int, int)[] whiteTilesCrissCross = new (int, int)[]{
        
    };
    public (int, int)[] blueTilesCrissCross = new (int, int)[] {
         (3,4), (4,7),  (2,5), (3,8), (1,2),
    };
    public (int, int)[] greenTilesCrissCross = new (int, int)[] {
        (0,9), (6,3), (2,3), (4,9)
    };
    public (int, int)[] purpleTilesCrissCross = new (int, int)[] {
        (0,3), (6,9)
    };
    public (int, int)[] yellowTilesOnCrissCross = new (int, int)[] {
        (0,5), (0,7), (6,5), (6,7), (5,10),
    };
    public (int, int)[] yellowTilesOffCrissCross = new (int, int)[] {
        (1,8), (2,7), (4,5), (5,4), 
    };

    //Level10
    public (int, int)[][] allColorArraysCaptainsWheel;
    public Color[] colorsUsedCaptainsWheel = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow
    };
    public (int, int)[] whiteTilesCaptainsWheel = new (int, int)[]{
        
    };
    public (int, int)[] blueTilesCaptainsWheel = new (int, int)[] {
        (3,6), (3,4), (2,7), (4,7), (3,0)
    };
    public (int, int)[] greenTilesCaptainsWheel = new (int, int)[] {
        (2,5), (4,5), (3,8), (4,1)
    };
    public (int, int)[] purpleTilesCaptainsWheel = new (int, int)[] {
        (0,3), (0,5), (0,7), (0,9), (1,10), (2,11), (3,12), 
        (4,11), (5,10), (6,9), (6,7), (6,5), (6,3), (1,2), 
    };
    public (int, int)[] yellowTilesOnCaptainsWheel = new (int, int)[] {
        (2,1)
    };
    public (int, int)[] yellowTilesOffCaptainsWheel = new (int, int)[] {
        (3,2), (1,8), (5,8)
    };

    //Level11
    public (int, int)[][] allColorArraysBurnout;
    public Color[] colorsUsedBurnout = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow
    };
    public (int, int)[] whiteTilesBurnout = new (int, int)[]{
        
    };
    public (int, int)[] blueTilesBurnout = new (int, int)[] {
        
    };
    public (int, int)[] greenTilesBurnout = new (int, int)[] {
        (1, 2), (4, 1), (2, 5), (4, 5), (6, 7), (5, 10), (3, 10),
    };
    public (int, int)[] purpleTilesBurnout = new (int, int)[] {
         (3, 0), (3, 12), (1, 4), (1, 8), (5, 4), (6, 9),
    };
    public (int, int)[] yellowTilesOnBurnout = new (int, int)[] {
        (2, 1), (3, 2), (5, 2), (0, 3), (2, 3), (4, 3), (6, 3), (3, 4), 
        (0, 5),  (6, 5), (1, 6), (3, 6), (5, 6), (0, 7), (2, 7), (4, 7), 
        (3, 8), (5, 8), (0, 9), (2, 9), (4, 9), (1, 10), (2, 11), (4, 11), 
    };
    public (int, int)[] yellowTilesOffBurnout = new (int, int)[] {
       
    };

    //Level12
    public (int, int)[][] allColorArraysLevel12;
    public Color[] colorsUsedLevel12 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange
    };
    public (int, int)[] whiteTilesLevel12 = new (int, int)[]{
        
    };
    public (int, int)[] blueTilesLevel12 = new (int, int)[] {
        
    };
    public (int, int)[] greenTilesLevel12 = new (int, int)[] {
        
    };
    public (int, int)[] purpleTilesLevel12 = new (int, int)[] {
        
    };
    public (int, int)[] yellowTilesOnLevel12 = new (int, int)[] {
        
    };
    public (int, int)[] yellowTilesOffLevel12 = new (int, int)[] {
       
    };
    public (int, int)[] orangeTilesLevel12 = new (int, int)[] {
        
    };


  




    //Level21 Playground
    public (int, int)[][] allColorArraysLevel21;
    public Color[] colorsUsedLevel21 = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.purple, MapMakerScript.pink, MapMakerScript.pink, MapMakerScript.red
    };
    public (int, int)[] whiteTilesLevel21 = new (int, int)[]{
        (0,3), (1,6), (4,11), (6,5), (6,3)
    };
    public (int, int)[] blueTilesOnLevel21 = new (int, int)[] {
        (2,3), (2,1), (3,0), (1,4), (0,7),
        (1,8), (2,9), (1,10), (6,5), (5,6),
        (4,7), (4,9), (4,3),
    };
    public (int, int)[] greenTilesLevel21 = new (int, int)[] {
        (0,9), (6,9)
    };
    public (int, int)[] yellowTilesOnLevel21 = new (int, int)[] {
        (3,6), (4,1)
    };
    public (int, int)[] yellowTilesOffLevel21 = new (int, int)[] {
        (6,7), (5,8), (5,10), 
    };
    public (int, int)[] purpleTilesLevel21 = new (int, int)[] {
        (3,2), (2,7), (0,5), (5,4), (3,8), (1,2)
    };
    public (int, int)[] orangeTilesLevel21 = new (int, int)[] {
        (3,12), (3,4)
    };
    public (int, int)[] pinkTilesOnLevel21 = new (int, int)[] {
        (2,5),
    };
    public (int, int)[] pinkTilesOffLevel21 = new (int, int)[] {
        (4,5), (2,11), (3,10)
    };
    public (int, int)[] redTilesLevel21 = new (int, int)[] {
        (5,2)
    };

    /*
    public (int, int)[] whiteTilesLevel1 = new (int, int)[]{     --complexity 2
        (1, 4), (1, 6), (1, 8), (2, 3), (2, 5), (2, 7)
        (2, 9), (3, 2), (3, 4), (3, 6), (3, 8), (3,10)
        (4, 3), (4, 5), (4, 7), (4, 9), (5, 4), (5, 6), (5, 8)
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
