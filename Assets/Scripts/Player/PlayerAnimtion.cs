using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimtion : MonoBehaviour
{
    public static readonly int _idRunAnimation = Animator.StringToHash("IsRun");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(bool isAnim)
    {
        _animator.SetBool(_idRunAnimation, isAnim);
    }
}
