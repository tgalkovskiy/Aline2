using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[ExecuteInEditMode]
[CustomEditor(typeof(CreateManager))]
public class CreatEditor : Editor
{
   public override void OnInspectorGUI()
   {
      DrawDefaultInspector();
      CreateManager _manager = (CreateManager) target;
      if (GUILayout.Button("CreateEnemy"))
      {
         _manager.CreateEnemy(_manager._posEnemy);
      }
      if(GUILayout.Button("CreateTrap"))
      {
         _manager.CreateTrap(_manager._posTrap);
      }
   }
}
