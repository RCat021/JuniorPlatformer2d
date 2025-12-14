using UnityEngine;

public class MoverRotation : MonoBehaviour
{
    public void FlipByDirection(Vector2 target)
    {
        float direction = transform.position.x - target.x;

        FlipByDirection(direction);
    }

     public void FlipByDirection(float direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (direction > 0 ? 1 : -1);
        transform.localScale = scale;
    }
}
