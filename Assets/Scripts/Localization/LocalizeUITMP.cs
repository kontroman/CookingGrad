using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Devotion.Scripts.Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizeUITMP : MonoBehaviour
    {
        public LocalizeMaster LocalizeMaster = null;
        public LocalizeData LocalizeScritableObject = null;

        private TextMeshProUGUI thisText = null;

        private void Awake()
        {
            thisText = GetComponent<TextMeshProUGUI>();

        }

        private void OnEnable()
        {
            Apply();
        }

        public void Apply()
        {
            thisText.text = LocalizeMaster.langs.IndexOf(LocalizeMaster.GetSelectedLang()) >= 0
                ? LocalizeScritableObject.langStrList[LocalizeMaster.langs.IndexOf(LocalizeMaster.GetSelectedLang())]
                : LocalizeScritableObject.defaultText;
        }
    }
}
