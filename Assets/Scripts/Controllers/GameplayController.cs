using Devotion.Scripts.GameData;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Devotion.Scripts.Controllers
{
    public class GameplayController : BaseController
    {
        public static GameplayController Instance { get; private set; }

        public LevelData LevelData;

        private int customers;
        private int servedCustomers = 0;

        public override Task InitComponent(LevelData levelData)
        {
            Instance = this;
            LevelData = levelData;
            customers = levelData.CustomersCount;

            return Task.CompletedTask;
        }

        public void CheckGameFinish()
        {
            servedCustomers++;

            if(servedCustomers >= customers)
            {
                GameIniter.Instance.SetWin();
            }
        }
    }
}