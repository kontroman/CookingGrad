using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public bool IsOpen { get; private set; }
    public Window CurrentWindow { get; protected set; } = null;

    public delegate void OpenEventHandler(Window sender);
    public event OpenEventHandler OnOpen;

    void Awake()
    {
        UIManager.Instance.Windows.Add(this.gameObject);
    }
    public void Open()
    {
        IsOpen = true;
        if (OnOpen != null)
            OnOpen(this);

        SelfOpen();
    }
    protected abstract void SelfOpen();
    public void Close()
    {
        IsOpen = false;

        if (CurrentWindow != null)
            CurrentWindow.Close();
        SelfClose();
    }
    protected abstract void SelfClose();

    protected void ChangeCurrentWindow(Window sender)
    {
        if (CurrentWindow != null)
            CurrentWindow.Close();
        CurrentWindow = sender;
    }
}
