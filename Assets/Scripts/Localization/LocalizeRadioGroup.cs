using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Devotion.Scripts.Localization
{
    public class LocalizeRadioGroup : MonoBehaviour
    {
        [Header("Be careful that you are setting the correct LocalizeMaster.")]
        [SerializeField] LocalizeMaster lm = null;
        [SerializeField] GameObject RadioChildPrefab = null;

        private List<LocalizeRadioChild> RadioList = new List<LocalizeRadioChild>();

        void Start()
        {
            if (lm == null)
            {
                Debug.LogError("lm (LocalizeMaster) must be setted.");
                return;
            }
            if (RadioChildPrefab == null)
            {
                Debug.LogError("RadioChildPrefab must be setted.");
                return;
            }
            for (int i = 0; i < lm.langs.Count; i++)
            {
                GameObject thisRadioChild = Instantiate(
                        RadioChildPrefab,
                        transform.position,
                        Quaternion.identity,
                        transform
                    );
                LocalizeRadioChild RadioChildScript = thisRadioChild.GetComponent<LocalizeRadioChild>();
                RadioChildScript.ApplySelectedColor(i == lm.langs.IndexOf(lm.GetSelectedLang()));
                RadioChildScript.SetText(lm.MappingValueNam(lm.langs[i]));
                RadioList.Add(RadioChildScript);
            }
        }

        public void ApplyRadioChiild()
        {
            for (int i = 0; i < lm.langs.Count; i++)
            {
                RadioList[i].ApplySelectedColor(i == lm.langs.IndexOf(lm.GetSelectedLang()));
            }
        }

        public void RadioValueChanged(int index)
        {
            if (index == lm.langs.IndexOf(lm.GetSelectedLang())) return;
            lm.SetSelectedLang(lm.langs[index]);
            lm.ChangeLang();
        }
    }
}
