using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Devotion.Scripts.Localization
{
    public class MasterWindow : EditorWindow
    {
        public LocalizeMaster LocalizeMaster;
        [MenuItem("Tools/Localization")]
        static void Open()
        {
            var window = GetWindow<MasterWindow>();
            window.titleContent = new GUIContent("Localization");
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Languages", EditorStyles.boldLabel);
            Editor.CreateEditor(LocalizeMaster).DrawDefaultInspector();
        }
    }
}
