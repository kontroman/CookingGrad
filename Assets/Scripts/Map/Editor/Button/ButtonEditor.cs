using Map.Button;
using UnityEditor;
using UnityEngine;

namespace Map.Editor.Button
{
    [CustomEditor(typeof(ButtonPlacer))]
    public class ButtonEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        
            var placer = (ButtonPlacer)target;

            if (GUILayout.Button("Set Buttons"))
            {
                placer.SetButtons();
            }
        
        }
    }
}
