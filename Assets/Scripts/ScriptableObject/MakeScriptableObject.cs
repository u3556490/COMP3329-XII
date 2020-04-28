using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeScriptableObject
{
    [MenuItem("Assets/Create/VectorValue")]
    public static void CreateMyAsset()
    {
        VectorValue asset = ScriptableObject.CreateInstance<VectorValue>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/ScriptableObject/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
