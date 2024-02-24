using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Game.Levels
{
    public class DisplayTask : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _title;

        public void Init(LevelTask task)
        {
            string postfix = task.HasCounter ? task.Count.ToString() : " ";

            _icon.sprite = task.Icon;
            _title.text = task.Discription + postfix;
        }
    }
}
