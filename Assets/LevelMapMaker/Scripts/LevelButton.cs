using Devotion.Scripts.GameData;
using Devotion.Scripts.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
    public class LevelButton : MonoBehaviour
    {
        public GameObject LeftStar;
        public GameObject MiddleStar;
        public GameObject RightStar;
        public GameObject Lock;
        public Button button;
        public Text numberText;
        public LevelData LevelData;

        public bool Interactable { get; private set; }

        private void SetData()
        {
            //Debug.LogError("Levels/Level" + numberText.ToString());
            //LevelData = Resources.Load<LevelData>("Levels/Level" + numberText.text.ToString());
        }

        public void SetListener()
        {
            button.onClick.AddListener(OnClick);
        }
        
        public void OnClick()
        {
            if (LevelData != null)
            {
                GameObject window = (GameObject)Instantiate(Resources.Load("Prefabs/Interface/StartWindow"), GameObject.Find("Canvas").transform);
                window.GetComponent<LevelSelectionWindow>().SetLevelData(LevelData);
            }
        }

        internal void SetActive(bool active, int activeStarsCount, bool isPassed, int counter)
        {
            if (LeftStar)  LeftStar.SetActive(activeStarsCount > 1 && isPassed);
            if (MiddleStar) MiddleStar.SetActive(activeStarsCount > 0 && isPassed);
            if (RightStar) RightStar.SetActive(activeStarsCount > 2 && isPassed);

            Interactable = active || isPassed;

            if(button)  button.interactable = Interactable;

            if (active)
                MapController.Instance.ActiveButton = this;

            numberText.text = counter.ToString();
            LevelData = Resources.Load<LevelData>("Levels/Level" + (counter + 1).ToString());
            if (Lock) Lock.SetActive(!isPassed && !active);
            SetData();
        }
    }
}