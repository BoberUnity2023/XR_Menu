using UnityEngine;

namespace XR_Menu
{
    [CreateAssetMenu(fileName = "WindowCreatorNormal", menuName = "Data/WindowCreatorNormalData")]
    public class WindowCreatorNormalData : ScriptableObject
    {
        [Tooltip("Prefabs of the Settings window")]
        [SerializeField] private Window[] _windowPrefabsSettings;
        [Tooltip("Prefabs of the Friends window")]
        [SerializeField] private Window[] _windowPrefabsFriends;
        [Tooltip("Prefabs of the Invites window")]
        [SerializeField] private Window[] _windowPrefabsInvites;

        public Window[] WindowPrefabsSettings => _windowPrefabsSettings;

        public Window[] WindowPrefabsFriends => _windowPrefabsFriends;

        public Window[] WindowPrefabsInvites => _windowPrefabsInvites;
    }
}

