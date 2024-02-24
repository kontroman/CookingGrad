using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Devotion.Scripts.Localization
{
    [RequireComponent(typeof(Image))]
    public class LocalizeUIImage : MonoBehaviour
    {
        public LocalizeMaster LocalizeMaster = null;
        public List<Sprite> langSpriteList = new List<Sprite>();
        public Sprite defaultSprite = null;

        private Image thisImage = null;

        private void Awake()
        {
            thisImage = GetComponent<Image>();

        }

        private void OnEnable()
        {
            Apply();
        }

        public void Apply()
        {
            thisImage.sprite = LocalizeMaster.langs.IndexOf(LocalizeMaster.GetSelectedLang()) >= 0
                ? langSpriteList[LocalizeMaster.langs.IndexOf(LocalizeMaster.GetSelectedLang())]
                : defaultSprite;
        }
    }
}
