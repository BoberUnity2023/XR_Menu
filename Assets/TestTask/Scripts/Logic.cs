using UnityEngine;

namespace XR_Menu
{
    public class Logic : MonoBehaviour
    {
        [SerializeField] private CanvasMove _canvasMove;
        [SerializeField] private WindowCreatorPopup _windowCreatorPopup;
        [SerializeField] private WindowCreatorNormal _windowCreatorNormal;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _canvasMove.Init();
            _windowCreatorPopup.Init();
            _windowCreatorNormal.Init();
        }
    }
}

