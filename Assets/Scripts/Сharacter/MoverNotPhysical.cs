using UnityEngine;

public class MoverNotPhysical : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    public void Move(Vector3 target) 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
