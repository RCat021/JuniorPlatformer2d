using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(PlayerMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private PlayerJump _jump;
    private PlayerMove _move;
    private Rigidbody2D _rigidbody;

    private Animator _animator;
    private string _nameRunAnimation = "IsRun";

    private void Awake()
    {
        _jump = GetComponent<PlayerJump>();
        _move = GetComponent<PlayerMove>();
        _animator = GetComponent<Animator>();

        _rigidbody = GetComponent<Rigidbody2D>();
        _jump.SetRigidbody(_rigidbody);
        _move.SetRigidbody(_rigidbody);
    }

    public void Move(float direction)
    {
        _animator.SetBool(_nameRunAnimation, true);
       _move.Move(direction);
    }

    public void MoveStop()
    {
        _animator.SetBool(_nameRunAnimation, false);
    }

    public void Jump()
    {
        _jump.Jump();
    }

    public void AddMoney(int amount)
    {
        _wallet.AddMoney(amount);
    }
}
