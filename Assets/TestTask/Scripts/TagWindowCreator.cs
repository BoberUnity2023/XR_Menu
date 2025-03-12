using System.Collections.Generic;
using UnityEngine;

public class TagWindowCreator : MonoBehaviour
{
    [SerializeField] private QueueWindows _queueFirst;
    [SerializeField] private QueueWindows _queueSecond;
    [SerializeField] private Window[] _windowPrefabsSettings;
    [SerializeField] private Window[] _windowPrefabsFriends;
    [SerializeField] private Window[] _windowPrefabsInvites;
    [SerializeField] private Queue<Window> _queueWindowPrefabs = new Queue<Window>();

    public void PressShowWindow(string id)
    {
        Window[] windowPrefabs = null;

        if (id.Substring(0, 1) == "s")
        {
            windowPrefabs = _windowPrefabsSettings;
        }

        if (id.Substring(0, 1) == "f")
        {
            windowPrefabs = _windowPrefabsFriends;
        }

        if (id.Substring(0, 1) == "i")
        {
            windowPrefabs = _windowPrefabsInvites;
        }

        if (id.Substring(1, 1) == "0")
        {
            AddWindow(windowPrefabs[0]);
        }

        if (id.Substring(1, 1) == "1")
        {
            AddWindow(windowPrefabs[1]);
        }

        if (id.Substring(1, 1) == "2")
        {
            AddWindow(windowPrefabs[2]);
        }

        if (id.Substring(1, 1) == "3")
        {
            AddWindow(windowPrefabs[3]);
        }
    }

    public void PressTake(QueueWindows queueWindows)
    {
        queueWindows.Remove();
        if (_queueWindowPrefabs.Count > 0)
        {
            Window window = _queueWindowPrefabs.Dequeue();
            queueWindows.TryShow(window);
        }
    }

    public void AddWindow(Window window)
    {
        bool success = TryAddWindow(window, _queueFirst);
        if (!success)
        {
            success = TryAddWindow(window, _queueSecond);
            if (!success)
                _queueWindowPrefabs.Enqueue(window);
        }
    }

    private bool TryAddWindow(Window window, QueueWindows queueWindows)
    {
        if (queueWindows.IsFree)
        {
            queueWindows.TryShow(window);
            return true;
        }
        else
        {
            if (queueWindows.Tag == window.Tag)
            {
                queueWindows.HideActiveWindow();
                queueWindows.Show(window);
                return true;
            } 

            return false;   
        }
    }
}
