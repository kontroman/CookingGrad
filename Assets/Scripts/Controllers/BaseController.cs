using Devotion.Scripts.GameData;
using System.Threading.Tasks;
using UnityEngine;

namespace Devotion.Scripts.Controllers
{
    public class BaseController : MonoBehaviour
    {
        public virtual Task InitComponent(LevelData levelData)
        {
            return Task.CompletedTask;
        }
    }
}