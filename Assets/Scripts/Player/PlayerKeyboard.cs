using UnityEngine;
using static PlayerKeyboard;

public class PlayerKeyboard : MonoBehaviour, IPlayerInput
{
    private const string MovementAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;

    public event System.Action<float> OnMove;
    public event System.Action OnMoveStop;
    public event System.Action OnJump;

    private float _lastAxisValue = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            OnJump?.Invoke();

        float current = Input.GetAxisRaw(MovementAxis);

        if (current != 0f)
            OnMove?.Invoke(current);

        if (_lastAxisValue != 0f && current == 0f)
            OnMoveStop?.Invoke();

        _lastAxisValue = current;
    }

    public interface IPlayerInput
    {
        event System.Action<float> OnMove;
        event System.Action OnMoveStop;
        event System.Action OnJump;
    }
}

