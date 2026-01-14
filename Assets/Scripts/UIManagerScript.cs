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
    private float undoTimer = 0f; // So you can hold down backspace, but with a delay
    private float undoDelay = .1f;// ^^
    private bool isHoldingUndo = false;
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
        if (MapMakerScript.Instance == null) return;
        currentLevel = MapMakerScript.Instance.currentLevel;
        levelName.text = "Level " + MapMakerScript.Instance.currentLevel;
        if (MapMakerScript.Instance.currentLevel == 20) { levelName.text = "Infinite"; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartLevel();
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            if (!isHoldingUndo)
            {
                UndoMove();
                undoTimer = 0.7f; //delay after first undo
                isHoldingUndo = true;
            }
            else
            {
                undoTimer -= Time.deltaTime;
                if (undoTimer <= 0)
                {
                    UndoMove();
                    undoTimer = undoDelay;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            isHoldingUndo = false;
            undoTimer = 0f;
        }

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void RestartLevel()
    {
        MapMakerScript.Instance.undoStack.Clear();
        HexManagerScript.Instance.DestroyAllHexes();
        MapMakerScript.Instance.SetLevel(currentLevel);
        PlayerScript.Instance.playerFacing = 0;
    }
    public void UndoMove()
    {
        if (MapMakerScript.Instance.undoStack.Count > 0)
        {
            string lastState = MapMakerScript.Instance.undoStack.Pop();
            HexManagerScript.Instance.DestroyAllHexes();
            MapMakerScript.Instance.MakeMap(lastState);
        }
    }

}
