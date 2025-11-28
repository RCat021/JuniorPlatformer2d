using UnityEngine;

public class RotationMover : MonoBehaviour
{
    [SerializeField] protected float _rotationAngle = 180f;

    private Vector3 _defaultVector;
    private Vector3 _angleYVector;

    private void Start()
    {
        _defaultVector = Vector3.zero;
        _angleYVector = new Vector3(0, _rotationAngle, 0);
    }

    public void RotateToDefault()
    {
        Rotate(_defaultVector);
    }

    public void RotateToAngleY()
    {
        Rotate(_angleYVector);
    }

    private void Rotate(Vector3 target)
    {
        transform.rotation = Quaternion.Euler(target);
    }
}
