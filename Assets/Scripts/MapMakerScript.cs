using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using static UnityEngine.Mathf;

public class MapMakerScript : MonoBehaviour
{
    public const int COMPLEXITY = 3;
    public static MapMakerScript Instance { get; private set; }
    [SerializeField] public GameObject hex;

    [SerializeField] public GameObject hexOff;
    [SerializeField] public GameObject player;

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
    public Color[] colorsUsed = new Color[]{ 
        Color.white, green, green, blue, blue, blue, blue, blue, yellow, yellow, yellow, yellow, orange, purple, red, Color.black, Color.black, Color.black, Color.black
    };
    public System.Random random = new System.Random();
    private bool firstHex = true;
    public int currentLevel;
    public string levelcode = "0000000000000000000000000000000000000000"; // length: 40
    private int currentHexIndex = 0;
    private int playerSpawnIndex = 37;
    public Stack<string> undoStack = new Stack<string>();

    private Dictionary<string, Color> levelcodeToColor = new Dictionary<string, Color>()
    {
        { "0", Color.black }, //no tile
        { "1", Color.white },
        { "2", green},
        { "3", blue}, 
        { "4", blue }, //ccfalling
        { "5", purple },
        { "6", yellow}, //on
        { "7", yellow}, //off
        { "8", orange }, 
        { "9", red }, 
        { "A", red }, //temporary
    };

    private Dictionary<(int x, int y), int> hexToLevelcodeIndex = new Dictionary<(int x, int y), int>()
{
    { (0, 3), 0 }, { (0, 5), 1 }, { (0, 7), 2 }, { (0, 9), 3 },
    { (1, 2), 4 }, { (1, 4), 5 }, { (1, 6), 6 }, { (1, 8), 7 }, { (1, 10), 8 },
    { (2, 1), 9 }, { (2, 3), 10 }, { (2, 5), 11 }, { (2, 7), 12 }, { (2, 9), 13 },{ (2, 11), 14 },
    { (3, 0), 15 }, { (3, 2), 16 }, { (3, 4), 17 }, { (3, 6), 18 }, { (3, 8), 19 }, { (3, 10), 20 }, { (3, 12), 21 },
    { (4, 1), 22 }, { (4, 3), 23 }, { (4, 5), 24 }, { (4, 7), 25 }, { (4, 9), 26 }, { (4, 11), 27 },
    { (5, 2), 28 }, { (5, 4), 29 }, { (5, 6), 30 }, { (5, 8), 31 }, { (5, 10), 32 },
    { (6, 3), 33 }, { (6, 5), 34 }, { (6, 7), 35 }, { (6, 9), 36 }
};

