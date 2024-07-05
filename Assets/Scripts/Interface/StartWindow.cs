using Devotion.Scripts.Controllers;
using Devotion.Scripts.Game.Levels;
using Devotion.Scripts.GameData;
using System.Collections;
using UnityEngine;

namespace Devotion.Scripts.Interface
{
    public class StartWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _parentPanel;
        [SerializeField] private GameObject _taskPrefab;

        public LevelData CurrentTask;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1);

            gameObject.transform.localScale = Vector3.one;

            CurrentTask = GameplayController.Instance.LevelData;

            foreach (var item in CurrentTask.Tasks)
            {
                var task = Instantiate(_taskPrefab, _parentPanel.transform);

                task.GetComponent<DisplayTask>().Init(item);
            }

            DestroyWindow(2);
        }

        public void DestroyWindow(float delay)
        {
            Destroy(gameObject, delay);
        }
    }
}