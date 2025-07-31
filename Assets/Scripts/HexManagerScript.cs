using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexManagerScript : MonoBehaviour
{
    public static HexManagerScript Instance { get; private set; }
    public Dictionary<(int x, int y), GameObject> allHexes = new Dictionary<(int x, int y), GameObject>(); //assigns every hex to its coordinates
    public Dictionary<(int x, int y), GameObject> onOffHexes = new Dictionary<(int x, int y), GameObject>(); //dotted On/Off hex objects
    public Dictionary<(int x, int y), GameObject> growthHexes = new Dictionary<(int x, int y), GameObject>(); //temporary growth tiles
    (int x, int y)[] neighborOffsets = { (-1, -1), (-1, 1), (0, -2), (0, 2), (1, -1), (1, 1)};
    public (int x, int y) currHex;
    public Color currHexColor;
    public (int x, int y) prevHex;
    public Color prevHexColor;
    public (int x, int y) hoverHex;
    public Color hoverHexColor;
    public (int x, int y) clickedHex;
    public Color clickedHexColor;
    public GameObject delayedActivateHex = null;

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
    public void DestroyAllHexes()
    { //probably wipe variables too? (currHex etc.)
        foreach (var hex in allHexes)
        {
            Destroy(hex.Value);
        }
        allHexes.Clear();

        foreach (var hex in onOffHexes)
        {
            Destroy(hex.Value);
        }
        onOffHexes.Clear();

        //foreach (var hex in growthHexes)
        //{
        //    Destroy(hex.Value);
        //}
        //growthHexes.Clear();
        
    }
    public void ProcessPassiveStep()
    { //Lingering effects of tiles previously activated
        ChainCollapseHandler();
        OnOffButtonHandler();
        DegrowthHandler();
    }
    public void ProcessActiveStep(GameObject hex, Color color)
    { //Effects of tiles currently pressed on
        if (color.Equals(MapMakerScript.green))
        {
            KeyHexCollectHandler(hex);
        }
        if (color.Equals(MapMakerScript.orange))
        {
            EchoHandler(hex);
        }
        if (color.Equals(MapMakerScript.pink))
        {
            TravelOnOffHandler();
        }
        if (color.Equals(MapMakerScript.red))
        {
            GrowthHandler(hex);
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

    
    void KeyHexCollectHandler(GameObject hex){
        SpriteRenderer spriteRenderer = hex.GetComponent<SpriteRenderer>(); 
        spriteRenderer.color = Color.white;
        currHexColor = Color.white;
        MapMakerScript.Instance.amountKeysLeft--;
        if (MapMakerScript.Instance.amountKeysLeft == 0){ //If all key hexes are collected
            WinLevelHandler();
        }
    }
    public bool onOnOff = false;
    void OnOffButtonHandler(){
        if (currHexColor != MapMakerScript.yellow && currHexColor != MapMakerScript.orange && onOnOff == true)
        {
            onOnOff = false;
            foreach (var hex in allHexes)
            {
                GameObject current = hex.Value;
                SpriteRenderer spriteRenderer = current.GetComponent<SpriteRenderer>();
                HexScript hexScript = current.GetComponent<HexScript>();

                if (spriteRenderer.color == MapMakerScript.yellow && current.activeSelf)
                {
                    current.SetActive(false);
                    hexScript.thisHexIsOn = false;
                }
                else if (spriteRenderer.color == MapMakerScript.yellow && !current.activeSelf)
                {
                    current.SetActive(true);
                    hexScript.thisHexIsOn = true;
                }
            }
        }
    }
    void EchoHandler(GameObject hex)
    {
        SpriteRenderer spriteRenderer = hex.GetComponent<SpriteRenderer>();
        spriteRenderer.color = prevHexColor;
        currHexColor = spriteRenderer.color;

        if (spriteRenderer.color == MapMakerScript.blue)
        {
            HexScript hexScript = hex.GetComponent<HexScript>();
            hexScript.ccfalling = true;
        }
        if (spriteRenderer.color == MapMakerScript.yellow || spriteRenderer.color == MapMakerScript.pink)
        {
            MapMakerScript.Instance.CreateHexOff(hex.transform.position.x, hex.transform.position.y, spriteRenderer.color);
        }
    }
    public bool growthOn = false;
    void DegrowthHandler()
    {
        if (currHexColor != MapMakerScript.red && growthOn == true)
        {
            growthOn = false;
            foreach (var hex in growthHexes)
            {
                Destroy(hex.Value);
            }
            growthHexes.Clear();
        }
    }
    void GrowthHandler(GameObject hex)
    {
        if (growthOn == true) { return; }

        (int x, int y) curr = (MapMakerScript.Instance.ToReadablePosition(hex.transform.position.x, "x"), MapMakerScript.Instance.ToReadablePosition(hex.transform.position.y, "y"));

        Grow((curr.x, curr.y - 2));
        Grow((curr.x, curr.y + 2));
        Grow((curr.x - 1, curr.y - 1));
        Grow((curr.x + 1, curr.y - 1));
        Grow((curr.x - 1, curr.y + 1));
        Grow((curr.x + 1, curr.y + 1));
    }
    void Grow((int x, int y) curr)
    {
        GameObject nextCurr;
        if ((!allHexes.ContainsKey(curr) && !growthHexes.ContainsKey(curr) ) || onOffHexes.ContainsKey(curr) && !allHexes[curr].activeInHierarchy && !growthHexes.ContainsKey(curr))
        {
            if (CheckInBounds(curr))
            {
                nextCurr = MapMakerScript.Instance.CreateNewHex(curr, MapMakerScript.red);
                growthHexes.Add(curr, nextCurr);
                GrowthHandler(nextCurr);
            }
        }
    }
    bool CheckInBounds((int x, int y) nextCurr)
    {
        if (nextCurr.x < 0 || nextCurr.y < 0) { return false; }
        if (Mathf.Abs(3 - nextCurr.x) > MapMakerScript.Instance.currMapComplexity) { return false; }
        if (Mathf.Abs(6 - nextCurr.y) > MapMakerScript.Instance.currMapComplexity * 2) { return false; }
        if (Mathf.Abs(9 - (nextCurr.x + nextCurr.y)) > MapMakerScript.Instance.currMapComplexity * 2) { return false; }
        if (Mathf.Abs(3 - nextCurr.x) + Mathf.Abs(6 - nextCurr.y) > MapMakerScript.Instance.currMapComplexity * 2) { return false; }
        return true;
    }

    private (int x, int y) onPink = (0, 0);
    private (int x, int y) offPink = (0,0);
    private Stack<(int x, int y)> pinkTilesOn = new Stack<(int x, int y)>();
    private Stack<(int x, int y)> pinkTilesOff = new Stack<(int x, int y)>();
    void TravelOnOffHandler(){
        if (onPink == (0,0)){
            foreach (var hex in allHexes){
                GameObject current = hex.Value;
                SpriteRenderer spriteRenderer = current.GetComponent<SpriteRenderer>();
                HexScript hexScript = current.GetComponent<HexScript>();

                if (spriteRenderer.color == MapMakerScript.pink){
                    if (current.activeSelf){ //Finds onPink and adds it to pinkTilesOn stack
                        onPink = hex.Key;
                        pinkTilesOn.Push(hex.Key);
                    }
                   else{  //otherwise puts an offPink into pinkTileOff stack
                        pinkTilesOff.Push(hex.Key);
                   } 
                }
            }
        }
        if (pinkTilesOff.Count == 0) {
            int n = pinkTilesOn.Count - 1;
            for (int i = 0; i < n; i++){
                pinkTilesOff.Push(pinkTilesOn.Pop());
            }
            offPink = pinkTilesOn.Peek();
        }
        else {
            offPink = pinkTilesOff.Pop();
            pinkTilesOn.Push(offPink);
        }
        GameObject currentOn = allHexes[onPink];
        HexScript hexScriptOn = currentOn.GetComponent<HexScript>();
        currentOn.SetActive(false);
        GameObject currentOff = allHexes[offPink];
        HexScript hexScriptOff = currentOff.GetComponent<HexScript>();
        currentOff.SetActive(true);
        onPink = offPink;

        PlayerScript.Instance.Move(currentOff.transform.position.x, currentOff.transform.position.y);
    }
    
    public bool won = false;
    void WinLevelHandler(){
        won = true;
        DestroyAllHexes();
        PlayerScript.Instance.playerFacing = 0;
        LevelManagerScript.Instance.currentLevel++;
        LevelManagerScript.Instance.SetLevel(LevelManagerScript.Instance.currentLevel);
    }

}
