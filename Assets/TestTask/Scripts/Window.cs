using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Window: MonoBehaviour
{
    [SerializeField] private WindowTag _tag;    
    [SerializeField] private Button _takeButton;
    
    private WindowCreatorBase _windowCreator;
    private const float _duration = 0.25f;

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

    public void Init(WindowCreatorBase windowCreator)
    {
        _windowCreator = windowCreator;
        transform.localScale = new Vector3(1, 0, 1);
        StartCoroutine(Show(_duration));
    }    

    public void Hide()
    {
        IsHidden = true;
        Tween tween = transform.DOScaleY(0, _duration);
        tween.OnComplete
        (
            () => Destroy(gameObject)
        );        
    }

    private IEnumerator Show(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.DOScaleY(1, _duration);
    }

    private void PressClose()
    {
        Hide();
        _windowCreator.PressClose();
    }
}
