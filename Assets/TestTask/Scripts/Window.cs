using UnityEngine;
using UnityEngine.UI;

public class Window: MonoBehaviour
{
    [SerializeField] private WindowTag _tag;    
    [SerializeField] private Button _takeButton;
    
    private WindowCreator _windowCreator;

    public WindowTag Tag => _tag;

    public bool IsHidden { get; private set; }

    private void Start()
    {
        _takeButton.onClick.AddListener(PressClose);
    }

    private void OnDestroy()
    {
        _takeButton.onClick.RemoveAllListeners();
    }

    public void Init(WindowCreator windowCreator)
    {
        _windowCreator = windowCreator;
    }

    public void Hide()
    {
        IsHidden = true;
        Destroy(gameObject);
    }

    private void PressClose()
    {
        Hide();
        _windowCreator.PressClose();
    }
}
