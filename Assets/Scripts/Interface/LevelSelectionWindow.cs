using Devotion.Scripts.Game.Boosters;
using Devotion.Scripts.Game.Levels;
using Devotion.Scripts.GameData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Devotion.Scripts.Interface
{
    public class LevelSelectionWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _parentPanel;
        [SerializeField] private GameObject _taskPrefab;
        [SerializeField] private List<BoosterSelecter> _selecters = new List<BoosterSelecter>();

        public LevelData CurrentTask;

        public void SetLevelData(LevelData levelData)
        {
            CurrentTask = levelData;
            UpdateBoosters();
            UpdateTasks();
        }

        private void UpdateTasks()
        {
            foreach (var item in CurrentTask.Tasks)
            {
                var obj = Instantiate(_taskPrefab, _parentPanel.transform);
                obj.GetComponent<Image>().sprite = item.Icon;
                if(item.HasCounter)
                {
                    obj.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = item.Count.ToString();
                }
            }
        }

        public void StartGame()
        {
            PlayerPrefs.SetInt("CurrentLevel", CurrentTask.LevelIndex);
            SceneManager.LoadScene(1);
        }

        private void UpdateBoosters()
        {
            foreach (var item in _selecters)
            {
                item.SetLevelData(CurrentTask);
            }
        }

        public void DestroyWindow(float delay)
        {
            CurrentTask.Boosters.Clear();

            Destroy(gameObject, delay);
        }
    }
}