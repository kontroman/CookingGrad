using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Devotion.Scripts.Localization
{
    [RequireComponent(typeof(TextMesh))]
    public class Localize3DText : MonoBehaviour
    {
        public LocalizeMaster LocalizeMaster = null;
        public LocalizeData LocalizeScritableObject = null;

        private TextMesh thisText = null;

        private void Awake()
        {
            thisText = GetComponent<TextMesh>();

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
