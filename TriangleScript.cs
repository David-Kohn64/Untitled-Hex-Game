using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleScript : MonoBehaviour
{
   public static TriangleScript Instance { get; private set; }

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
        
    }
    private void OnMouseEnter()
    {
        
    }
    private void OnMouseExit()
    {
        
    }
    public void Move(Vector3 newHex) 
    {
        transform.position = newHex;
    }

}