using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexScript : MonoBehaviour
{
    public (int x, int y) coordinates;
    private bool mouseIsOn; 
    private float hoverTime = 0f;
    private Vector3 originalScale;
    private SpriteRenderer spriteRenderer;
    public bool thisHexIsOn = true;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    public void ColorizeHex(Color color) 
    {
        spriteRenderer.color = color;
    }

    void Start()
    {
        originalScale = transform.localScale;
        if (CheckIfPlayerOn())
        {
            HexManagerScript.Instance.currHex = (MapMakerScript.Instance.ToReadablePosition(transform.position.x, "x"), MapMakerScript.Instance.ToReadablePosition(transform.position.y, "y"));
            HexManagerScript.Instance.currHexColor = spriteRenderer.color;
            Activate();
        }

    }

    void Update()
    {

        if(mouseIsOn ){
            hoverTime += Time.deltaTime * 2f;
            float scaleModifier = 1.0714f + Mathf.Abs(Mathf.Sin(270+hoverTime) /14f);
            transform.localScale = originalScale * scaleModifier;
       }

    }

    private float zPos; 
    private int hexRelationForPlayerFacing;
    private void OnMouseEnter()
    {
        HexManagerScript.Instance.hoverHex = coordinates; 
        HexManagerScript.Instance.hoverHexColor = spriteRenderer.color;
        if (CheckIfClickable()){
            PlayerScript.Instance.playerFacing = GetPlayerFaceDirection(); //for ship facing/rotation, hexes labeled 1-6 counter-clockwise
            zPos = transform.position.z; //Only needs to be called once but I put it here for organization but technically not optimal
            Vector3 newZ = transform.position;
            newZ.z = -2f;
            transform.position = newZ;

            mouseIsOn = true;
        }
    }
    private void OnMouseExit()
    {
        if (mouseIsOn){
            transform.localScale = originalScale;

            Vector3 oldZ = transform.position;
            oldZ.z = zPos;
            transform.position = oldZ;
            hoverTime = 0f;
            
            mouseIsOn = false;
        }
    }
    private void OnMouseDown()
    {
        if (CheckIfClickable()){
            PlayerScript.Instance.playerFacing = GetPlayerFaceDirection();
            HexManagerScript.Instance.prevHex = HexManagerScript.Instance.currHex;
            HexManagerScript.Instance.prevHexColor = HexManagerScript.Instance.currHexColor;
            HexManagerScript.Instance.clickedHex = coordinates;
            HexManagerScript.Instance.clickedHexColor = spriteRenderer.color;
            SendToMove();
            HexManagerScript.Instance.ProcessPassiveStep();
            if (HexManagerScript.Instance.delayedActivateHex != null) { //if there is a stored activate from a landing (final) tile after launch
                HexManagerScript.Instance.delayedActivateHex.GetComponent<HexScript>().Activate();
                HexManagerScript.Instance.delayedActivateHex = null;
            }
            Activate();
            CheckIfLost();
            transform.localScale = originalScale;
            mouseIsOn = false;
        }
    }
    public bool ccfalling = false;
    public void Activate()
    {
        if (spriteRenderer.color == MapMakerScript.blue)
        {
            ccfalling = true;
        }
        if (spriteRenderer.color == MapMakerScript.green)
        {
            HexManagerScript.Instance.ProcessActiveStep(gameObject, MapMakerScript.green);
        }
        if (spriteRenderer.color == MapMakerScript.yellow)
        {
            HexManagerScript.Instance.onOnOff = true;
        }
        if (spriteRenderer.color == MapMakerScript.orange)
        {
            HexManagerScript.Instance.ProcessActiveStep(gameObject, MapMakerScript.orange);
        }
        if (spriteRenderer.color == MapMakerScript.pink)
        {
            HexManagerScript.Instance.ProcessActiveStep(gameObject, MapMakerScript.pink);
        }
        if (spriteRenderer.color == MapMakerScript.red)
        {
            HexManagerScript.Instance.ProcessActiveStep(gameObject, MapMakerScript.red);
        }

    }    
    private bool CheckIfClickable(){
        if (CheckIfAdjacentHexToPlayer()){
            return true;
        }

        if (CheckIfLaunchPad()){
            return true;
        }
        return false;
    }
    private bool CheckIfAdjacentHexToPlayer(){
        if (Mathf.Abs(transform.position.x - PlayerScript.Instance.transform.position.x) < MapMakerScript.xUnit + 0.1f && Mathf.Abs(transform.position.y - PlayerScript.Instance.transform.position.y) < 2* MapMakerScript.yUnit + 0.1f)
            {
                return !CheckIfPlayerOn();
            }
        return false;
    }
    private bool CheckIfPlayerOn(){
        return Mathf.Abs(transform.position.x - PlayerScript.Instance.transform.position.x) < 0.001 && Mathf.Abs(transform.position.y - PlayerScript.Instance.transform.position.y) < 0.001;
    }
    private (int x, int y) unit;
    private (int x, int y) candidatePad;
    private (int x, int y) candidateHex;
    private bool CheckIfLaunchPad(){
        if (HexManagerScript.Instance.currHexColor == MapMakerScript.purple && spriteRenderer.color == MapMakerScript.purple){
            GetUnit(); 
            candidatePad = HexManagerScript.Instance.currHex;
            for (int i = 0; i <= 2 * MapMakerScript.Instance.mapComplexity + 1; i++){
                candidatePad.x += unit.x;
                candidatePad.y += unit.y;
                if (!HexManagerScript.Instance.allHexes.ContainsKey(candidatePad)){
                    continue;
                }
                if (candidatePad == HexManagerScript.Instance.hoverHex){
                    return !CheckIfPlayerOn();
                }
            }
        }
        return false;
    }
    private void SendToMove(){
        if (HexManagerScript.Instance.clickedHexColor == MapMakerScript.purple && HexManagerScript.Instance.currHexColor == MapMakerScript.purple){
            GetUnit();
            candidateHex = HexManagerScript.Instance.currHex;
            int safety = 50;
            while (candidateHex != HexManagerScript.Instance.clickedHex && safety > 0)
            {
                candidateHex.x += unit.x;
                candidateHex.y += unit.y;
                if (HexManagerScript.Instance.allHexes.ContainsKey(candidateHex) && HexManagerScript.Instance.allHexes[candidateHex].activeInHierarchy && !HexManagerScript.Instance.allHexes[candidateHex].GetComponent<HexScript>().ccfalling)
                {

                    HexManagerScript.Instance.currHex = candidateHex;

                    GameObject finalHex = HexManagerScript.Instance.allHexes[candidateHex];
                    HexScript finalHexScript = finalHex.GetComponent<HexScript>();
                    SpriteRenderer spriteRenderer = finalHex.GetComponent<SpriteRenderer>();
                    HexManagerScript.Instance.currHexColor = spriteRenderer.color;

                    HexManagerScript.Instance.delayedActivateHex = finalHex;

                    PlayerScript.Instance.Move((candidateHex.x - MapMakerScript.Instance.mapComplexity) * MapMakerScript.xUnit, ((MapMakerScript.Instance.mapComplexity * 2) - candidateHex.y) * MapMakerScript.yUnit);
                    return;
                }
                safety--;
            }
        }
        else{ //when not purple
            HexManagerScript.Instance.currHex = HexManagerScript.Instance.clickedHex;
            HexManagerScript.Instance.currHexColor = HexManagerScript.Instance.clickedHexColor;
            PlayerScript.Instance.Move(transform.position.x, transform.position.y);
        }
    }
    public void GetUnit(){
        if (CheckIfPlayerOn()){
            unit = (0,0);
            return;
        }
        if (HexManagerScript.Instance.currHex.x == coordinates.x){
                unit = HexManagerScript.Instance.currHex.y > coordinates.y ? (0,-2) : (0,2);
                return;
            }
        unit = (1,1);
        if (HexManagerScript.Instance.currHex.x > coordinates.x){
            unit.x *= -1;
            }
        if (HexManagerScript.Instance.currHex.y  > coordinates.y){
            unit.y *= -1;
            }
        return;
    }
    public void CheckIfLost(){
        if (HexManagerScript.Instance.won)
        {
            HexManagerScript.Instance.won = false;
            return;
        }
        if(!HexManagerScript.Instance.allHexes.ContainsKey(HexManagerScript.Instance.currHex))
        {
            PlayerScript.Instance.Fell();
        }
        
    }
    public int GetPlayerFaceDirection(){
        if (Mathf.Abs(PlayerScript.Instance.transform.position.x - transform.position.x) < 0.1f){
            return PlayerScript.Instance.transform.position.y - transform.position.y < 0.1f ? 0 : 180;
        }
        else if (PlayerScript.Instance.transform.position.x - transform.position.x < 0.1f){
            return PlayerScript.Instance.transform.position.y - transform.position.y < 0.1f ? 300 : 240;
        }
        else {
            return PlayerScript.Instance.transform.position.y - transform.position.y < 0.1f ? 60 : 120;
        }
        
    }
}
