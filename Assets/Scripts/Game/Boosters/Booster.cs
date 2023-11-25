using System;

namespace Devotion.Scripts.Game.Boosters
{
    [Serializable]
    public class Booster
    {
        public enum BoosterType
        {
            NoOvercooked,
            FastCooking,
            AutoServer
        }

        public event Action<BoosterType> OnBoosterActivated;
        public bool IsActive;
        public BoosterType Type;

        public void ActivateBooster(BoosterType boosterType)
        {
            OnBoosterActivated?.Invoke(boosterType);

            IsActive = true;
        }
    }
}
