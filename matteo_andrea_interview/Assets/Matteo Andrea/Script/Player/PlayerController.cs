using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PlayerControl _playerControl;

    [Space(20)]

    [SerializeField] private PlayerMovement _playerMovement;

    [Space(10)]

    [SerializeField] private PlayerInteract _playerInteract;

    [Space(20)]

    private Camera _cam;
    private Vector2 _mousePos;

    private void Awake()
    {
        _cam = Camera.main;

        _playerInteract.Awake();
    }

    private void OnEnable()
    {
        _input.MoveEvent += SetMousePos;
        _input.ClickEvent += PressedMouse;
    }

    private void OnDisable()
    {
        _input.MoveEvent -= SetMousePos;
        _input.ClickEvent -= PressedMouse;
    }

    private void Start()
    {
        _playerControl.Inicialization();
        _playerMovement.Start();
    }

    private void Update()
    {
        _playerInteract.Update(_mousePos);
    }

    private void PressedMouse()
    {
        if (_playerInteract.currentInteract != null && _playerControl.canInteract)
            _playerInteract.currentInteract.Interact();

        else
        {
            var target = _cam.ScreenToWorldPoint(_mousePos);
            _playerMovement.Move(target);
        }
    }

    private void SetMousePos(Vector2 pos) => _mousePos = pos;
}
