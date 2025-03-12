using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace XR_Menu
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private WindowData _data;
        [SerializeField] private WindowTag _tag;
        [SerializeField] private Button _takeButton;

        private WindowCreatorBase _windowCreator;        

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
            StartCoroutine(Show(_data.Duration));
        }

        public void Hide()
        {
            IsHidden = true;
            Debug.Log("Window " + gameObject.name + " was hidden");
            Tween tween = transform.DOScaleY(0, _data.Duration);
            tween.OnComplete
            (
                () => Destroy(gameObject)
            );
        }

        private IEnumerator Show(float duration)
        {
            yield return new WaitForSeconds(duration);
            Debug.Log("Window " + gameObject.name + " was shown");
            transform.DOScaleY(1, _data.Duration);
        }

        private void PressClose()
        {
            Hide();
            _windowCreator.PressClose();
        }
    }

}
