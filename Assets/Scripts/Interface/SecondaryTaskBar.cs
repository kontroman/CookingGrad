using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Interface
{
    public class SecondaryTaskBar : BaseController
    {
        [SerializeField] private Image _icon;

        public void Init(LevelTask levelTask)
        {
            _icon.sprite = levelTask.Icon;
        }
    }
}