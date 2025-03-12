using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace XR_Menu
{
    public class CanvasMove : MonoBehaviour
    {
        [SerializeField] private CanvasMoveData _data;
        [SerializeField] private Transform _gazeInteractorTransform;
        [SerializeField] private Transform _canvasTransform;
        private Vector3 _previousPosition;        

        public void Init()
        {
            _previousPosition = _gazeInteractorTransform.position;
            WaitIntervalAsync(_data.Interval);
        }

        private async void WaitIntervalAsync(float time)
        {
            await Task.Delay(TimeSpan.FromSeconds(time));
            
            if (DistanceToCanvas > _data.MoveDistance)
            {
                _previousPosition = _canvasTransform.position;
                Rotate();
                Move();
            }
            WaitIntervalAsync(_data.Interval);
        }

        private void Move()
        {
            float x = TargetPosition.x;
            float y = _gazeInteractorTransform.position.y;
            float z = TargetPosition.z;
            Vector3 end = new Vector3(x, y, z);
            _canvasTransform.DOMove(end, _data.MoveDuration);
        }

        private void Rotate()
        {
            float x = -_gazeInteractorTransform.forward.x;
            float z = -_gazeInteractorTransform.forward.z;
            Vector3 offset = new Vector3(x, 0f, z);
            float rotY = Vector3.SignedAngle(Vector3.back, offset, Vector3.up);
            _canvasTransform.rotation = Quaternion.Euler(0f, rotY, 0f);
        }

        private Vector3 TargetPosition
        {
            get
            {
                return _gazeInteractorTransform.position + _gazeInteractorTransform.forward;
            }
        }

        private float DistanceToCanvas
        {
            get
            {
                return Vector3.Distance(_gazeInteractorTransform.position, _previousPosition);
            }
        }
    }

}

