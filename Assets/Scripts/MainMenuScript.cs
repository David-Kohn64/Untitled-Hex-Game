using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript Instance {get; private set;}

    private Transform targetPosition;
    public Transform targetReset;
    public Transform targetAbout;
    public float fixedZPos = -10;
    public float panSpeed = 5f;
    private bool isPanning = false; 


    public GameObject buttonEmbark;
    public GameObject buttonOptions;
    public GameObject buttonAbout;
    public GameObject buttonExit;
    public GameObject panelsAbout;

    void Start()
    {
        panelsAbout.SetActive(false); 
    }
    void Update()
    {
        if (isPanning)
        {
            Vector3 target = new Vector3(targetPosition.position.x, targetPosition.position.y, fixedZPos);
            transform.position = Vector3.Lerp(transform.position, target, panSpeed * Time.deltaTime); // Smooth movement
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f) // Stops panning when close to the target
            {
                transform.position = targetPosition.position;
                isPanning = false;
            }
        }
    }
    private bool atAbout = false;
    public TMP_Text textAbout;
    public void PanAbout()
    {
        if (!atAbout){
        targetPosition = targetAbout;
        textAbout.text = "Back";
        panelsAbout.SetActive(true);
        buttonEmbark.SetActive(false);
        buttonOptions.SetActive(false);
        buttonExit.SetActive(false);
        atAbout = true;
        }
        else {
        targetPosition = targetReset;
        textAbout.text = "About";
        panelsAbout.SetActive(false);
        buttonEmbark.SetActive(true);
        buttonOptions.SetActive(true);
        buttonExit.SetActive(true);
        atAbout = false;
        }
        isPanning = true;
    }
}
