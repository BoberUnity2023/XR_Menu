using UnityEngine;

namespace XR_Menu
{
    [CreateAssetMenu(fileName = "Window", menuName = "Data/WindowData")]

    public class WindowData : ScriptableObject
    {
        [Tooltip("Show/Hide animation time")]
        [Range(0, 1)]
        [SerializeField] private float _duration;

        public float Duration => _duration;
    }
}

