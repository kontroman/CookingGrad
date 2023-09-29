using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Interface
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        [SerializeField] private TextMeshProUGUI _text;

        private LevelTask _task;

        private int maxValue;
        private int currentValue;

        public void Init(LevelTask levelTask)
        {
            _progressBar = GetComponent<Image>();
            maxValue = levelTask.Count;
            currentValue = 0;
            _text.text = string.Format("{0}/{1}", currentValue, maxValue);
            _progressBar.fillAmount = 0;
            _task = levelTask;

            ObserveTask(levelTask);
        }

        private void ObserveTask(LevelTask levelTask)
        {
            switch (levelTask.MainTask)
            {
                case Quest.ServeCustomers:
                    CustomersController.Instance.TotalServedCustomersChanged += UpdateInfo;
                    break;
                case Quest.CollectMoney:
                    CustomersController.Instance.TotalMoneyChanged += UpdateMoney;
                    break;
            }
        }

        private void UpdateInfo()
        {
            if(currentValue < maxValue)
                currentValue += 1;

            _text.text = string.Format("{0}/{1}", currentValue, maxValue);

            if(_progressBar.fillAmount != 1)
                _progressBar.fillAmount = (float)currentValue / (float)maxValue;

            if (currentValue >= maxValue)
            {
                _task.IsCompleted = true;
            }
        }

        private void UpdateMoney()
        {
            currentValue = CustomersController.Instance.TotalEarnedMoney;

            _text.text = string.Format("{0}/{1}", currentValue, maxValue);

            if (_progressBar.fillAmount != 1)
                _progressBar.fillAmount = (float)currentValue / (float)maxValue;

            if (currentValue >= maxValue)
            {
                _task.IsCompleted = true;
            }
        }
    }
}