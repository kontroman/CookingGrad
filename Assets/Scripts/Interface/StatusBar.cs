using Devotion.Scripts.Controllers;
using Devotion.Scripts.Game.Levels;
using Devotion.Scripts.GameData;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Devotion.Scripts.Interface
{
    public class StatusBar : BaseController
    {
        [SerializeField] ProgressBar _mainBar;
        [SerializeField] ProgressBar _secondaryBar;
        [SerializeField] GameObject _secondaryTaskPrefab;

        [SerializeField] List<Transform> _secondaryTasksPositions = new List<Transform>();

        public override Task InitComponent(LevelData levelData)
        {
            _mainBar.Init(levelData.Tasks.Find(x => x.Type == QuestType.Main));
            _secondaryBar.Init(levelData.Tasks.Find(x => x.Type == QuestType.Secondary));

            foreach (LevelTask lt in levelData.Tasks)
            {
                if(lt.Type == QuestType.Additional)
                {
                    Transform position = _secondaryTasksPositions[0];

                    _secondaryTasksPositions.RemoveAt(0);

                    var bar = Instantiate(_secondaryTaskPrefab, position);
                    bar.transform.localPosition = Vector3.zero;

                    bar.GetComponent<SecondaryTaskBar>().Init(lt);
                }
            }

            return Task.CompletedTask;
        }

    }
}