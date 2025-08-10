using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance { get; private set; }

    public int playerFacing = 0;
    [SerializeField] private Transform spriteTransform;
    private (int x, int y) nextHex;
    private void Awake()
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
        spriteTransform.localRotation = Quaternion.identity;
        spriteTransform.localRotation = Quaternion.Euler(0, 0, playerFacing);

        if (HexManagerScript.Instance.allHexes.ContainsKey(HexManagerScript.Instance.currHex) && HexManagerScript.Instance.allHexes[HexManagerScript.Instance.currHex].GetComponent<HexScript>().ccfalling)
        {
            GetComponentInChildren<Animator>().Play("ShakeLess");
        }

        nextHex = HexManagerScript.Instance.currHex;
        string switchKey = "none";

        if (Input.GetKeyDown(KeyCode.W)) { switchKey = "up"; }
        else if (Input.GetKeyDown(KeyCode.S)) { switchKey = "down"; }
        else if (Input.GetKeyDown(KeyCode.Q)) { switchKey = "upLeft"; }
        else if (Input.GetKeyDown(KeyCode.A)) { switchKey = "downLeft"; }
        else if (Input.GetKeyDown(KeyCode.E)) { switchKey = "upRight"; }
        else if (Input.GetKeyDown(KeyCode.D)) { switchKey = "downRight"; }
        // else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) { switchKey = "upLeft";}
        // else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) { switchKey = "downLeft";}
        // else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) { switchKey = "upRight";}
        // else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) { switchKey = "downRight";}


        if (switchKey != "none")
        {
            NextHexViaKeyPress(switchKey);
        }
        if (HexManagerScript.Instance.growthHexes.ContainsKey(nextHex))
        {
            HexScript hexScript = HexManagerScript.Instance.growthHexes[nextHex].GetComponent<HexScript>();
            hexScript.OnMouseDown();
        }
        if (HexManagerScript.Instance.allHexes.ContainsKey(nextHex) && HexManagerScript.Instance.allHexes[nextHex].GetComponent<HexScript>().thisHexIsOn)
        {
            HexScript hexScript = HexManagerScript.Instance.allHexes[nextHex].GetComponent<HexScript>();
            hexScript.OnMouseDown();
        }
        else
        {
            if (HexManagerScript.Instance.currHexColor == MapMakerScript.purple)
            {
                int safety = 8;
                while ((!HexManagerScript.Instance.allHexes.ContainsKey(nextHex) || (HexManagerScript.Instance.allHexes.ContainsKey(nextHex) && HexManagerScript.Instance.allHexes[nextHex].GetComponent<HexScript>().spriteRenderer.color != MapMakerScript.purple)) && safety > 0)
                {
                    NextHexViaKeyPress(switchKey);
                    safety--;
                }
                if (safety > 0)
                {
                    HexScript hexScript = HexManagerScript.Instance.allHexes[nextHex].GetComponent<HexScript>();
                    hexScript.OnMouseDown();
                }
            }
        }
    }
    public void NextHexViaKeyPress(string switchKey)
    {
        switch (switchKey)
            {
                case "up":
                    nextHex.y -= 2;
                    break;
                case "down":
                    nextHex.y += 2;
                    break;
                case "upLeft":
                    nextHex.x -= 1;
                    nextHex.y -= 1;
                    break;
                case "downLeft":
                    nextHex.x -= 1;
                    nextHex.y += 1;
                    break;
                case "upRight":
                    nextHex.x += 1;
                    nextHex.y -= 1;
                    break;
                case "downRight":
                    nextHex.x += 1;
                    nextHex.y += 1;
                    break;
            }
    }
    private void OnMouseEnter()
    {

    }
    private void OnMouseExit()
    {

    }
    public void Move(float newX, float newY)
    {
        GetComponentInChildren<Animator>().Play("Idle");
        //StopAllCoroutines();

        Vector3 targetPos = new Vector3(newX, newY, transform.position.z);
        transform.position = targetPos;
        //StartCoroutine(MoveSmooth(targetPos));
    }
    public void Move((int x, int y) newXY)
    {
        GetComponentInChildren<Animator>().Play("Idle");
        //StopAllCoroutines();

        Vector3 targetPos = new Vector3(MapMakerScript.Instance.ToUnityPosition(newXY.x, "x"), MapMakerScript.Instance.ToUnityPosition(newXY.y, "y"), transform.position.z);
        transform.position = targetPos;
        //StartCoroutine(MoveSmooth(targetPos));
    }
    private IEnumerator MoveSmooth(Vector3 targetPos)
    {
        float speed = 10f; 
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
    }
    public void Fell()
    {
        transform.position = new Vector3(-20, 0, transform.position.z); //Go far away instead of destroying
        Debug.Log("FELL");
    }
    

}