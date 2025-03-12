using UnityEngine;

namespace XR_Menu
{
    [CreateAssetMenu(fileName = "WindowCreatorPopup", menuName = "Data/WindowCreatorPopupData")]
    public class WindowCreatorPopupData : ScriptableObject
    {
        [Tooltip("Prefabs of the Bonuses window")]
        [SerializeField] private Window[] _windowPrefabs;

        [Tooltip("Time interval for create popup window")]
        [SerializeField] private float _interval;

        public Window[] WindowPrefabs => _windowPrefabs;   
        
        public float Interval => _interval;
    }
}

