using UnityEngine;

namespace Devotion.Scripts.Interface
{
    public class EndWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _parentPanel;
        [SerializeField] private GameObject _taskPrefab;

        public LevelData CurrentTask;

        private void Awake()
        {
            foreach (var item in CurrentTask.Tasks)
            {
                var task = Instantiate(_taskPrefab, _parentPanel.transform);

                task.GetComponent<DisplayTaskEnd>().Init(item);
            }
        }
    }
}