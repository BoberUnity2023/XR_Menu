using UnityEngine;

public class GazeUIPosition: MonoBehaviour
{
    [SerializeField] private Transform _gazeInteractorTransform;

    private void FixedUpdate()
    {
        FixedUpdate_Rotate();
        FixedUpdate_Move();
    }

    private void FixedUpdate_Rotate()
    {
        transform.LookAt(_gazeInteractorTransform);
    }

    private void FixedUpdate_Move()
    { 
        float x = transform.position.x;
        float y = _gazeInteractorTransform.position.y;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);        
    }
}
