using System.Collections.Generic;
using UnityEngine;

public class WindowCreatorNormal : WindowCreatorBase
{
    [SerializeField] private Transform _slotFirstTransform;
    [SerializeField] private Transform _slotSecondTransform;
    [SerializeField] private Window[] _windowPrefabsSettings;
    [SerializeField] private Window[] _windowPrefabsFriends;
    [SerializeField] private Window[] _windowPrefabsInvites;
    
    private Queue<Window> _queueWindowPrefabs = new Queue<Window>();
    private Slot _slotFirst;
    private Slot _slotSecond;    

    public void Init()
    {
        _slotFirst = new Slot(_slotFirstTransform);
        _slotSecond = new Slot(_slotSecondTransform);
    }

    public override void PressClose()
    {
        if (_queueWindowPrefabs.Count > 0)
        {
            if (_slotFirst.IsFree || _slotSecond.IsFree)
                ShowOrEnqueue(_queueWindowPrefabs.Dequeue());
        }
    }

    private void ShowOrEnqueue(Window windowPrefab)
    {
        if (_slotFirst.IsFree || windowPrefab.Tag == _slotFirst.Tag)
        {            
            if (!_slotFirst.IsFree)
            {
                _slotFirst.ActiveWindow.Hide(); 
            }
            ShowWindow(windowPrefab, _slotFirst);
        }
        else
        {
            if (_slotSecond.IsFree || windowPrefab.Tag == _slotSecond.Tag)
            {                
                if (!_slotSecond.IsFree)
                {
                    _slotSecond.ActiveWindow.Hide();
                }
                ShowWindow(windowPrefab, _slotSecond);                
            }
            else
            {
                Debug.Log("Normal window " + windowPrefab.name + " was added to queue");
                _queueWindowPrefabs.Enqueue(windowPrefab);
            }
        }
    }

    public void PressShowWindow(string id)//from Editor
    {
        Window[] windowPrefabs = GetWindowPrefabsById(id);
        string key = id.Substring(1, 1);//TODO: Add values more than 9
        Window windowPrefab = GetWindowPrefabByKey(key, windowPrefabs);
        ShowOrEnqueue(windowPrefab);
    }  

    private Window[] GetWindowPrefabsById(string id)
    { 
        if (id.Substring(0, 1) == "s")
        {
            return _windowPrefabsSettings;
        }

        if (id.Substring(0, 1) == "f")
        {
            return _windowPrefabsFriends;
        }

        if (id.Substring(0, 1) == "i")
        {
            return _windowPrefabsInvites;
        }

        Debug.LogWarning("Uncorrect ID: " + id);
        return null;
    }

    private Window GetWindowPrefabByKey(string key, Window[] windowPrefabs)
    {
        if (key == "0")
        {
            return windowPrefabs[0];
        }

        if (key == "1")
        {
            return windowPrefabs[1];
        }

        if (key == "2")
        {
            return windowPrefabs[2];
        }

        if (key == "3")
        {
            return windowPrefabs[3];
        }

        Debug.LogWarning("Uncorrect key: " + key);
        return null;
    }
}
