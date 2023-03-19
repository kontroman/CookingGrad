using Map.Line;
using UnityEditor;
using UnityEngine;

namespace Map.Editor
{
    [CustomEditor(typeof(LinePathCreator))]
    public class LineEditor : UnityEditor.Editor
    {
        private LinePathCreator _creator;
        private LinePath _path;

        private void OnSceneGUI()
        {
            Input();
            Draw();
        }

        private void OnEnable()
        {
            _creator = (LinePathCreator)target;
        
            if (_creator.LinePath == null)
                _creator.CreatePath();

            _path = _creator.LinePath;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        
            GUILayout.Label($"Number of points: {_path.NumPoints}");
        }

        private void Input()
        {
            var guiEvent = Event.current;
            Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

            if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
            {
                Undo.RecordObject(_creator, "Add segment");
                _path.AddSegment(mousePos);
            }
        }

        private void Draw()
        {
            for (int i = 0; i < _path.NumSegment; i++)
            {
                var points = _path.GetPointsInSegment(i);
                Handles.color = Color.green;
                Handles.DrawLine(points[0], points[1]);
            }
        
            for (int i = 0; i < _path.NumPoints; i++)
            {
                Handles.color = Color.red;
                Vector2 newPos = Handles.FreeMoveHandle(_path[i], Quaternion.identity, 4f,
                    Vector2.zero, Handles.CylinderHandleCap);

                if (_path[i] == newPos) continue;
                Undo.RecordObject(_creator, "Move Point");
                _path.MovePoint(i, newPos);
            }
        }
    }
}
