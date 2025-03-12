using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CanvasMove : MonoBehaviour
{
    [SerializeField] private Transform _gazeInteractorTransform;    
    [SerializeField] private Transform _canvasTransform;
    private Vector3 _previousPosition;
    private const float _interval = 3;
    private const float _moveDuration = 0.25f;
    private const float _moveDistance = 1;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _previousPosition = _gazeInteractorTransform.position;
        StartCoroutine(WaitInterval(_interval));
    }

    private IEnumerator WaitInterval(float time)
    {
        yield return new WaitForSeconds(time);
        float distance = Vector3.Distance(_gazeInteractorTransform.position, _previousPosition);
        if (distance > _moveDistance)
        {
            _previousPosition = _canvasTransform.position;
            Rotate();
            Move();
        }
        StartCoroutine(WaitInterval(_interval));        
    }

    private void Move()
    {
        float x = TargetPosition.x;
        float y = _gazeInteractorTransform.position.y;
        float z = TargetPosition.z;
        Vector3 end = new Vector3(x, y, z);        
        _canvasTransform.DOMove(end, _moveDuration);
    }

    private void Rotate()
    {  
        float x = -_gazeInteractorTransform.forward.x;        
        float z = -_gazeInteractorTransform.forward.z;
        Vector3 offset = new Vector3(x, 0f, z);
        float rotY = Vector3.SignedAngle(Vector3.back, offset, Vector3.up);
        _canvasTransform.rotation = Quaternion.Euler(0f, rotY, 0f);
    }

    Vector3 TargetPosition
    {
        get
        {
            return _gazeInteractorTransform.position + _gazeInteractorTransform.forward;
        }
    }
}
