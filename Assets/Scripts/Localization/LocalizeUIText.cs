using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Localization
{
    [RequireComponent(typeof(Text))]
    public class LocalizeUIText : MonoBehaviour
    {
        public LocalizeMaster LocalizeMaster = null;
        public LocalizeData LocalizeScritableObject = null;

        private Text thisText = null;

        private void Awake()
        {
            thisText = GetComponent<Text>();

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