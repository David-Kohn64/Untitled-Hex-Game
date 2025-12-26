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
        currentLevel = MapMakerScript.Instance.currentLevel;
        levelName.text = "Level " + MapMakerScript.Instance.currentLevel;
        if (MapMakerScript.Instance.currentLevel == 20) { levelName.text = "Infinite"; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartLevel();
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>
        {
            MapMakerScript.Instance.undoStack.Clear();
            MapMakerScript.Instance.SetLevel(currentLevel);
        };
    }
    public void UndoMove()
    {
        if (MapMakerScript.Instance.undoStack.Count > 0)
        {
            string lastState = MapMakerScript.Instance.undoStack.Pop();
            Debug.Log("RETURNING TO: " + lastState);
            HexManagerScript.Instance.DestroyAllHexes();
            MapMakerScript.Instance.MakeMap(lastState);
        }
    }

}
