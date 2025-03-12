using UnityEngine;
using UnityEngine.UI;

public class Window: MonoBehaviour
{
    [SerializeField] private WindowTag _tag;    
    [SerializeField] private Button _takeButton;

    private QueueWindows _queueWindows;
    private TagWindowCreator _tagWindowCreator;
    private WindowPlace _windowPlace;

    public WindowTag Tag => _tag;

    private void Start()
    {
        _takeButton.onClick.AddListener(PressClose);
    }

    private void OnDestroy()
    {
        _takeButton.onClick.RemoveAllListeners();
    }

    public void Init(QueueWindows queueWindows, TagWindowCreator tagWindowCreator = null, WindowPlace windowPlace = null)
    {
        _queueWindows = queueWindows;
        _tagWindowCreator = tagWindowCreator;
    }

    public void Hide()
    {
        Destroy(gameObject);
    }

    private void PressClose()
    {
        _queueWindows.Remove();
        Hide();
        if (_tagWindowCreator != null)
        {
            _tagWindowCreator.PressTake(_queueWindows);
        }
    }
}
