using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCreator : WindowCreator
{    
    [SerializeField] private Transform _initPositionTransform;    
    [SerializeField] protected Window[] _bonusWindowPrefabs;
    private Queue<Window> _queueWindowPrefabs = new Queue<Window>();
    private Window _activeWindow;

    private int _id;
    private const float _interval = 5;

    public bool IsFree => _activeWindow == null;    

    private void Start()
    {
        StartCoroutine(Waitinterval(_interval));
    }       

    public override void PressClose()
    {
        base.PressClose();
        Remove();
    }

    private IEnumerator Waitinterval(float time)
    {
        yield return new WaitForSeconds(time);
        
        
        if (_id < _bonusWindowPrefabs.Length)
        {
            AddWindow(_id);            
            _id++;
            StartCoroutine(Waitinterval(_interval));
        }        
    }

    private void AddWindow(int id)
    {
        TryShow(_bonusWindowPrefabs[id]);
    }

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

    public void Show(Window windowPrefab)
    {
        Vector3 position = _initPositionTransform.position;
        Quaternion rotation = _initPositionTransform.rotation;
        Transform parent = _initPositionTransform;
        _activeWindow = Instantiate(windowPrefab, position, rotation, parent);
        _activeWindow.Init(this);        
    }

    public void Remove()
    {
        _activeWindow.Hide();        

        if (_queueWindowPrefabs.Count > 0)
        {
            Show(_queueWindowPrefabs.Dequeue());
        }
    }
}
