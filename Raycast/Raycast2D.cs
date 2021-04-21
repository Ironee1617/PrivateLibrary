using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D<T> : MonoBehaviour
{
    public enum LayerMaskType
    {
        None,
        SpecificLayer,
        ExcludeSpecificLayer
    }

    public LayerMaskType layerMaskType;
    public int layerNum;
    public T touchedObject;

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

    public T InputClick()
    {
        Vector2 t_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(t_Pos, transform.forward, Mathf.Infinity, layerMask);
        Debug.DrawRay(t_Pos, transform.forward, Color.red, 0.3f);

        if (hit) return hit.transform.GetComponent<T>();
        else return default(T);
    }
}