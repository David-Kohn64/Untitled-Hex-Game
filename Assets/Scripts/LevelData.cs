using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance { get; private set; }
    public string[] levelcodes;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        levelcodes = new string[]{
            levelcodeBuddingPath,    // Level 1
            levelcodeCeruleanStep,   // Level 2
            levelcodeVioletLaunch,   // Level 3
            levelcodeInterception,   // Level 4
            levelcodeIslandHopping,  // Level 5
            levelcodeChainingCommand,// Level 6
            levelcodeGoldenToggle,   // Level 7
            levelcodeCrissCross,     // Level 8
            levelcodeCaptainsWheel,  // Level 9
            levelcodeBurnout,        // Level 10
            levelcodeEcholocation,   // Level 11
            levelcodeStarburst,      // Level 12
            levelcodeAngelWings,     // Level 13
            levelcodeTurtle,         // Level 14
            levelcodeRedRising,      // Level 15
            levelcodeReconnect,      // Level 16
            levelcodeJellyDonut,     // Level 17
            levelcodeCulmination     // Level 18
        };

    }
    //Edit levelcode in inspector too (when changed here)
    public string levelcodeBuddingPath = "0000011200111100211120011110021200000104"; // Level 1
    public string levelcodeCeruleanStep = "0000013200133100231310031130021100000104"; // Level 2
    public string levelcodeVioletLaunch = "0000013100513200203310000130025100000104"; // Level 3
    public string levelcodeInterception = "0310010500030300203020010300050300000104"; // Level 4
    public string levelcodeIslandHopping = "5025000012000005100005000002020205105003"; // Level 5
    public string levelcodeChainingCommand = "1110133101303103303000503005003320213003"; // Level 6
    public string levelcodeGoldenToggle = "0000011700617200233330061720021700000104"; // Level 7
    public string levelcodeCrissCross = "5662300700237000030300007320070062665003"; // Level 8
    public string levelcodeCaptainsWheel = "5555500756023053733205202305000755555003"; // Level 9
    public string levelcodeBurnout = "6666256566626665666625262666656626625003"; // Level 10
    public string levelcodeEcholocation = "0000011100163100158210017000010500002104"; // Level 11
    public string levelcodeStarburst = "0000030200088000586850008800020200000104"; // Level 12
    public string levelcodeAngelWings = "1111066612083665078305203366066611111003"; // Level 13
    public string levelcodeTurtle = "6000688720888302883800088830388727000003"; // Level 14
    public string levelcodeRedRising = "0000011100111900663330020110001200000104"; // Level 15
    public string levelcodeReconnect = "0000011100786000011020033100093100000104"; // Level 16
    public string levelcodeJellyDonut = "5623600062000063009003700002700063265003"; // Level 17
    public string levelcodeCulmination = "1116110060338850080100007772070002059003"; // Level 18

    public string levelcodeLevel21 = "0000000000000000000000000000000000000"; // Level 21

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
    
}
