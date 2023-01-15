using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : Window
{
    private StartGameWindow startGameWindow;
    private SettingsWindow settingsWindow;

    public void Start()
    {
        startGameWindow = UIManager.Instance.GetWindow<StartGameWindow>();
        settingsWindow = UIManager.Instance.GetWindow<SettingsWindow>();

        startGameWindow.OnOpen += ChangeCurrentWindow;
        settingsWindow.OnOpen += ChangeCurrentWindow;
     
    }
    protected override void SelfOpen()
    {
        this.gameObject.SetActive(true);
    }
    protected override void SelfClose()
    {
        this.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        startGameWindow.Open();
    }

    public void Settings()
    {
        settingsWindow.Open();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
