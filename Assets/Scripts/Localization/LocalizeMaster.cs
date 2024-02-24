using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Devotion.Scripts.Localization
{
    public class LocalizeMaster : ScriptableObject
    {
        public List<SystemLanguage> langs = new List<SystemLanguage>();
        private SystemLanguage selectedLang = SystemLanguage.English;
        private readonly string DATA_KEY = "Localization";

        private void Awake()
        {
            if (PlayerPrefs.HasKey(DATA_KEY))
            {
                UniSimpleLocalizeData prevData = ReadData();
                selectedLang = prevData.selectedLang;
            }
            else
            {
                selectedLang = Application.systemLanguage;
            }
        }

        public void UpdateSelectedLanguage()
        {

        }
        public void SetSelectedLang(SystemLanguage nextLang)
        {
            selectedLang = nextLang;
            UniSimpleLocalizeData saveData = new UniSimpleLocalizeData
            {
                langs = langs,
                selectedLang = nextLang
            };
            SaveData(saveData);
        }

        public SystemLanguage GetSelectedLang()
        {
            return selectedLang;
        }

        private void SaveData(UniSimpleLocalizeData nextSaveData)
        {
            var json = JsonUtility.ToJson(nextSaveData);
            PlayerPrefs.SetString(DATA_KEY, json);
            PlayerPrefs.Save();
        }

        public UniSimpleLocalizeData ReadData()
        {
            var json = PlayerPrefs.GetString(DATA_KEY);
            var data = JsonUtility.FromJson<UniSimpleLocalizeData>(json);
            return data;
        }

        public void ChangeLang()
        {
            LocalizeUIText[] uiTexts = FindObjectsOfType(typeof(LocalizeUIText)) as LocalizeUIText[];
            foreach (LocalizeUIText uiText in uiTexts)
            {
                uiText.Apply();
            }
            Localize3DText[] threeDTexts = FindObjectsOfType(typeof(Localize3DText)) as Localize3DText[];
            foreach (Localize3DText threeDText in threeDTexts)
            {
                threeDText.Apply();
            }
            LocalizeRadioGroup[] radioGroups = FindObjectsOfType(typeof(LocalizeRadioGroup)) as LocalizeRadioGroup[];
            foreach (LocalizeRadioGroup radioGroup in radioGroups)
            {
                radioGroup.ApplyRadioChiild();
            }
            LocalizeDropdown[] dropdowns = FindObjectsOfType(typeof(LocalizeDropdown)) as LocalizeDropdown[];
            foreach (LocalizeDropdown dropdown in dropdowns)
            {
                dropdown.ApplyDropdownValue();
            }
            LocalizeUIImage[] images = FindObjectsOfType(typeof(LocalizeUIImage)) as LocalizeUIImage[];
            foreach (LocalizeUIImage iamge in images)
            {
                iamge.Apply();
            }

            LocalizeUITMP[] uiTmps = FindObjectsOfType(typeof(LocalizeUITMP)) as LocalizeUITMP[];
            foreach (LocalizeUITMP uiTmp in uiTmps)
            {
                uiTmp.Apply();
            }
        }

        public string MappingValueNam(SystemLanguage thisLandValue)
        {
            switch (thisLandValue)
            {
                case SystemLanguage.English:
                    return "English";
                case SystemLanguage.Japanese:
                    return "日本語";
                case SystemLanguage.ChineseSimplified:
                    return "中国语 简体字";
                case SystemLanguage.ChineseTraditional:
                    return "中国语 繁體字";
                case SystemLanguage.Chinese:
                    return "中国语";
                case SystemLanguage.Afrikaans:
                    return "Afrikane";
                case SystemLanguage.Arabic:
                    return "عربى";
                case SystemLanguage.Basque:
                    return "Euskara";
                case SystemLanguage.Belarusian:
                    return "Беларуская";
                case SystemLanguage.Bulgarian:
                    return "български";
                case SystemLanguage.Catalan:
                    return "Català";
                case SystemLanguage.Czech:
                    return "Český jazyk";
                case SystemLanguage.Danish:
                    return "dansk";
                case SystemLanguage.Dutch:
                    return "Nederlands";
                case SystemLanguage.Estonian:
                    return "Eestlane";
                case SystemLanguage.Faroese:
                    return "Føroyskt";
                case SystemLanguage.Finnish:
                    return "Suomen kieli, Suomi";
                case SystemLanguage.French:
                    return "français";
                case SystemLanguage.German:
                    return "Deutsch";
                case SystemLanguage.Greek:
                    return "Ελληνικά";
                case SystemLanguage.Hebrew:
                    return "עברית";
                case SystemLanguage.Hungarian:
                    return "magyar nyelv";
                case SystemLanguage.Icelandic:
                    return "íslenska";
                case SystemLanguage.Indonesian:
                    return "Bahasa Indonesia";
                case SystemLanguage.Italian:
                    return "Italiano";
                case SystemLanguage.Korean:
                    return "조선말";
                case SystemLanguage.Latvian:
                    return "Latviešu";
                case SystemLanguage.Lithuanian:
                    return "lietuvių kalba";
                case SystemLanguage.Norwegian:
                    return "norsk";
                case SystemLanguage.Polish:
                    return "język polski";
                case SystemLanguage.Portuguese:
                    return "Português";
                case SystemLanguage.Romanian:
                    return "limba română";
                case SystemLanguage.Russian:
                    return "русский язык";
                case SystemLanguage.SerboCroatian:
                    return "srpskohrvatski / српскохрватски";
                case SystemLanguage.Slovak:
                    return "Slovenčina";
                case SystemLanguage.Slovenian:
                    return "slovenščina";
                case SystemLanguage.Spanish:
                    return "español";
                case SystemLanguage.Swedish:
                    return "svenska";
                case SystemLanguage.Thai:
                    return "ภาษาไทย";
                case SystemLanguage.Turkish:
                    return "Türkçe";
                case SystemLanguage.Ukrainian:
                    return "українська мова";
                case SystemLanguage.Vietnamese:
                    return "Tiếng Việt";
                case SystemLanguage.Unknown:
                default:
                    return thisLandValue.ToString();
            }
        }

    }

    [System.Serializable]
    public class UniSimpleLocalizeData
    {
        public List<SystemLanguage> langs;
        public SystemLanguage selectedLang;
    }
}
