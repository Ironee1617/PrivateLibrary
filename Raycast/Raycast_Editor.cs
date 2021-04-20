using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Raycast2D))]
public class Raycast_Editor : Editor
{
    Raycast2D rayCast = null;

    void OnEnable()
    {
        rayCast = (Raycast2D)target;
    }
    public override void OnInspectorGUI()
    {
        rayCast.layerMaskType = (Raycast2D.LayerMaskType)EditorGUILayout.EnumPopup("Type", rayCast.layerMaskType);
        switch(rayCast.layerMaskType)
        {
            case Raycast2D.LayerMaskType.SpecificLayer:
                rayCast.layerNum = EditorGUILayout.IntField("Layer Number", rayCast.layerNum);
                break;
            case Raycast2D.LayerMaskType.ExcludeSpecificLayer:
                rayCast.layerNum = EditorGUILayout.IntField("Layer Number", rayCast.layerNum);
                break;
        }
        EditorGUILayout.Space();

        EditorGUILayout.ObjectField("Touched GameObject", rayCast.touchedGameObject, typeof(GameObject), true);
    }
}