using System.Collections.Generic;
using UnityEngine;

namespace Map.Line
{
    [System.Serializable]
    public class LinePath
    {
        [SerializeField, HideInInspector] private List<Vector2> _points;
    
        public LinePath(Vector2 center)
        {
            _points = new List<Vector2>
            {
                center + Vector2.left * 100f,
                center + Vector2.right * 100f
            };
        }

        public Vector2 this[int i] => _points[i];
    
        public int NumPoints => _points.Count;
    
        public int NumSegment => _points.Count - 1;
    
        public void AddSegment(Vector2 anchorPos)
        {
            _points.Add(anchorPos);
        }

        public Vector2[] GetPointsInSegment(int i)
        {
            return new[]
            {            
                _points[i],
                _points[i + 1]
            };
        }

        public void MovePoint(int i, Vector2 pos)
        {
            _points[i] = pos;
        }

        public float GetDistanceInSegment(int i)
        {
            var dots = GetPointsInSegment(i);
            var dst = Vector2.Distance(dots[0],dots[1]);

            return dst;
        }
    }
}
