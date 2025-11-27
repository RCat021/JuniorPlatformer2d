using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : BaseMover
{
    [SerializeField] private float _speed = 2f;
    public void Move(Vector3 target) 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
