using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript Instance { get; private set; }

    public TMP_Text levelName;
    private int currentLevel; //Some level save when restart button resets everything else

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = LevelManagerScript.Instance.currentLevel;
        levelName.text = "Level " + LevelManagerScript.Instance.currentLevel;
        if (LevelManagerScript.Instance.currentLevel == 20) { levelName.text = "Infinite"; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>
        {
            LevelManagerScript.Instance.SetLevel(currentLevel);
        };
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

}
