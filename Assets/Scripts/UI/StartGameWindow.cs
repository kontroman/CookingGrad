using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameWindow : Window
{
    protected override void SelfOpen()
    {
        this.gameObject.SetActive(true);
    }
    protected override void SelfClose()
    {
        this.gameObject.SetActive(false);
    }
}
