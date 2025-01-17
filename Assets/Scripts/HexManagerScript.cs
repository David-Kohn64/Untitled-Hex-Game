using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexManagerScript : MonoBehaviour
{
    public static HexManagerScript Instance { get; private set; }

    public Dictionary<(int x, int y), GameObject> allHexes = new Dictionary<(int x, int y), GameObject>(); //assigns every hex to its coordinates

    public Dictionary<(int x, int y), GameObject> onOffHexes = new Dictionary<(int x, int y), GameObject>(); //dotted On/Off hex objects
    (int x, int y)[] neighborOffsets = { (-1, -1), (-1, 1), (0, -2), (0, 2), (1, -1), (1, 1)}; 



    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addHex(float xPos, float yPos, GameObject hex, Dictionary<(int, int), GameObject> hexDictionary){
        int x = (int)Mathf.Round(xPos / MapMakerScript.xUnit);
        int y = (int)Mathf.Round(yPos / MapMakerScript.yUnit);
        hexDictionary.Add((x, y), hex);
        //Debug.Log(x + ", " + y + " Added to allHexes");
    }
    public void DestroyAllHexes(){
        foreach (var hex in allHexes){
            Destroy(hex.Value);
        }
        allHexes.Clear();

        foreach (var hex in onOffHexes){
            Destroy(hex.Value);
        }
        onOffHexes.Clear();
    }
    public void processPassiveStep(){ //Lingering effects of tiles previously activated
        ChainCollapseHandler();
            //will add more handlers for each color
    }
    public void processActiveStep(GameObject hex, Color color){ //Effects of tiles currently pressed on
        if (color.Equals(MapMakerScript.black)){
            WinLevelHandler();
        }
        if (color.Equals(MapMakerScript.green)){
            KeyHexCollectHandler(hex, MapMakerScript.green);
        }
        if (color.Equals(MapMakerScript.orange)){
            OnOffButtonHandler();
        }
    }
    void ChainCollapseHandler(){

        var enumerator = allHexes.GetEnumerator();
        var keysToRemove = new List<(int x, int y)>(); 
        var keysToFalling = new List<(int x, int y)>();
    
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current; 
            var (currentX, currentY) = current.Key; // Deconstruct the tuple
            GameObject thisHex = current.Value;
            HexScript hexScript = thisHex.GetComponent<HexScript>();
            SpriteRenderer spriteRenderer = thisHex.GetComponent<SpriteRenderer>();

            if (hexScript.ccfalling) // checks if ccfalling already true and therefore now destroy hex
            {
                keysToRemove.Add(current.Key); 
            }
            else { // checks if neighbor is ccfalling and therefore this hex should be ccfalling too
                foreach (var offset in neighborOffsets){
                    var neighborKey = (currentX + offset.x, currentY + offset.y);

                    if (allHexes.TryGetValue(neighborKey, out GameObject neighbor))
                    {
                        HexScript neighborHexScript = neighbor.GetComponent<HexScript>();
                        if (neighborHexScript.ccfalling)
                        {
                            if(spriteRenderer.color == MapMakerScript.blue){
                                keysToFalling.Add(current.Key);
                                break; //Exit early if any are falling
                            }
                        }
                    }
                }
            }
        }
        foreach (var key in keysToRemove){
            Destroy(allHexes[key]);
            allHexes.Remove(key);
        }
        foreach (var key in keysToFalling){
            GameObject hex = allHexes[key];
            HexScript hexScript = hex.GetComponent<HexScript>();
            hexScript.ccfalling = true; 
        }
    }

    
    void KeyHexCollectHandler(GameObject hex, Color color){
        SpriteRenderer spriteRenderer = hex.GetComponent<SpriteRenderer>(); 
        spriteRenderer.color = Color.white;
        MapMakerScript.Instance.amountKeysLeft--;

    }
    void OnOffButtonHandler(){
        foreach (var hex in allHexes){
            GameObject current = hex.Value;
            SpriteRenderer spriteRenderer = current.GetComponent<SpriteRenderer>();
            HexScript hexScript = current.GetComponent<HexScript>();

            if (spriteRenderer.color == MapMakerScript.yellow && current.activeSelf){
                current.SetActive(false);
                hexScript.thisHexIsOn = false;
            }
            else if (spriteRenderer.color == MapMakerScript.yellow && !current.activeSelf){
                current.SetActive(true);
                hexScript.thisHexIsOn = true;
            }  
        }
    }
    void WinLevelHandler(){
        if (MapMakerScript.Instance.amountKeysLeft == 0){ //If all key hexes are collected
            DestroyAllHexes();
            LevelManagerScript.Instance.currentLevel++;
            LevelManagerScript.Instance.setLevel(LevelManagerScript.Instance.currentLevel);
        }
        
    }

}
