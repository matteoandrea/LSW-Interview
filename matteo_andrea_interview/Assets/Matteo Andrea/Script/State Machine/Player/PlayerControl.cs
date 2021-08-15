using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControl", menuName = "Player/Player Control", order = 0)]
public class PlayerControl : ScriptableObject
{
    [Header("Movement")]
    public bool canMove;
    public bool isMoving;
    public Vector2 moveTarget;

    [Space(10)]

    [Header("Interacion")]
    public bool canInteract;

    public void Inicialization()
    {
        canMove = true;
        isMoving = false;

        canInteract = true;
    }
}