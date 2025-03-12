using System.Collections.Generic;
using UnityEngine;

public class TagWindowCreator : WindowCreator
{
    [SerializeField] private Transform _initPositionFirstTransform;
    [SerializeField] private Transform _initPositionSecondTransform;

    [SerializeField] private Window[] _windowPrefabsSettings;
    [SerializeField] private Window[] _windowPrefabsFriends;
    [SerializeField] private Window[] _windowPrefabsInvites;
    private Window _activeWindowFirst;
    private Window _activeWindowSecond;
    private Queue<Window> _queueWindowPrefabs = new Queue<Window>();

    public bool IsFree(int id)
    {
        if (id == 0)
        { 
            if (_activeWindowFirst == null)
                return true;

            if (_activeWindowFirst.IsHidden)
                return true;

            return false;
        }

        if (id == 1)
        {
            if (_activeWindowSecond == null)
                return true;

            if (_activeWindowSecond.IsHidden)
                return true;

            return false;
        }

        return false;
    }

    public override void PressClose()
    {
        base.PressClose();        
        if (_queueWindowPrefabs.Count > 0)
        {
            Debug.Log("_activeWindowFirst.IsHidden: " + _activeWindowFirst.IsHidden);
            Debug.Log("IsFree(0): " + IsFree(0));

            if (IsFree(0) || IsFree(1))
                TryShow(_queueWindowPrefabs.Dequeue());
        }
    }

    public bool TryShow(Window windowPrefab)
    {
        if (IsFree(0) || windowPrefab.Tag == _activeWindowFirst.Tag)
        {            
            if (!IsFree(0))
            {
                _activeWindowFirst.Hide(); 
            }
            ShowWindow(windowPrefab, 0);

            return true;
        }
        else
        {
            if (IsFree(1) || windowPrefab.Tag == _activeWindowSecond.Tag)
            {                
                if (!IsFree(1))
                {
                    _activeWindowSecond.Hide();
                }
                ShowWindow(windowPrefab, 1);

                return true;
            }
            Debug.Log("Окно " + windowPrefab.name + " добавлено в очередь");
            _queueWindowPrefabs.Enqueue(windowPrefab);
            return false;
        }
    }

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
            TryShow(windowPrefabs[0]);
        }

        if (id.Substring(1, 1) == "1")
        {
            TryShow(windowPrefabs[1]);
        }

        if (id.Substring(1, 1) == "2")
        {
            TryShow(windowPrefabs[2]);
        }

        if (id.Substring(1, 1) == "3")
        {
            TryShow(windowPrefabs[3]);
        }
    } 
    

    public void ShowWindow(Window windowPrefab, int positionId)
    {
        Transform _initPositionTransform = positionId == 0 ? _initPositionFirstTransform : _initPositionSecondTransform;

        Vector3 position = _initPositionTransform.position;//TODO!
        Quaternion rotation = _initPositionTransform.rotation;
        Transform parent = _initPositionTransform;
        if (positionId == 0)
        {
            _activeWindowFirst = Instantiate(windowPrefab, position, rotation, parent);
            _activeWindowFirst.Init(this);
        }
        if (positionId == 1)
        {
            _activeWindowSecond = Instantiate(windowPrefab, position, rotation, parent);
            _activeWindowSecond.Init(this);
        }
    }
}
