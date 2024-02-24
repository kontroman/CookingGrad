using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Localization
{
    [RequireComponent(typeof(Dropdown))]
    public class LocalizeDropdown : MonoBehaviour
    {
        [Header("Be careful that you are setting the correct LocalizeMaster.")]
        [SerializeField] LocalizeMaster lm = null;
        private Dropdown dropdown = null;

        private void Awake()
        {
            dropdown = GetComponent<Dropdown>();
        }

        void Start()
        {
            if (lm == null) {
                Debug.LogError("lm (LocalizeMaster) must be setted.");
                return;
            }
            dropdown.ClearOptions();
            List<string> list = new List<string>();
            for (int i = 0; i < lm.langs.Count; i++)
            {
                list.Add(lm.MappingValueNam(lm.langs[i]));
            }
            dropdown.AddOptions(list);
            dropdown.value = lm.langs.IndexOf(lm.GetSelectedLang());
            dropdown.onValueChanged.AddListener(delegate
            {
                DropdownValueChanged(dropdown);
            });

            ApplyDropdownValue();
        }

        public void ApplyDropdownValue()
        {
            dropdown.value = lm.langs.IndexOf(lm.GetSelectedLang()) >= 0
                ? lm.langs.IndexOf(lm.GetSelectedLang())
                : 0;
        }

        private void DropdownValueChanged(Dropdown change)
        {
            lm.SetSelectedLang(lm.langs[change.value]);
            lm.ChangeLang();
        }
    }
}
