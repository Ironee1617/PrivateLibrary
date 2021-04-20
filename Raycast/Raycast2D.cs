using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{
    public enum LayerMaskType
    {
        None,
        SpecificLayer,
        ExcludeSpecificLayer
    }

    public LayerMaskType layerMaskType;
    public int layerNum;
    public GameObject touchedGameObject;

    private int layerMask;

    void Start()
    {
        InitLayerType();
    }

    private void InitLayerType()
    {
        switch(layerMaskType)
        {
            case LayerMaskType.None:
                break;
            case LayerMaskType.SpecificLayer:
                if(layerNum.Equals(0)) { Debug.LogError("Layer is default"); }
                layerMask = 1 << layerNum;
                break;
            case LayerMaskType.ExcludeSpecificLayer:
                if (layerNum.Equals(0)) { Debug.LogError("Layer is default"); }
                layerMask = 1 << layerNum;
                layerMask = ~layerMask;
                break;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 t_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(t_Pos, transform.forward, Mathf.Infinity, layerMask);
            Debug.DrawRay(t_Pos, transform.forward, Color.red, 0.3f);
            if (hit)
            {
                touchedGameObject = hit.transform.gameObject;
            }
        }
    }
}
