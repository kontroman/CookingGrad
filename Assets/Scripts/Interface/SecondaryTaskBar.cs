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

            ObserveTask(levelTask);
        }

        private void ObserveTask(LevelTask levelTask)
        {
            switch (levelTask.MainTask)
            {
                case Quest.NoOvercooked:
                    GameIniter.Instance.foodOvercoked += UpdateInfo;
                    break;

                case Quest.NoTrash:
                    GameIniter.Instance.foodTrashed += UpdateInfo;
                    break;

                case Quest.NoUnhappy:

                    break;
            }
        }

        private void UpdateInfo()
        {
            GameIniter.Instance.SetGameOver();
        }
    }
}