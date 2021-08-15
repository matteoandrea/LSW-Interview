using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    public readonly string isMoving = "IsMoving";
    public readonly string direction = "Direction";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetFloat(string name, float value, float time) => _animator.SetFloat(name, value, time, Time.deltaTime);
    public void SetFloat(string name, float value) => _animator.SetFloat(name, value);

    public void SetInt(string name, int value) => _animator.SetInteger(name, value);
    public void SetBool(string name, bool value) => _animator.SetBool(name, value);
    public void SetTrigger(string name) => _animator.SetTrigger(name);
}
