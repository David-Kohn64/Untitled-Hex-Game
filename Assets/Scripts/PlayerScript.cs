using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   public static PlayerScript Instance { get; private set; }

   public int playerFacing = 0;

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
        transform.rotation = Quaternion.identity;
        transform.Rotate(new Vector3(0, 0, playerFacing));

    }
    private void OnMouseEnter()
    {
        
    }
    private void OnMouseExit()
    {
        
    }
    public void Move(float newX, float newY)
    {
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    public void Move((int x, int y) newXY)
    {
        transform.position = new Vector3(MapMakerScript.Instance.ToUnityPosition(newXY.x, "x"), MapMakerScript.Instance.ToUnityPosition(newXY.y, "y"), transform.position.z);
    }
    public void Fell()
    {
        transform.position = new Vector3(-20, 0, transform.position.z); //Go far away instead of destroying
        Debug.Log("FELL");
    }

}