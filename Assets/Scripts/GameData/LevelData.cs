using Devotion.Scripts.Game.Boosters;
using Devotion.Scripts.Game.Levels;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Devotion.Scripts.GameData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Datas/Game/LevelData")]
    public class LevelData : ScriptableObject
    {
        public int LevelIndex;
        public int CustomersCount;
        public int TimeBeforeFirstCustomer;
        public int SpawnTime;

        [AssetSelector]
        public TextAsset AvailableOrders;

        public bool HasTime;

        [ShowIf("HasTime")]
        public int GameTime;

        [TableList, GUIColor(1f, 0.8f, 0.8f)]
        public List<LevelTask> Tasks;

        public List<Booster> Boosters;
    }
}