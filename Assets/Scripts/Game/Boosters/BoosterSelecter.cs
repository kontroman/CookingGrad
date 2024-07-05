using Devotion.Scripts.GameData;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Game.Boosters
{
    public class BoosterSelecter : MonoBehaviour
    {
        [SerializeField] private Booster.BoosterType Type;

        private Booster booster;

        [SerializeField] private Sprite ActiveSprite;
        [SerializeField] private Sprite InactiveSprite;
        [SerializeField] private Image Image;

        private bool isActive;
        private LevelData levelData;

        public void Toggle()
        {
            if (isActive)
            {
                booster.IsActive = false;
                levelData.Boosters.Remove(booster);
                isActive = false;
                Image.sprite = InactiveSprite;
            }
            else
            {
                booster.IsActive = true;
                levelData.Boosters.Add(booster);
                isActive = true;
                Image.sprite = ActiveSprite;
            }
        }

        internal void SetLevelData(LevelData currentTask)
        {
            switch (Type)
            {
                case Booster.BoosterType.NoOvercooked:
                    booster = new Booster();
                    booster.Type = Booster.BoosterType.NoOvercooked;
                    break;
                case Booster.BoosterType.AutoServer:
                    booster = new Booster();
                    booster.Type = Booster.BoosterType.AutoServer;
                    break;
                case Booster.BoosterType.FastCooking:
                    booster = new Booster();
                    booster.Type = Booster.BoosterType.FastCooking;
                    break;
            }
            levelData = currentTask;
        }
    }
}