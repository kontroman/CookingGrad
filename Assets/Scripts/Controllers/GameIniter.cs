using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIniter : MonoBehaviour
{
    public static GameIniter Instance;

    [SerializeField]
    private List<BaseController> _components = new List<BaseController>();

    public LevelData LevelData;

    private async void Start()
    {
        Instance = this;

        _components.ForEach(async component =>
        {
            await component.InitComponent(LevelData);
        });
    }
}
