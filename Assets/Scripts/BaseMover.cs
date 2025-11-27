using UnityEngine;

public class BaseMover : MonoBehaviour
{
    [SerializeField] protected float _rotationAngle = 180f;

    public void RotateToDefault()
    {
        Rotate(Vector3.zero);
    }

    public void RotateToAngleY()
    {
        Rotate(new Vector3(0, _rotationAngle, 0));
    }

    private void Rotate(Vector3 target)
    {
        transform.rotation = Quaternion.Euler(target);
    }
}
