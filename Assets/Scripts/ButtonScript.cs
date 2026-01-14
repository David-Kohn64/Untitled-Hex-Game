using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private float zPos; 
    private bool mouseIsOn; 
    public float radius = 232f; 
    private float hoverTime = 0f;
    private Vector3 originalScale;
    private RectTransform rectTransform; 
    public enum ButtonType { Embark, Levels, Infinite, Editor, Options, About, Exit,  
        Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, Level10, Level11, Level12, Level13, 
        Level14, Level15, Level16, Level17, Level18, Level19, Level20, Level21, EditorWhite, EditorGreen, EditorBlue, EditorPurple,
        EditorYellowOn, EditorYellowOff, EditorOrange, EditorRed, SaveAndLeave, ToPlayspace, 
        Editor1, Editor2, Editor3, Editor4, Editor5, Editor6, Editor7, Editor8, Editor9, NotAButton }
    public ButtonType buttonType;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale; 
    }
    void Update()
    {
        Vector2 localMousePosition = GetLocalMousePosition();

        // Check if the mouse is inside the custom circular hitbox
        bool isInsideHitbox = localMousePosition.magnitude <= radius;

        if (isInsideHitbox)
        {
            OnCustomPointerEnter();
        }
        else if (!isInsideHitbox)
        {
            OnCustomPointerExit();
        }

        if (isInsideHitbox && Input.GetMouseButtonDown(0))
        {
            OnCustomPointerClick();
        }
        if(mouseIsOn){
            hoverTime += Time.deltaTime * 2f;
            float scaleModifier = 1.0714f + Mathf.Abs(Mathf.Sin(270+hoverTime) /14f);
            rectTransform.localScale = originalScale * scaleModifier;
        }

    }
    Vector2 GetLocalMousePosition()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, 
            Input.mousePosition, 
            Camera.main,
            out Vector2 localMousePosition
        );
        return localMousePosition;
    }
    void OnCustomPointerEnter(){
            zPos = rectTransform.position.z; //Only needs to be called once but I put it here for organization but technically not optimal
            Vector3 newZ = rectTransform.position;
            newZ.z = -2f;
            rectTransform.position = newZ;

            mouseIsOn = true;
    }
    void OnCustomPointerExit(){
            if (mouseIsOn){
            rectTransform.localScale = originalScale;

            Vector3 oldZ = rectTransform.position;
            oldZ.z = zPos;
            rectTransform.position = oldZ;
            hoverTime = 0f;
            
            mouseIsOn = false;
            }
    }
    void OnCustomPointerClick(){
        switch (buttonType)
        {
            case ButtonType.Embark:
                MainMenuScript.Instance.PanEmbark();
                break;
            case ButtonType.Levels:
                SceneManager.LoadSceneAsync("LevelSelect");
                break;
            case ButtonType.Infinite:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                MapMakerScript.Instance.SetLevel(20); };
                break;
            case ButtonType.Editor:
                SceneManager.LoadSceneAsync("LevelEditor");
                break;
            case ButtonType.Options:
                MainMenuScript.Instance.PanOptions();
                break;
            case ButtonType.About:
                MainMenuScript.Instance.PanAbout();
                break;
            case ButtonType.Exit:
                Application.Quit();
                break;
            case ButtonType.Level1:
            case ButtonType.Level2:
            case ButtonType.Level3:
            case ButtonType.Level4:
            case ButtonType.Level5:
            case ButtonType.Level6:
            case ButtonType.Level7:
            case ButtonType.Level8:
            case ButtonType.Level9:
            case ButtonType.Level10:
            case ButtonType.Level11:
            case ButtonType.Level12:
            case ButtonType.Level13:
            case ButtonType.Level14:
            case ButtonType.Level15:
            case ButtonType.Level16:
            case ButtonType.Level17:
            case ButtonType.Level18:
            case ButtonType.Level19:
            case ButtonType.Level20:
            case ButtonType.Level21:
                string levelNumber = buttonType.ToString();
                int.TryParse(levelNumber.Replace("Level", ""), out int levelNum);
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                MapMakerScript.Instance.SetLevel(levelNum); };
                break;
            case ButtonType.EditorWhite:
                EditorManagerScript.Instance.color = Color.white;
                break;
            case ButtonType.EditorGreen:
                EditorManagerScript.Instance.color = MapMakerScript.green;
                break;
            case ButtonType.EditorBlue:
                EditorManagerScript.Instance.color = MapMakerScript.blue;
                break;
            case ButtonType.EditorPurple:
                EditorManagerScript.Instance.color = MapMakerScript.purple;
                break;
            case ButtonType.EditorYellowOn:
                EditorManagerScript.Instance.color = MapMakerScript.yellow;
                EditorManagerScript.Instance.isYellowOff = false;
                break;
            case ButtonType.EditorYellowOff:
                EditorManagerScript.Instance.color = MapMakerScript.yellow;
                EditorManagerScript.Instance.isYellowOff = true;
                break;
            case ButtonType.EditorOrange:
                EditorManagerScript.Instance.color = MapMakerScript.orange;
                break;
            case ButtonType.EditorRed:
                EditorManagerScript.Instance.color = MapMakerScript.red;
                break;
            case ButtonType.SaveAndLeave: //Rework later
                EditorManagerScript.Instance.SaveEditorState();
                SceneManager.LoadSceneAsync("Main Menu");
                break;
            case ButtonType.ToPlayspace:
                EditorManagerScript.Instance.makerMode = false;
                EditorManagerScript.Instance.PlayLevel(); 
                break;
            case ButtonType.Editor1:
            case ButtonType.Editor2:
            case ButtonType.Editor3:
            case ButtonType.Editor4:
            case ButtonType.Editor5:
            case ButtonType.Editor6:
            case ButtonType.Editor7:
            case ButtonType.Editor8:
            case ButtonType.Editor9:
                string editorLevelNumber = buttonType.ToString();
                int.TryParse(editorLevelNumber.Replace("Editor", ""), out int editorLevelNum);
                EditorManagerScript.Instance.currEditorState = LevelData.Instance.editorLevelcodes[editorLevelNum - 1];
                EditorManagerScript.Instance.makerMode = true;
                EditorManagerScript.Instance.MakeLevel();
                break;
            case ButtonType.NotAButton:
                break;
            default:
                break;
        }
    }
}
