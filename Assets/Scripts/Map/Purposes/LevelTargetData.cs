using UnityEngine;
using UnityEngine.Serialization;

namespace Map.Purposes
{
    public enum MainTarget
    {
        Dishes,
        Coins,
        Likes
    }

    public enum SubTarget
    {
        None,
        Time,
        Customers
    }
    
    [CreateAssetMenu(fileName = "NewLevelData", menuName = "SciptableObjects/LevelTarget") ]
    public class LevelTargetData : ScriptableObject
    {
        [Header("MAIN TARGET")]
        [SerializeField] private MainTarget _mainTarget;
        public MainTarget MainTargetType => _mainTarget;
        [SerializeField, Min(1)] private int _mainTargetValue;
        public int MainTarget => _mainTargetValue;
        
        [Header("SUB TARGET")]
        [SerializeField] private SubTarget _subTarget;
        public SubTarget SubTargetType => _subTarget;
        [SerializeField] private int _subTargetValue;
        public int SubTarget => _subTargetValue;
    }
}