    void Awake()
    {
        Instance = this;
    }

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
        currentLevel = level;
        levelcode = LevelData.Instance.levelcodes[currentLevel - 1];
        MakeMap(levelcode);
    }

    public void MakeMap(string givenLevelcode)
    {
        levelcode = givenLevelcode;
        CreatePlayer();

        foreach (var hex in hexToLevelcodeIndex)
        {
            currentHexIndex = hex.Value;
            CreateHex(hex.Key.x, hex.Key.y);
        }
    }

    private void CreateHex(int xReadablePos, int yReadablePos)
    {
        float unityXPos = ToUnityPosition(xReadablePos, "x");
        float unityYPos = ToUnityPosition(yReadablePos, "y");
        Color color = DetermineColor();

        string tileFlag = GetFlagFromCode();

        if (tileFlag == "tempGrowth")
        {
            HexManagerScript.Instance.growthHexes.Add((xReadablePos, yReadablePos), CreateNewHex((xReadablePos, yReadablePos), color));
        }
        else if (color != Color.black)
        {
            GameObject hexInstance = Instantiate(hex, new Vector3(unityXPos, unityYPos, 0), transform.rotation);
            HexScript hexScript = hexInstance.GetComponent<HexScript>();
            hexScript.coordinates = (xReadablePos, yReadablePos);
            hexScript.ColorizeHex(color);
            
            if (tileFlag == "ccfalling")
            {
                hexScript.ccfalling = true;
            }
            if (color == yellow)
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
    public GameObject CreateNewHex((int xReadablePos, int yReadablePos) newHex, Color color)
    {
        GameObject hexInstance = Instantiate(hex, new Vector3(ToUnityPosition(newHex.xReadablePos, "x"), ToUnityPosition(newHex.yReadablePos, "y"), 0), transform.rotation);
        HexScript hexScript = hexInstance.GetComponent<HexScript>();
        hexScript.coordinates = (newHex.xReadablePos, newHex.yReadablePos);
        hexScript.ColorizeHex(color);
        return hexInstance;

    }
    public void CreateHexOff(float unityXPos, float unityYPos, Color color)
    {
        GameObject hexOffInstance = Instantiate(hexOff, new Vector3(unityXPos, unityYPos, 0), transform.rotation);
        HexScript hexScript = hexOffInstance.GetComponent<HexScript>();
        hexScript.ColorizeHex(color);
        HexManagerScript.Instance.onOffHexes.Add((ToReadablePosition(unityXPos, "x"), ToReadablePosition(unityYPos, "y")), hexOffInstance);
    }
    private void CreatePlayer()
    {
        int playerXCoordinate = levelcode[playerSpawnIndex] - '0';
        int playerYCoordinate = int.Parse(levelcode.Substring(playerSpawnIndex + 1, 2));
        if (thereIsAPlayer)
        {
            PlayerScript.Instance.Move(ToUnityPosition(playerXCoordinate, "x"), ToUnityPosition(playerYCoordinate, "y"));
        }
        else {
            Instantiate(player, new Vector3(ToUnityPosition(playerXCoordinate, "x"), ToUnityPosition(playerYCoordinate, "y"), -1), transform.rotation);
        }
        thereIsAPlayer = true;
    }

    private string GetLevelCode()
    {
        return LevelData.Instance.levelcodes[currentLevel - 1];
    }
    private Color DetermineColor() 
    {
        if (currentLevel == 20) //Infinite (TODO: create random levelcode)
        {
            int randomColor = random.Next(0, 19);
            if (firstHex && randomColor > 15) {randomColor = random.Next(0, 15);}
            Color returnRandomColor = colorsUsed[randomColor];
            if (returnRandomColor == yellow)
            {
                int sixtySixPercent = random.Next(0, 3);
                if (sixtySixPercent == 2 && !firstHex)
                {
                    isHexOn = !isHexOn;
                }
            }
            firstHex = false;
            return returnRandomColor;
        }
        else
        {
            return GetColorFromCode();
        }
    }
    private Color GetColorFromCode()
    {
        string levelcodeBit = levelcode[currentHexIndex].ToString();
        return levelcodeToColor[levelcodeBit];
    }
    private string GetFlagFromCode()
    {
        string levelcodeBit = levelcode[currentHexIndex].ToString();
        switch (levelcodeBit)
        {
            case "4":
                return "ccfalling";
            case "7":
                isHexOn = false;
                return "off";
            case "A":
                return "tempGrowth";
            default:
                return null;
        } 
    }
    public string Encode()
    {
        StringBuilder levelcode = new StringBuilder("0000000000000000000000000000000000000000"); // length: 40

        foreach( var hex in HexManagerScript.Instance.allHexes)
        {
            char levelcodeBit = '0';
            HexScript hexScript = hex.Value.GetComponent<HexScript>();
            Color col = hexScript.spriteRenderer.color;

            if (col == Color.white) levelcodeBit = '1';
            else if (col == MapMakerScript.green)  levelcodeBit = '2';
            else if (col == MapMakerScript.blue) 
            {
                levelcodeBit = !hexScript.ccfalling ? '3' : '4';
            }
            else if (col == MapMakerScript.purple) levelcodeBit = '5';
            else if (col == MapMakerScript.yellow)
            {
                levelcodeBit = hexScript.thisHexIsOn ? '6' : '7';
            }
            else if (col == MapMakerScript.orange) levelcodeBit = '8';
            else if (col == MapMakerScript.red)    levelcodeBit = '9';

            levelcode[hexToLevelcodeIndex[hex.Key]] = levelcodeBit;
        }
        foreach( var hex in HexManagerScript.Instance.growthHexes)
        {
            levelcode[hexToLevelcodeIndex[hex.Key]] = 'A';
        }

        if (thereIsAPlayer)
        {
            int playerXCoord = ToReadablePosition(PlayerScript.Instance.transform.position.x, "x");
            int playerYCoord = ToReadablePosition(PlayerScript.Instance.transform.position.y, "y");
            levelcode[playerSpawnIndex] = (char)(playerXCoord + '0');
            levelcode[playerSpawnIndex + 1] = (char)(Mathf.Floor(playerYCoord / 10) + '0');
            levelcode[playerSpawnIndex + 2] = (char)(playerYCoord % 10 +'0');
        }

        return levelcode.ToString();
    }


    public int ToReadablePosition(float unityPos, string axis)
    {
        if (axis.Equals("x"))
        {
            return (int)Mathf.Round(COMPLEXITY + (unityPos / xUnit));
        }
        else
        { //y-axis
            return (int)Mathf.Round((COMPLEXITY * 2) - (unityPos / yUnit));
        }
    }

    public float ToUnityPosition(int readablePos, string axis)
    {
        if (axis.Equals("x"))
        {
            return (readablePos - COMPLEXITY) * xUnit;
        }
        else
        { //y-axis
            return (COMPLEXITY * 2 - readablePos) * yUnit;
        }
    }
}