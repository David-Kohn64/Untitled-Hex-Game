using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript Instance { get; private set; }

    private Transform targetPosition;
    public Transform targetReset;
    public Transform targetAbout;
    public Transform targetEmbark;
    public Transform targetOptions;
    public float fixedZPos = -10;
    public float panSpeed = 5f;
    private bool isPanning = false;


    public GameObject buttonEmbark;
    public GameObject buttonOptions;
    public GameObject buttonAbout;
    public GameObject buttonExit;
    public GameObject panelsAbout;
    public GameObject panelsEmbark;
    public GameObject panelsOptions;

    void Start()
    {
        panelsAbout.SetActive(false);
        panelsEmbark.SetActive(false);
        panelsOptions.SetActive(false);

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
        //PanBackEmbark();
        //PanBackOptions();
        if (!atAbout)
        {
            targetPosition = targetAbout;
            textAbout.text = "Back";
            panelsAbout.SetActive(true);
            buttonEmbark.SetActive(false);
            buttonOptions.SetActive(false);
            buttonExit.SetActive(false);
            atAbout = true;
        }
        else
        {
            PanBackAbout();
        }
        isPanning = true;
    }
    public void PanBackAbout()
    {
        targetPosition = targetReset;
        textAbout.text = "About";
        panelsAbout.SetActive(false);
        buttonEmbark.SetActive(true);
        buttonOptions.SetActive(true);
        buttonExit.SetActive(true);
        atAbout = false;

        isPanning = true;
    }
    private bool atEmbark = false;
    public TMP_Text textEmbark;
    public void PanEmbark()
    {
        //PanBackAbout();
        //PanBackOptions();
        if (!atEmbark)
        {
            targetPosition = targetEmbark;
            textEmbark.text = "Back";
            buttonEmbark.GetComponent<Image>().color = Color.gray;
            panelsEmbark.SetActive(true);
            buttonAbout.SetActive(false);
            buttonOptions.SetActive(false);
            buttonExit.SetActive(false);
            atEmbark = true;
        }
        else
        {
            PanBackEmbark();
        }
        isPanning = true;
    }

    public void PanBackEmbark()
    {
        targetPosition = targetReset;
        textEmbark.text = "Embark";
        buttonEmbark.GetComponent<Image>().color = MapMakerScript.green;
        panelsEmbark.SetActive(false);
        buttonAbout.SetActive(true);
        buttonOptions.SetActive(true);
        buttonExit.SetActive(true);
        atEmbark = false;

        isPanning = true;
    }

    private bool atOptions = false;
    public TMP_Text textOptions;
    public void PanOptions()
    {
        //PanBackAbout();
        //PanBackEmbark();
        if (!atOptions)
        {
            targetPosition = targetOptions;
            textOptions.text = "Back";
            panelsOptions.SetActive(true);
            buttonAbout.SetActive(false);
            buttonEmbark.SetActive(false);
            buttonExit.SetActive(false);
            atOptions = true;
        }
        else
        {
            PanBackOptions();
        }
        isPanning = true;
    }

    public void PanBackOptions()
    {
        targetPosition = targetReset;
        textOptions.text = "Options";
        panelsOptions.SetActive(false);
        buttonAbout.SetActive(true);
        buttonEmbark.SetActive(true);
        buttonExit.SetActive(true);
        atOptions = false;

        isPanning = true;
    }
}
