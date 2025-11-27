using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimtion : MonoBehaviour
{
    private Animator _animator;
    public static readonly int _idRunAnimation = Animator.StringToHash("IsRun");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(bool isAnim)
    {
        _animator.SetBool(_idRunAnimation, isAnim);
    }
}
