using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditorManagerScript : MonoBehaviour
{
    public static EditorManagerScript Instance { get; private set; }

    public string currEditorState;
    public GameObject spacePanel;
    public GameObject workspacePanel;
    public GameObject playspacePanel;
    public GameObject menuPanel;
    public GameObject mapMaker;
    public Color color = Color.white;
    public bool isYellowOff;
    public bool makerMode = true;
    public TMP_InputField levelcodeInput;
    void Awake() 
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (workspacePanel.activeInHierarchy)
        {
            PlayerScript.Instance.Hide(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelcodeInput.text != null)
        {
            LevelData.Instance.editorLevelcodes[0] = levelcodeInput.text;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            SwitchPanels();
        }
    }
    public void SwitchPanels()
    {   
        if (!makerMode) return;

        if (workspacePanel.activeInHierarchy)
        {
            SaveEditorState();
        }
        HexManagerScript.Instance.DestroyAllHexes();
        workspacePanel.SetActive(!workspacePanel.activeInHierarchy);
        playspacePanel.SetActive(workspacePanel.activeInHierarchy);
        MapMakerScript.Instance.undoStack.Clear();
        PlayerScript.Instance.Hide(workspacePanel.activeInHierarchy);
        PlayerScript.Instance.playerFacing = 0;
        MapMakerScript.Instance.MakeMap(LevelData.Instance.editorLevelcodes[MapMakerScript.Instance.currentLevel - 1000]);
        
    }
    public void SaveEditorState()
    {
        currEditorState = MapMakerScript.Instance.Encode();
        LevelData.Instance.editorLevelcodes[MapMakerScript.Instance.currentLevel - 1000] = currEditorState;
        
    }
    public void MakeLevel()
    {
        menuPanel.SetActive(false);
        spacePanel.SetActive(true);
        playspacePanel.SetActive(false);
        workspacePanel.SetActive(true);
        MapMakerScript mm = mapMaker.GetComponent<MapMakerScript>();
            if (mm != null)
            {
                mm.levelcode = currEditorState; 
                mm.SetLevel(MapMakerScript.Instance.currentLevel);
            }
        PlayerScript.Instance.Hide(true);
    }
    public void PlayLevel() //level 1000
    {
        if (IsLevelcodeValid())
        {
            menuPanel.SetActive(false);
            spacePanel.SetActive(true);
            playspacePanel.SetActive(true);
            workspacePanel.SetActive(false);
            MapMakerScript mm = mapMaker.GetComponent<MapMakerScript>();
            if (mm != null)
            {
                //mm.levelcode = LevelData.Instance.editorLevelcodes[0]; 
                mm.SetLevel(1000);
            }
        
        }
        else
        {
            Debug.Log("Invalid Levelcode!");
        }
    }
    public bool IsLevelcodeValid()
    {
        if (LevelData.Instance.editorLevelcodes[0].Length == MapMakerScript.CODE_LENGTH)
        {
            return true;
        }
        return false;
    }

}
