using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMakerScript : MonoBehaviour
{
    public static MapMakerScript Instance { get; private set; }
    [SerializeField] public GameObject hex;

    [SerializeField] public GameObject hexOff;
    [SerializeField] public GameObject player;

    public int mapComplexity = 3;  //Should be set by levelManager and not right now

    public static float xUnit = 1.2f; //Units of distance between hexes
    public static float yUnit = 0.7f; //Units of distance between hexes

    private int xReadablePos; //Readable tile units, top left being (3,0)
    private int yReadablePos;
    private float originXPosition;
    private float originYPosition;

    public bool thereIsAPlayer = false;

    public bool isHexOn = true;

    public int amountKeysLeft = 0;
    public static Color green = new Color(0.0f / 255f, 107f / 255f, 61f / 255f);
    public static Color blue = new Color(0f / 255f, 117f / 255f, 218f / 255f);
    public static Color yellow = new Color(253f / 255f, 224f / 255f, 12f / 255f);
    public static Color orange = new Color(255f / 255f, 176f / 255f, 0f / 255f);
    public static Color purple = new Color(154f / 255f, 64f / 255f, 254f / 255f);
    public static Color pink = new Color(254f / 255f, 100f / 255f, 225f / 255f);
    public static Color red = new Color(255f / 255f, 0f / 255f, 0f / 255f);
    public static Color black = new Color(100f / 255f, 100f / 255f, 100f / 255f);

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeMap(int mapComplexity)
    {
        originXPosition = -1 * xUnit * mapComplexity; //Unity x-coordinate of where origin should be
        originYPosition = yUnit * mapComplexity; //Unity y-coordinate of where origin should be

        if (thereIsAPlayer == false)
        {
            CreatePlayer(LevelManagerScript.Instance.spawnPoint);
            thereIsAPlayer = true;
        }
        else
        {
            PlayerScript.Instance.Move(LevelManagerScript.Instance.spawnPoint);
        }
        float xPosition = originXPosition;
        float yPosition = originYPosition;
        int tileAmount = mapComplexity;

        for (int i = 1; i <= (mapComplexity * 2) + 1; i++) //columns
        {

            for (int j = 0; j <= tileAmount; j++) //rows
            {
                CreateHex(xPosition, yPosition);
                yPosition -= 2 * yUnit;
            }
            xPosition += xUnit;
            if (i <= mapComplexity)
            {
                yPosition = originYPosition + (i * yUnit);
                tileAmount += 1;
            }
            if (i > mapComplexity)
            {
                yPosition = originYPosition + ((mapComplexity - (i - mapComplexity)) * yUnit);
                tileAmount -= 1;
            }

        }
    }

    private void CreateHex(float unityXPos, float unityYPos)
    {
        xReadablePos = ToReadablePosition(unityXPos, "x");
        yReadablePos = ToReadablePosition(unityYPos, "y");

        Color color = DetermineColor(LevelManagerScript.Instance.currentLevel);

        if (color != Color.black)
        {
            GameObject hexInstance = Instantiate(hex, new Vector3(unityXPos, unityYPos, 0), transform.rotation);
            HexScript hexScript = hexInstance.GetComponent<HexScript>();
            hexScript.coordinates = (xReadablePos, yReadablePos);
            hexScript.ColorizeHex(color);

            if (color == yellow || color == pink)
            {
                CreateHexOff(unityXPos, unityYPos, color);
                if (isHexOn == false)
                {
                    isHexOn = true;
                    hexInstance.SetActive(false);
                    hexScript.thisHexIsOn = false;
                }
            }

            if (color == green)
            {
                amountKeysLeft++;
            }
            HexManagerScript.Instance.allHexes.Add((xReadablePos, yReadablePos), hexInstance);
        }
    }
    public void CreateHexOff(float unityXPos, float unityYPos, Color color)
    {
        GameObject hexOffInstance = Instantiate(hexOff, new Vector3(unityXPos, unityYPos, 0), transform.rotation);
        HexScript hexScript = hexOffInstance.GetComponent<HexScript>();
        hexScript.ColorizeHex(color);
        HexManagerScript.Instance.onOffHexes.Add((xReadablePos, yReadablePos), hexOffInstance);
    }
    private void CreatePlayer((int x, int y) spawnPoint)
    {
        Instantiate(player, new Vector3(ToUnityPosition(spawnPoint.x, "x"), ToUnityPosition(spawnPoint.y, "y"), -1), transform.rotation);
    }

    private Color DetermineColor(int Level)
    {
        switch (Level)
        {
            case 1:
                return GetColorFromLists(LevelData.Instance.colorsUsedBuddingPath, LevelData.Instance.allColorArraysBuddingPath);
            case 2:
                return GetColorFromLists(LevelData.Instance.colorsUsedCeruleanStep, LevelData.Instance.allColorArraysCeruleanStep);
            case 3:
                return GetColorFromLists(LevelData.Instance.colorsUsedVioletLaunch, LevelData.Instance.allColorArraysVioletLaunch);
            case 4:
                return GetColorFromLists(LevelData.Instance.colorsUsedInterception, LevelData.Instance.allColorArraysInterception);
            case 5:
                return GetColorFromLists(LevelData.Instance.colorsUsedIslandHopping, LevelData.Instance.allColorArraysIslandHopping);
            case 6:
                return GetColorFromLists(LevelData.Instance.colorsUsedChainingCommand, LevelData.Instance.allColorArraysChainingCommand);
            case 7:
                return GetColorFromLists(LevelData.Instance.colorsUsedChainingCollapse, LevelData.Instance.allColorArraysChainingCollapse);
            case 8:
                return GetColorFromLists(LevelData.Instance.colorsUsedGoldenToggle, LevelData.Instance.allColorArraysGoldenToggle, LevelData.Instance.yellowTilesOffGoldenToggle);
            case 9:
                return GetColorFromLists(LevelData.Instance.colorsUsedCrissCross, LevelData.Instance.allColorArraysCrissCross, LevelData.Instance.yellowTilesOffCrissCross);
            case 10:
                return GetColorFromLists(LevelData.Instance.colorsUsedCaptainsWheel, LevelData.Instance.allColorArraysCaptainsWheel, LevelData.Instance.yellowTilesOffCaptainsWheel);
            case 11:
                return GetColorFromLists(LevelData.Instance.colorsUsedBurnout, LevelData.Instance.allColorArraysBurnout, LevelData.Instance.yellowTilesOffBurnout);
            case 12:
                return GetColorFromLists(LevelData.Instance.colorsUsedLevel12, LevelData.Instance.allColorArraysLevel12, LevelData.Instance.yellowTilesOffLevel12);
            case 21:
                return GetColorFromLists(LevelData.Instance.colorsUsedLevel21, LevelData.Instance.allColorArraysLevel21, LevelData.Instance.yellowTilesOffLevel21, LevelData.Instance.pinkTilesOffLevel21);

            default:
                Debug.LogWarning("Level not implemented");
                return Color.white;

        }
    }
    private Color GetColorFromLists(Color[] colorsUsed, (int, int)[][] allColors, (int, int)[] yellowTilesOff, (int, int)[] pinkTilesOff)
    {
        const float tolerance = 0.01f;
        for (int j = 0; j < allColors.Length; j++)
        {
            for (int k = 0; k < allColors[j].Length; k++)
            {
                (int a, int b) = allColors[j][k];
                if (Mathf.Abs(a - xReadablePos) < tolerance && Mathf.Abs(b - yReadablePos) < tolerance)
                {

                    if (allColors[j] == yellowTilesOff || allColors[j] == pinkTilesOff)
                    { //for yellow On/Off tiles
                        isHexOn = false;
                    }
                    return colorsUsed[j];
                }
            }
        }
        return Color.black; //This means do not create hex!
    }
    private Color GetColorFromLists(Color[] colorsUsed, (int, int)[][] allColors, (int, int)[] yellowTilesOff) { return GetColorFromLists(colorsUsed, allColors, yellowTilesOff, yellowTilesOff);}
    private Color GetColorFromLists(Color[] colorsUsed, (int, int)[][] allColors)
    {
        const float tolerance = 0.01f;
        for (int j = 0; j < allColors.Length; j++)
        {
            for (int k = 0; k < allColors[j].Length; k++)
            {
                (int a, int b) = allColors[j][k];
                if (Mathf.Abs(a - xReadablePos) < tolerance && Mathf.Abs(b - yReadablePos) < tolerance)
                {
                    return colorsUsed[j];
                }
            }
        }
        return Color.black; //This means do not create hex!
    }

    public int ToReadablePosition(float unityPos, string axis)
    {
        if (axis.Equals("x")){
            return (int)Mathf.Round(mapComplexity + (unityPos / xUnit));
        }
        else { //y-axis
            return (int)Mathf.Round((mapComplexity * 2) - (unityPos / yUnit));
        }
    }

    public float ToUnityPosition(int readablePos, string axis)
    {
        if (axis.Equals("x")){
            return (readablePos - mapComplexity) * xUnit;
        }
        else { //y-axis
            return (mapComplexity * 2 - readablePos) * yUnit;
        }
    }
}