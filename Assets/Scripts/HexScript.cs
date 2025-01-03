using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexScript : MonoBehaviour
{
    private bool mouseIsOn; 
    private float hoverTime = 0f;
    private Vector3 originalScale;
    private SpriteRenderer spriteRenderer; 

    public bool thisHexIsOn = true;
    // public Sprite hexOn;
    // public Sprite hexOff;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        // if (MapMakerScript.Instance.isHexOn == true)
        // {
        //     spriteRenderer.sprite = hexOn;
        // }
        // else
        // {
        //     spriteRenderer.sprite = hexOff;
        //     MapMakerScript.Instance.isHexOn = true;
        // }
    }
    public void ColorizeHex(Color color) 
    {
        spriteRenderer.color = color;
    }

    void Start()
    {
        originalScale = transform.localScale;
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
    private void OnMouseEnter()
    {
        if (checkIfAdjacentHexToPlayer()){
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
        if (checkIfAdjacentHexToPlayer()){
            TriangleScript.Instance.Move(transform.position.x, transform.position.y);
            HexManagerScript.Instance.processPassiveStep();
            activate();
            transform.localScale = originalScale;
            mouseIsOn = false;
        }
    }
    public bool ccfalling = false;
    //bool ccfell = false;
    void activate(){
        if (spriteRenderer.color == MapMakerScript.blue){
            ccfalling = true;
        }
        if (spriteRenderer.color == MapMakerScript.black){
            HexManagerScript.Instance.processActiveStep(gameObject, MapMakerScript.black);
        }
        if (spriteRenderer.color == MapMakerScript.green){
            HexManagerScript.Instance.processActiveStep(gameObject, MapMakerScript.green);
        }
        if (spriteRenderer.color == MapMakerScript.orange){
            HexManagerScript.Instance.processActiveStep(gameObject, MapMakerScript.orange);
        }
    }    
    
    private bool checkIfAdjacentHexToPlayer(){
        if (Mathf.Abs(transform.position.x - TriangleScript.Instance.transform.position.x) < MapMakerScript.xUnit + 0.1f && Mathf.Abs(transform.position.y - TriangleScript.Instance.transform.position.y) < 2* MapMakerScript.yUnit + 0.1f)
            {
                if (!(Mathf.Abs(transform.position.x - TriangleScript.Instance.transform.position.x) < 0.001 && Mathf.Abs(transform.position.y - TriangleScript.Instance.transform.position.y) < 0.001))
                {
                    return true;
                }
            }
        return false;
    }
}
