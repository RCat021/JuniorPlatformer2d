using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(RigidbodyMover))]
[RequireComponent(typeof(PlayerIsGround))]
[RequireComponent(typeof(PlayerAnimtion))]
[RequireComponent(typeof(PlayerKeyboard))]
[RequireComponent(typeof(RotationMover))]
[RequireComponent(typeof(Collector))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Collector _collector;
    private PlayerKeyboard _playerKeyboard;
    private PlayerJump _jump;
    private RigidbodyMover _mover;
    private PlayerIsGround _isGround;
    private PlayerAnimtion _animator;
    private RotationMover _rotationMover;

    private void Awake()
    {
        _playerKeyboard = GetComponent<PlayerKeyboard>();
        _jump = GetComponent<PlayerJump>();
        _mover = GetComponent<RigidbodyMover>();
        _isGround = GetComponent<PlayerIsGround>();
        _animator = GetComponent<PlayerAnimtion>();
        _rotationMover = GetComponent<RotationMover>();
        _collector = GetComponent<Collector>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _playerKeyboard.OnMove += Move;
        _playerKeyboard.OnMoveStop += MoveStop;
        _playerKeyboard.OnJump += Jump;
        _collector.AddMoney += AddMoney;
    }
    
    private void OnDisable()
    {
        _playerKeyboard.OnMove -= Move;
        _playerKeyboard.OnMoveStop -= MoveStop;
        _playerKeyboard.OnJump -= Jump;
        _collector.AddMoney -= AddMoney;
    }

    private void Move(float direction)
    {
        _animator.MoveAnimation(true);
        _mover.Move(direction);

        if (direction < 0)
            _rotationMover.RotateToAngleY();
        else
            _rotationMover.RotateToDefault();
    }

    private void MoveStop()
    {
        _animator.MoveAnimation(false);
        _mover.Stop();
    }

    private void Jump()
    {
        if(_isGround.IsGrounded())
            _jump.Jump();
    }

    private void AddMoney()
    {
        _wallet.AddMoney();
    }
}
