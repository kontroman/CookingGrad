using UnityEngine;

namespace Map.Line
{
    public class LinePathCreator : MonoBehaviour
    { 
        [HideInInspector]
        public LinePath LinePath;

        public void CreatePath()
        {
            LinePath = new LinePath(transform.position);
        }
    }
}
