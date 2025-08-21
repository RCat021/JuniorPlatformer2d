using UnityEngine;

public class PlayerMove : BaseMovement
{
    [SerializeField] private float _speed = 5f;

    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void Move(float direction)
    {
        Rigidbody.velocity = new Vector2(direction * _speed, Rigidbody.velocity.y);

        _sprite.flipX = direction < 0;
    }
}
