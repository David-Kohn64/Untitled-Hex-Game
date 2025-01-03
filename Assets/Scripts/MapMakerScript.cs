using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMakerScript : MonoBehaviour
{
    public static MapMakerScript Instance { get; private set; }
    [SerializeField] public GameObject hex;

    [SerializeField] public GameObject hexOff;
    [SerializeField] public GameObject triangle;
    
    public int mapComplexity = 3;  //Should be set by levelManager and not right now
    public int currentLevel = 1; //Should be set by levelManager and not now
    
    public static float xUnit = 1.2f; //Units of distance between hexes
    public static float yUnit = 0.7f; //Units of distance between hexes

    private float xTilePos; //Readable tile units, top left being (3,0)
    private float yTilePos;
    private float originXPosition;
    private float originYPosition;

    public bool thereIsAPlayer = false;

    public bool isHexOn = true;

    public int amountKeysLeft = 0;
    public static Color red = new Color(161f/255f, 28f/255f, 15f/255f); 
    public static Color green = new Color(0.0f/255f, 107f/255f, 61f/255f); 
    public static Color blue = new Color(0f/255f, 117f/255f, 218f/255f); 
    public static Color yellow = new Color(253f/255f, 224f/255f, 12f/255f);
    public static Color orange = new Color(255f/255f, 176f/255f, 0f/255f);
    public static Color black = new Color(100f/255f, 100f/255f, 100f/255f);

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

    public void makeMap(int currentLevel, int mapComplexity){
        originXPosition = -1 * xUnit * mapComplexity; //Coordinate of where origin should be
        originYPosition = yUnit * mapComplexity; //Coordinate of where origin should be
        if (thereIsAPlayer == false){
            createTriangle(originXPosition, originYPosition);
            thereIsAPlayer = true;
        }
        else {
            TriangleScript.Instance.Move(originXPosition, originYPosition);
        }
        float xPosition = originXPosition;
        float yPosition = originYPosition;
        int tileAmount = mapComplexity;
        
        for (int i = 1; i <= (mapComplexity*2) + 1; i++) //columns
        {
            
            for (int j = 0; j <= tileAmount; j++) //rows
            {
                createHex(xPosition, yPosition);
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
                yPosition = originYPosition + ((mapComplexity -(i - mapComplexity)) * yUnit);
                tileAmount -= 1;
            }
            
        }
    }

    private void createHex(float xPos, float yPos){
        xTilePos = mapComplexity + (xPos / xUnit);
        yTilePos = (mapComplexity * 2) - (yPos / yUnit);

        
        Color color = determineColor(currentLevel, xTilePos, yTilePos);

        if (color != Color.black){
            GameObject hexInstance = Instantiate(hex, new Vector3(xPos, yPos, 0), transform.rotation);
            HexScript hexScript = hexInstance.GetComponent<HexScript>();
            hexScript.ColorizeHex(color);

            if (color == yellow){
                GameObject hexOffInstance = Instantiate(hexOff, new Vector3(xPos, yPos, 0), transform.rotation);
                HexManagerScript.Instance.addHex(xPos, yPos, hexOffInstance, HexManagerScript.Instance.onOffHexes);
                if (isHexOn == false){
                    isHexOn = true;
                    hexInstance.SetActive(false);
                    hexScript.thisHexIsOn = false;
                }  
            }

            if (color == green){
                amountKeysLeft++;
            }

            HexManagerScript.Instance.addHex(xPos, yPos, hexInstance, HexManagerScript.Instance.allHexes);
        }
    }
    private void createTriangle(float xPos, float yPos){
        Instantiate(triangle, new Vector3(xPos, yPos, -1), transform.rotation);
    }

    private Color determineColor(int Level, float xTilePos, float yTilePos){
        switch (Level)
        {
            case 1:

            return getColorFromLists(LevelData.Instance.colorsUsedLevel1, LevelData.Instance.allColorsLevel1, LevelData.Instance.yellowTilesOffLevel1);

            case 2:
                return Color.white; 
           
            case 3:
                return Color.white; 
           
            default:
                Debug.LogWarning("Level not implemented.");
                return Color.white; 
                
        }
    }
    private Color getColorFromLists(Color[] colorsUsed, (int, int)[][] allColors, (int, int)[] yellowTilesOff){
        const float tolerance = 0.01f;
        for (int j = 0; j < allColors.Length; j++)
        {
            for (int k = 0; k < allColors[j].Length; k++)
            {
                (int a, int b) = allColors[j][k];
                if (Mathf.Abs(a - xTilePos) < tolerance && Mathf.Abs(b - yTilePos) < tolerance){

                    if (colorsUsed[j] == yellow && allColors[j] == yellowTilesOff){ //for yellow On/Off tiles
                        isHexOn = false;
                    }
                    return colorsUsed[j];
                }
            }
        }
            return Color.black; //This means do not create hex!
    }
}