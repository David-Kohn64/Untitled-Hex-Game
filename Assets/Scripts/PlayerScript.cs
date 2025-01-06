using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   public static PlayerScript Instance { get; private set; }

   public int playerFacing = 1;

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
        switch (playerFacing){
            case 1:
                transform.rotation = Quaternion.identity;
                break;
            case 2:
                transform.rotation = Quaternion.identity;
                transform.Rotate(new Vector3(0, 0, 60));
                break;
            case 3:
                transform.rotation = Quaternion.identity;
                transform.Rotate(new Vector3(0, 0, 120));
                break;
            case 4:
                transform.rotation = Quaternion.identity;
                transform.Rotate(new Vector3(0, 0, 180));
                break;
            case 5:
                transform.rotation = Quaternion.identity;
                transform.Rotate(new Vector3(0, 0, 240));
                break;
            case 6:
                transform.rotation = Quaternion.identity;
                transform.Rotate(new Vector3(0, 0, 300));
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
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

}