using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControl", menuName = "Player/Player Control", order = 0)]
public class PlayerControl : ScriptableObject
{
    public bool isMoving { get; set; }
    public bool canMove { get; private set; }

    public Vector2 moveTarget { get; set; }

    public bool canInteract { get; private set; }

    public void Inicialization()
    {
        canMove = true;
        isMoving = false;

        canInteract = true;
    }

    public void EnablePlayer()
    {
        canMove = true;
        canInteract = true;
    }

    public void DisablePlayer()
    {
        canMove = false;
        canInteract = false;
    }
}