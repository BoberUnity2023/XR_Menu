using System.Collections.Generic;
using UnityEngine;

public class QueueWindows: MonoBehaviour
{    
    [SerializeField] private Transform _initPositionTransform;
    private Queue<Window> _queueWindowPrefabs = new Queue<Window>();
    private Window _activeWindow;    

    public bool IsFree => _activeWindow == null;

    public WindowTag Tag { get; private set; }

    public bool TryShow(Window windowPrefab)
    {
        if (IsFree)
        {
            Show(windowPrefab);
            return true;
        }
        else
        { 
            _queueWindowPrefabs.Enqueue(windowPrefab);
            return false;
        }
    }

    public void Remove()
    {
        _activeWindow.Hide();
        Tag = WindowTag.None;

        if (_queueWindowPrefabs.Count > 0)
        {
            Show(_queueWindowPrefabs.Dequeue());
        }
    }

    public void Show(Window windowPrefab)
    {
        Vector3 position = _initPositionTransform.position;
        Quaternion rotation = _initPositionTransform.rotation;
        Transform parent = _initPositionTransform;
        _activeWindow = Instantiate(windowPrefab, position, rotation, parent);
        _activeWindow.Init(this);
        Tag = windowPrefab.Tag;
    }

    public void HideActiveWindow()
    {
        _activeWindow.Hide();
    }
}
