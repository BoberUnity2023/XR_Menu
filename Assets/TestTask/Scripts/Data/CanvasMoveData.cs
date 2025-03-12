using UnityEngine;

namespace XR_Menu
{
    [CreateAssetMenu(fileName = "CanvasMove", menuName = "Data/CanvasMoveData")]

    public class CanvasMoveData : ScriptableObject
    {
        [Tooltip("Time interval for update position")]
        [Range(0, 10)]
        [SerializeField] private float _interval;

        [Tooltip("Canvas movement time")]
        [Range(0, 1)]
        [SerializeField] private float _moveDuration;

        [Tooltip("Distance offset for updane position")]
        [Range(0, 10)]
        [SerializeField] private float _moveDistance;

        public float Interval => _interval;

        public float MoveDuration => _moveDuration;

        public float MoveDistance => _moveDistance;
    }
}

