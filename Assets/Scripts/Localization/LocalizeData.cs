using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Devotion.Scripts.Localization
{
    [CreateAssetMenu(fileName = "LocalizeData", menuName = "Tools/Localization/LocalizeData", order = 1)]
    public class LocalizeData : ScriptableObject
    {
        public LocalizeMaster lm = null;
        public List<string> langStrList = new List<string>();
        public string defaultText = "";
    }
}
