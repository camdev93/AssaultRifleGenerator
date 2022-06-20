using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DynamicMeshGenerator))]
public class DynamicMeshGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DynamicMeshGenerator generator = (DynamicMeshGenerator)target;

        if (GUILayout.Button("Generate New Gun"))
        {
            for (int i = 0; i < generator.gameObject.transform.childCount; i++)
            {
                DestroyImmediate(generator.gameObject.transform.GetChild(i).gameObject);
            }

            generator.GenerateMesh();
        }
    }
}
