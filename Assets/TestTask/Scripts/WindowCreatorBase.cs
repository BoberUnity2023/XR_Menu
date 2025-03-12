using UnityEngine;

public class WindowCreatorBase : MonoBehaviour
{
    [SerializeField] private QueueWindows _queueWindows;
    [SerializeField] protected Window[] _bonusWindowPrefabs;

    protected void AddWindow(int id)
    {
        _queueWindows.TryShow(_bonusWindowPrefabs[id]);
    }

    public void PressTake()
    {
        _queueWindows.Remove();
    }
}
