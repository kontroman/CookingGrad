using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Devotion.Scripts.Localization
{
    [CustomEditor(typeof(LocalizeMaster))]
    public class LocalizeMasterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This scritable object is the master data. Please be careful not to delete.", MessageType.Info, true);

            EditorGUILayout.LabelField("Languages", EditorStyles.boldLabel);
            DrawDefaultInspector();

            EditorUtility.SetDirty(target);
        }
    }
}
