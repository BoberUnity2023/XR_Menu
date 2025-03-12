using UnityEngine;

public abstract class WindowCreatorBase : MonoBehaviour
{
    public abstract void PressClose();

    protected void ShowWindow(Window windowPrefab, Slot slot)
    {
        Vector3 position = slot.Transform.position;
        Quaternion rotation = slot.Transform.rotation;
        Transform parent = slot.Transform;
        slot.ActiveWindow = Instantiate(windowPrefab, position, rotation, parent);
        slot.ActiveWindow.Init(this);
    }
}
