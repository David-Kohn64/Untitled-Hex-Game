using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance {get; private set;}

    public TMP_Text levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelName.text = "Level " + LevelManagerScript.Instance.currentLevel;
    }

}
