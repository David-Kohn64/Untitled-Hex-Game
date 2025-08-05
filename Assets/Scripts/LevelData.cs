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
        allColorArraysEcholocation = new (int, int)[][]{
            whiteTilesEcholocation, blueTilesEcholocation, greenTilesEcholocation, purpleTilesEcholocation, yellowTilesOnEcholocation, yellowTilesOffEcholocation, orangeTilesEcholocation
        };
        allColorArraysStarburst = new (int, int)[][]{
            whiteTilesStarburst, blueTilesStarburst, greenTilesStarburst, purpleTilesStarburst, yellowTilesOnStarburst, yellowTilesOffStarburst, orangeTilesStarburst
        };
        allColorArraysAngelWings = new (int, int)[][]{
            whiteTilesAngelWings, blueTilesAngelWings, greenTilesAngelWings, purpleTilesAngelWings, yellowTilesOnAngelWings, yellowTilesOffAngelWings, orangeTilesAngelWings
        };
        allColorArraysTurtle = new (int, int)[][]{
            whiteTilesTurtle, blueTilesTurtle, greenTilesTurtle, purpleTilesTurtle, yellowTilesOnTurtle, yellowTilesOffTurtle, orangeTilesTurtle
        };
        allColorArraysRedRising = new (int, int)[][]{
            whiteTilesRedRising, blueTilesRedRising, greenTilesRedRising, purpleTilesRedRising, yellowTilesOnRedRising, yellowTilesOffRedRising, orangeTilesRedRising, redTilesRedRising
        };
        allColorArraysReconnect = new (int, int)[][]{
            whiteTilesReconnect, blueTilesReconnect, greenTilesReconnect, purpleTilesReconnect, yellowTilesOnReconnect, yellowTilesOffReconnect, orangeTilesReconnect, redTilesReconnect
        };
        allColorArraysJellyDonut = new (int, int)[][]{
            whiteTilesJellyDonut, blueTilesJellyDonut, greenTilesJellyDonut, purpleTilesJellyDonut, yellowTilesOnJellyDonut, yellowTilesOffJellyDonut, orangeTilesJellyDonut, redTilesJellyDonut
        };
        allColorArraysCulmination = new (int, int)[][]{
            whiteTilesCulmination, blueTilesCulmination, greenTilesCulmination, purpleTilesCulmination, yellowTilesOnCulmination, yellowTilesOffCulmination, orangeTilesCulmination, redTilesCulmination
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

    //Bad Level 7
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

    //Level7
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

    //Level8
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

    //Level9
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

    //Level10
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

    //Level11
    public (int, int)[][] allColorArraysEcholocation;
    public Color[] colorsUsedEcholocation = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange
    };
    public (int, int)[] whiteTilesEcholocation = new (int, int)[]{
        (1,4), (2,3), (3,2), (4,3), (5,4), (1,6), (1,8), (2,9), (3,10)
    };
    public (int, int)[] blueTilesEcholocation = new (int, int)[] {
        (2,7)
    };
    public (int, int)[] greenTilesEcholocation = new (int, int)[] {
        (3,8), (6,9)
    };
    public (int, int)[] purpleTilesEcholocation = new (int, int)[] {
        (3,4), (5,8)
    };
    public (int, int)[] yellowTilesOnEcholocation = new (int, int)[] {
        (2,5)
    };
    public (int, int)[] yellowTilesOffEcholocation = new (int, int)[] {
        (4,5)
    };
    public (int, int)[] orangeTilesEcholocation = new (int, int)[] {
        (3,6)
    };

    //Level12
    public (int, int)[][] allColorArraysStarburst;
    public Color[] colorsUsedStarburst = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange
    };
    public (int, int)[] whiteTilesStarburst = new (int, int)[]{
        
    };
    public (int, int)[] blueTilesStarburst = new (int, int)[] {
        (1,4)
    };
    public (int, int)[] greenTilesStarburst = new (int, int)[] {
        (1,8), (5,8), (5,4)
    };
    public (int, int)[] purpleTilesStarburst = new (int, int)[] {
        (3,10), (3,2)
    };
    public (int, int)[] yellowTilesOnStarburst = new (int, int)[] {
        (3,6)
    };
    public (int, int)[] yellowTilesOffStarburst = new (int, int)[] {
       
    };
    public (int, int)[] orangeTilesStarburst = new (int, int)[] {
       (3,4), (2,5), (2,7), (3,8), (4,5), (4,7)
    };


    //Level13
    public (int, int)[][] allColorArraysAngelWings;
    public Color[] colorsUsedAngelWings = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange
    };
    public (int, int)[] whiteTilesAngelWings = new (int, int)[]{
        (0,3), (0,5), (0,7), (0,9), (1,10), (5,10), (6,3), (6,5), (6,7), (6,9)
    };
    public (int, int)[] blueTilesAngelWings = new (int, int)[] {
        (2,7), (3,8), (4,7), (4,5)
    };
    public (int, int)[] greenTilesAngelWings = new (int, int)[] {
        (2,1), (4,1)
    };
    public (int, int)[] purpleTilesAngelWings = new (int, int)[] {
        (3,0), (3,12)
    };
    public (int, int)[] yellowTilesOnAngelWings = new (int, int)[] {
        (1,4), (1,6), (1,8), (2,9), (2,11), (5,4), (5,6), (5,8), (4,9), (4,11)
    };
    public (int, int)[] yellowTilesOffAngelWings = new (int, int)[] {
        (3,4)
    };
    public (int, int)[] orangeTilesAngelWings = new (int, int)[] {
       (2,5), (3,6)
    };

    //Level14
    public (int, int)[][] allColorArraysTurtle;
    public Color[] colorsUsedTurtle = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange
    };
    public (int, int)[] whiteTilesTurtle = new (int, int)[]{
        
    };
    public (int, int)[] blueTilesTurtle = new (int, int)[] {
        (5,2), (2,9), (4,9), (3, 6),
    };
    public (int, int)[] greenTilesTurtle = new (int, int)[] {
        (3,0), (1,10), (5,10)
    };
    public (int, int)[] purpleTilesTurtle = new (int, int)[] {
       
    };
    public (int, int)[] yellowTilesOnTurtle = new (int, int)[] {
        (0,3), (1,2)
    };
    public (int, int)[] yellowTilesOffTurtle = new (int, int)[] {
        (6,3), (5, 8), (1, 8)
    };
    public (int, int)[] orangeTilesTurtle = new (int, int)[] {
       (1, 4), (1, 6), (2, 3), (2, 5), (2, 7),
        (3, 2), (3, 4), (3, 8), (4, 3), (4, 5),
        (4, 7), (5, 4), (5, 6), 
    };

    //Level15
    public (int, int)[][] allColorArraysRedRising;
    public Color[] colorsUsedRedRising  = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange, MapMakerScript.red
    };
    public (int, int)[] whiteTilesRedRising = new (int, int)[]{
        (1,4), (1,6), (1,8), (2,3), (2,5), (2,7), (4,7), (4,9), (5,6)
    };
    public (int, int)[] blueTilesRedRising = new (int, int)[] {
        (4,7), (3,6), (3,8), (3,10), 
    };
    public (int, int)[] greenTilesRedRising = new (int, int)[] {
        (4,3), (5,8)
    };
    public (int, int)[] purpleTilesRedRising  = new (int, int)[] {
       
    };
    public (int, int)[] yellowTilesOnRedRising  = new (int, int)[] {
        (3,2), (3,4)
    };
    public (int, int)[] yellowTilesOffRedRising  = new (int, int)[] {
        
    };
    public (int, int)[] orangeTilesRedRising  = new (int, int)[] {
       
    };
    public (int, int)[] redTilesRedRising  = new (int, int)[] {
        (2,9)
    };

    //Level16
    public (int, int)[][] allColorArraysReconnect;
    public Color[] colorsUsedReconnect  = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange, MapMakerScript.red
    };
    public (int, int)[] whiteTilesReconnect = new (int, int)[]{
       (1,4), (1,6), (1,8), (4,7), (5,8), (3,6),  (3,4),
    };
    public (int, int)[] blueTilesReconnect = new (int, int)[] {
        (4,5), (4,3), (5,6),
    };
    public (int, int)[] greenTilesReconnect = new (int, int)[] {
       (3,10)
    };
    public (int, int)[] purpleTilesReconnect  = new (int, int)[] {
       
    };
    public (int, int)[] yellowTilesOnReconnect  = new (int, int)[] {
        (2,7)
    };
    public (int, int)[] yellowTilesOffReconnect  = new (int, int)[] {
        (2,3)
    };
    public (int, int)[] orangeTilesReconnect  = new (int, int)[] {
        (2,5)
    };
    public (int, int)[] redTilesReconnect  = new (int, int)[] {
        (5,4),
    };

    //Level17
    public (int, int)[][] allColorArraysJellyDonut;
    public Color[] colorsUsedJellyDonut  = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange, MapMakerScript.red
    };
    public (int, int)[] whiteTilesJellyDonut = new (int, int)[]{
       
    };
    public (int, int)[] blueTilesJellyDonut = new (int, int)[] {
        (3,0), (3,12), (0,9), (6,3)
    };
    public (int, int)[] greenTilesJellyDonut = new (int, int)[] {
       (2,1), (0,7), (4,11), (6,5)
    };
    public (int, int)[] purpleTilesJellyDonut = new (int, int)[] {
       (0,3), (6,9)
    };
    public (int, int)[] yellowTilesOnJellyDonut = new (int, int)[] {
        (1,2), (0,5), (1,10), (2,11), (5,10), (6,7)
    };
    public (int, int)[] yellowTilesOffJellyDonut = new (int, int)[] {
       (4,1), (5,2)
    };
    public (int, int)[] orangeTilesJellyDonut = new (int, int)[] {
        
    };
    public (int, int)[] redTilesJellyDonut = new (int, int)[] {
        (3,6),
    };

    //Level18
    public (int, int)[][] allColorArraysCulmination;
    public Color[] colorsUsedCulmination  = new Color[]{ //WHEN ADDING NEW COLOR, ADD TO SCRIPT IN INSPECTOR AS WELL
        Color.white, MapMakerScript.blue, MapMakerScript.green, MapMakerScript.purple, MapMakerScript.yellow, MapMakerScript.yellow, MapMakerScript.orange, MapMakerScript.red
    };
    public (int, int)[] whiteTilesCulmination = new (int, int)[]{
       (0,3), (0,5), (0,7), (1,2), (1,4), (3,8), 
    };
    public (int, int)[] blueTilesCulmination = new (int, int)[] {
       (2,5), (2,3)
    };
    public (int, int)[] greenTilesCulmination = new (int, int)[] {
       (4,11), (6,3)
    };
    public (int, int)[] purpleTilesCulmination = new (int, int)[] {
       (2,11), (6,7)
    };
    public (int, int)[] yellowTilesOnCulmination = new (int, int)[] {
        (0,9), (1,10), 
    };
    public (int, int)[] yellowTilesOffCulmination = new (int, int)[] {
       (5,4), (4,5), (4,7), (4,9)
    };
    public (int, int)[] orangeTilesCulmination = new (int, int)[] {
        (2,7), (3,4), (2,9)
    };
    public (int, int)[] redTilesCulmination = new (int, int)[] {
        (6,9)
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
        (1, 4), (1, 6), (1, 8), (2, 3), (2, 5), (2, 7),
        (2, 9), (3, 2), (3, 4), (3, 6), (3, 8), (3,10),
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
