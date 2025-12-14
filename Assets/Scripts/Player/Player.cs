using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(JumpController))]
[RequireComponent(typeof(MoverPhysical))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerAnimtion))]
[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(MoverRotation))]
[RequireComponent(typeof(Collector))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Collector _collector;
    private PlayerInputReader _inputReader;
    private JumpController _jumper;
    private MoverPhysical _mover;
    private GroundDetector _groundDetector;
    private PlayerAnimtion _animator;
    private MoverRotation _rotationMover;

    private void Awake()
    {
        _inputReader = GetComponent<PlayerInputReader>();
        _jumper = GetComponent<JumpController>();
        _mover = GetComponent<MoverPhysical>();
        _groundDetector = GetComponent<GroundDetector>();
        _animator = GetComponent<PlayerAnimtion>();
        _rotationMover = GetComponent<MoverRotation>();
        _collector = GetComponent<Collector>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _inputReader.OnMove += Move;
        _inputReader.OnMoveStop += MoveStop;
        _inputReader.OnJump += Jump;
        _collector.AddMoney += AddMoney;
    }
    
    private void OnDisable()
    {
        _inputReader.OnMove -= Move;
        _inputReader.OnMoveStop -= MoveStop;
        _inputReader.OnJump -= Jump;
        _collector.AddMoney -= AddMoney;
    }

    private void Move(float direction)
    {
        _animator.MoveAnimation(true);
        _mover.Move(direction);

        _rotationMover.FlipByDirection(direction);
    }

    private void MoveStop()
    {
        _animator.MoveAnimation(false);
        _mover.Stop();
    }

    private void Jump()
    {
        if(_groundDetector.RequestGrounded())
            _jumper.Jump();
    }

    private void AddMoney()
    {
        _wallet.AddMoney();
    }
}
