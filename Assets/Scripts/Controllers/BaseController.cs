using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public virtual Task InitComponent(LevelData levelData)
    {
        return Task.CompletedTask;
    }
}
