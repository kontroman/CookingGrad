using Map.Line;
using UnityEngine;

namespace Map.Button
{
    public class ButtonPlacer : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private int _count;
    
        private LinePath _path;

        public void SetButtons()
        {
            _path = FindObjectOfType<LinePathCreator>().LinePath;

            if (_count > _path.NumPoints)
                return;
            for (int i = 0; i < _count; i++)
            {
                Vector2 targetPosition = _path[i];
                var button = Instantiate(_buttonPrefab,targetPosition,Quaternion.identity);
                button.transform.SetParent(transform);
                button.transform.localScale = new Vector3(1,1,1);
            }
        }
    }
}
