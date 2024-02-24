using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Localization
{
    public class LocalizeRadioChild : MonoBehaviour
    {
        [SerializeField] Image ThisCheckBoxImg = null;
        [SerializeField] Text ThisText = null;

        private Color32 activeColor = new Color32(80, 220, 255, 255);
        private Color32 passiveColor = new Color32(255, 255, 255, 255);

        public void SetText(string langStr)
        {
            ThisText.text = langStr;
        }

        public void ApplySelectedColor(bool isActive)
        {
            ThisCheckBoxImg.color = isActive ? activeColor : passiveColor;
        }

        public void ChangeLang()
        {
            transform.parent.gameObject
                .GetComponent<LocalizeRadioGroup>()
                .RadioValueChanged(transform.GetSiblingIndex());
        }
    }
}
