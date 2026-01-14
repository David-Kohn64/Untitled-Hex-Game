using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHexScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public SpriteRenderer miniTile;

    void Start()
    {
        miniTile.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        miniTile.enabled = false;
    }
    void OnMouseEnter()
    {
        miniTile.enabled = true;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            TrySpawnHex();
        }
        if (Input.GetMouseButton(1))
        {
            RemoveHex();
        }
    }
    void OnMouseExit()
    {
        miniTile.enabled = false;
    }
    void OnMouseDown()
    {
        TrySpawnHex();
    }
    void TrySpawnHex()
    {
        if (HexManagerScript.Instance.allHexes.ContainsKey(MapMakerScript.Instance.ToSimpleCoords(transform.position)))
        {
            RemoveHex();
        }
        if (EditorManagerScript.Instance.isYellowOff == true) 
        {
            MapMakerScript.Instance.isHexOn = false;
        }
        MapMakerScript.Instance.CreateHex(transform.position, EditorManagerScript.Instance.color);
    }
    void RemoveHex()
    {
        (int x, int y) coords = MapMakerScript.Instance.ToSimpleCoords(transform.position);
        if (HexManagerScript.Instance.allHexes.ContainsKey(coords))
            {
                Destroy(HexManagerScript.Instance.allHexes[coords]);
                HexManagerScript.Instance.allHexes.Remove(coords);
            }
        if (HexManagerScript.Instance.onOffHexes.ContainsKey(coords))
            {
                Destroy(HexManagerScript.Instance.onOffHexes[coords]);
                HexManagerScript.Instance.onOffHexes.Remove(coords);
            }
    }
}
