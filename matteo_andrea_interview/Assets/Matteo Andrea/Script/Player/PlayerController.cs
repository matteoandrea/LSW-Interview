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

    [SerializeField] public PlayerInteract playerInteract;

    [Space(20)]

    private Camera _cam;
    private Vector2 _mousePos;

    private void Awake()
    {
        _cam = Camera.main;

        playerInteract.Awake();
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
        playerInteract.Update(_mousePos);
    }

    private void PressedMouse()
    {
        if (playerInteract.LookInteract != null && _playerControl.canInteract)
        {
            playerInteract.currentInteract = playerInteract.LookInteract;
            var target = playerInteract.currentInteract.targetLocaction;
            _playerMovement.Move(target.position);
        }
        else
        {
            var target = _cam.ScreenToWorldPoint(_mousePos);
            _playerMovement.Move(target);
            playerInteract.currentInteract = null;
        }
    }

    private void SetMousePos(Vector2 pos) => _mousePos = pos;
}
