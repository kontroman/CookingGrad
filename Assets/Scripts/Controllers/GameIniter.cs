using Devotion.Scripts.Game.Boosters;
using Devotion.Scripts.GameData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Devotion.Scripts.Controllers
{
    public class GameIniter : MonoBehaviour
    {
        public static GameIniter Instance;

        [SerializeField]
        private List<BaseController> _components = new List<BaseController>();

        public LevelData LevelData;

        public event Action foodOvercoked;
        public event Action foodTrashed;

        public GameObject EndGameWindow;

        public bool GameFinished;

        private void Awake()
        {
            BoostersManager boostersManager = new BoostersManager(LevelData);
        }

        private async void Start()
        {
            Time.timeScale = 1;
            Instance = this;

            _components.ForEach(async component =>
            {
                await component.InitComponent(LevelData);
            });
        }

        public void InvokeAction(bool trashed)
        {
            if (trashed)
                foodTrashed?.Invoke();
            else
                foodOvercoked?.Invoke();
        }

        public async void SetGameOver()
        {
            GameFinished = true;

            ShowEndGameWindow();

            await DoSlowTime();
        }

        public async void SetWin()
        {
            GameFinished = true;


            await DoSlowTime();
        }

        private async Task<Task> DoSlowTime()
        {
            while (Time.timeScale > 0.1)
            {
                Time.timeScale -= 0.05f;

                await Task.Delay(90);
            }

            Time.timeScale = 0;

            return Task.CompletedTask;
        }

        public void ShowEndGameWindow()
        {
            EndGameWindow.SetActive(true);
        }
    }
}