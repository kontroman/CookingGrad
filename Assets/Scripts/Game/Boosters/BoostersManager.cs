using Devotion.Scripts.Game.Boosters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Devotion.Scripts.Game.Boosters
{
    public class BoostersManager
    {
        public static BoostersManager Instance;
        private List<Booster> _boosters = new List<Booster>();

        public BoostersManager(LevelData levelData)
        {
            if (Instance != null)
                return;

            Instance = this;

            Init(levelData);
        }

        private void Init(LevelData levelData)
        {
            if(levelData.Boosters.Count > 0)

            foreach(Booster booster in levelData.Boosters)
            {
                _boosters.Add(booster);

                booster.ActivateBooster(booster.Type);
            }
        }

        public bool GetBooster(Booster.BoosterType type)
        {
            return _boosters.Contains(_boosters.Find(x => x.Type == type));
        }
    }
}