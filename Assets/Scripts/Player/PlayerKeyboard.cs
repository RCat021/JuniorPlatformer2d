using UnityEngine;

public class PlayerKeyboard : MonoBehaviour
{
    [SerializeField] private Player _player;

    private const string MovementAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;
    private float _lastAxisValue = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            _player.Jump();
        }

        float movement = Input.GetAxisRaw(MovementAxis);

        if (movement != 0f)
        {
            _player.Move(movement);
        }

        float currentAxis = Input.GetAxisRaw(MovementAxis);

        if (_lastAxisValue == 0f && currentAxis != 0f)
        {
            _player.Move(movement);
        }

        if (_lastAxisValue != 0f && currentAxis == 0f)
        {
            _player.MoveStop();
        }

        _lastAxisValue = currentAxis;
    }
}

