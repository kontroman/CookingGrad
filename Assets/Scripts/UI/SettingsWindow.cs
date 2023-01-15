using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : Window
{
    private VideoSettingsWindow videoSettingsWindow;
    private LanguageSettingsWindow languageSettingsWindow;
    private AudioSettingsWindow audioSettingsWindow;
    private ControlSettingsWindow controlSettingsWindow;
    public void Start()
    {
        videoSettingsWindow = UIManager.Instance.GetWindow<VideoSettingsWindow>();
        languageSettingsWindow = UIManager.Instance.GetWindow<LanguageSettingsWindow>();
        audioSettingsWindow = UIManager.Instance.GetWindow<AudioSettingsWindow>();
        controlSettingsWindow = UIManager.Instance.GetWindow<ControlSettingsWindow>();
     
        videoSettingsWindow.OnOpen += ChangeCurrentWindow;
        languageSettingsWindow.OnOpen += ChangeCurrentWindow;
        audioSettingsWindow.OnOpen += ChangeCurrentWindow;
        controlSettingsWindow.OnOpen += ChangeCurrentWindow;
    }
    protected override void SelfOpen()
    {
        this.gameObject.SetActive(true);
    }
    protected override void SelfClose()
    {
        this.gameObject.SetActive(false);
    }
    public void Apply()
    {
        
    }

    public void VideoSettings()
    {
        videoSettingsWindow.Open();
    }
    public void LanguageSettings()
    {
        languageSettingsWindow.Open();
    }
    public void AudioSettings()
    {
        audioSettingsWindow.Open();
    }
    public void ControlSettings()
    {
        controlSettingsWindow.Open();
    }
}
