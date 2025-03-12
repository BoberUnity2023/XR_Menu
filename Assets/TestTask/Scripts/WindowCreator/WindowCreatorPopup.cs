using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCreatorPopup : WindowCreatorBase
{    
    [SerializeField] private Transform _slotTransform;    
    [SerializeField] protected Window[] _windowPrefabs;
    private Queue<Window> _queueWindowPrefabs = new Queue<Window>();    
    private Slot _slot;
    private int _number;
    private const float _interval = 5;     
        
    public void Init()
    {
        _slot = new Slot(_slotTransform);
        StartCoroutine(Waitinterval(_interval));
    }

    public override void PressClose()
    {
        _slot.ActiveWindow.Hide();

        if (_queueWindowPrefabs.Count > 0)
        {
            ShowWindow(_queueWindowPrefabs.Dequeue(), _slot);
        }
    }

    private IEnumerator Waitinterval(float time)
    {
        yield return new WaitForSeconds(time);        
        
        if (_number < _windowPrefabs.Length)
        {            
            ShowOrEnqueue(_windowPrefabs[_number]);
            _number++;
            StartCoroutine(Waitinterval(_interval));
        }        
    }

    private void ShowOrEnqueue(Window windowPrefab)
    {
        if (_slot.IsFree)
        {
            ShowWindow(windowPrefab, _slot);            
        }
        else
        {
            _queueWindowPrefabs.Enqueue(windowPrefab);
            Debug.Log("Popup window " + windowPrefab.name + " was added to queue");            
        }
    }     
}
