using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public MainMenuScript mainMenuScript;
    private float zPos; 
    private bool mouseIsOn; 
    public float radius = 232f; 
    private float hoverTime = 0f;
    private Vector3 originalScale;
    private RectTransform rectTransform; 
    public enum ButtonType { Embark, Levels, Infinite, Editor, Options, About, Exit, Level1, Level2, Level3, Level4, Level5, 
        Level6, Level7, Level8, Level9, Level10, Level11, Level12, Level13, Level14, Level15, Level16,
        Level17, Level18, Level19, Level20, Level21, NotAButton }
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
                mainMenuScript.PanEmbark();
                break;
            case ButtonType.Levels:
                SceneManager.LoadSceneAsync("LevelSelect");
                break;
            case ButtonType.Infinite:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(20); };
                break;
            case ButtonType.Editor:
                //Level Editor
                break;
            case ButtonType.Options:
                mainMenuScript.PanOptions();
                break;
            case ButtonType.About:
                mainMenuScript.PanAbout();
                break;
            case ButtonType.Exit:
                Application.Quit();
                break;
            case ButtonType.Level1:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(1); };
                break;
            case ButtonType.Level2:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(2); };
                break;
            case ButtonType.Level3:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(3); };
                break;
            case ButtonType.Level4:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(4); };
                break;
            case ButtonType.Level5:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(5); };
                break;
            case ButtonType.Level6:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(6); };
                break;
            case ButtonType.Level7:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(7); };
                break;
            case ButtonType.Level8:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(8); };
                break;
            case ButtonType.Level9:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(9); };
                break;
            case ButtonType.Level10:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(10); };
                break;
            case ButtonType.Level11:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(11); };
                break;
            case ButtonType.Level12:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(12); };
                break;
            case ButtonType.Level13:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(13); };
                break;
            case ButtonType.Level14:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(14); };
                break;
            case ButtonType.Level15:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(15); };
                break;
            case ButtonType.Level16:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(16); };
                break;
            case ButtonType.Level17:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(17); };
                break;
            case ButtonType.Level18:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(18); };
                break;
            case ButtonType.Level19:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(19); };
                break;
            case ButtonType.Level20:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(20); };
                break;
            case ButtonType.Level21:
                SceneManager.LoadSceneAsync("HexScene").completed += (asyncOperation) =>{ 
                LevelManagerScript.Instance.SetLevel(21); };
                break;
            case ButtonType.NotAButton:
                break;
            default:
                break;
        }
    }
    void ButtonDisappear(){

    }
    
}
