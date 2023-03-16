using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SplinePathCreator))]
public class SplineEditor : Editor
{
    private SplinePathCreator creator;
    private SplinePath path;

    private void OnSceneGUI()
    {
        Input();
        Draw();
    }

    private void Input()
    {
        var guiEvent = Event.current;
        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
            Undo.RecordObject(creator, "Add segment");
            path.AddSegment(mousePos);
        }
    }

    private void Draw()
    {
        for (int i = 0; i < path.NumSegment; i++)
        {
            Vector2[] points = path.GetPointsInSegment(i);
            Handles.color = Color.black;
            Handles.DrawLine(points[1], points[0]);
            Handles.DrawLine(points[2], points[3]);
            Handles.DrawBezier(points[0], points[3],
                               points[1], points[2],
                               Color.green, null, 10f);
        }
        
        for (int i = 0; i < path.NumPoints; i++)
        {
            Handles.color = i % 3 == 0 ? Color.red : Color.blue;
            Vector2 newPos = Handles.FreeMoveHandle(path[i], Quaternion.identity, 4f,
                Vector2.zero, Handles.CylinderHandleCap);
            
            if (path[i] != newPos)
            {
                Undo.RecordObject(creator, "Move Point");
                path.MovePoint(i, newPos);
            }
        }
    }
    private void OnEnable()
    {
        creator = (SplinePathCreator)target;
        
        if (creator.splinePath == null)
            creator.CreatePath();

        path = creator.splinePath;
    }
}
