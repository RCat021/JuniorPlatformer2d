using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerIsGround))]
[RequireComponent(typeof(PlayerAnimtion))]
public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerKeyboard _playerKeyboard;

    private PlayerJump _jump;
    private PlayerMover _move;
    private PlayerIsGround _isGround;
    private PlayerAnimtion _animator;

    private int _priceMoney = 1;

    private void Awake()
    {
        _jump = GetComponent<PlayerJump>();
        _move = GetComponent<PlayerMover>();
        _isGround = GetComponent<PlayerIsGround>();
        _animator = GetComponent<PlayerAnimtion>();
    }

    private void OnEnable()
    {
        _playerKeyboard.OnMove += Move;
        _playerKeyboard.OnMoveStop += MoveStop;
        _playerKeyboard.OnJump += Jump;
    }
    
    private void OnDisable()
    {
        _playerKeyboard.OnMove -= Move;
        _playerKeyboard.OnMoveStop -= MoveStop;
        _playerKeyboard.OnJump -= Jump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            AddMoney(_priceMoney);
            money.Desroy();
        }
    }

    public void Move(float direction)
    {
        _animator.MoveAnimation(true);
        _move.Move(direction);

        if (direction < 0)
            _move.RotateToAngleY();
        else
            _move.RotateToDefault();

    }

    public void MoveStop()
    {
        _animator.MoveAnimation(false);
    }

    public void Jump()
    {
        if(_isGround.IsGrounded())
            _jump.Jump();
    }

    public void AddMoney(int amount)
    {
        _wallet.AddMoney(amount);
    }
}
