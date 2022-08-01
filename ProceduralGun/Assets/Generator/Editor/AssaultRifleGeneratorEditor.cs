using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssaultRifleGenerator))]
public class AssaultRifleGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AssaultRifleGenerator gunGenerator = (AssaultRifleGenerator)target;

        if (GUILayout.Button("Generate New Gun"))
        {
            gunGenerator.GenerateAssaultRifle();
        }
    }
    
}
