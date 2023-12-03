using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEditor;

[CustomEditor(typeof(BattleCharacterController))]
public class BattleCharacterControllerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var controller = target as BattleCharacterController;

        if (GUILayout.Button("Fire"))
        {
            if (controller != null)
            {
                controller.Fire();
            }    
        }
    }
}
