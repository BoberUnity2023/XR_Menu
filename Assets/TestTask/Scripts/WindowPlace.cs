using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPlace : MonoBehaviour
{
    /*[SerializeField] private TagWindowCreator _tagWindowCreator;
    [SerializeField] private Transform _initPositionTransform;
    private Window _activeWindow;

    public bool IsFree => _activeWindow == null;

    public WindowTag Tag { get; private set; }

    public void Show(Window windowPrefab)
    {
        Vector3 position = _initPositionTransform.position;
        Quaternion rotation = _initPositionTransform.rotation;
        Transform parent = _initPositionTransform;
        _activeWindow = Instantiate(windowPrefab, position, rotation, parent);
        _activeWindow.Init(null, _tagWindowCreator, this);
        Tag = windowPrefab.Tag;
    }

    public void Hide()
    {
        _activeWindow.Hide();
    }*/
}
