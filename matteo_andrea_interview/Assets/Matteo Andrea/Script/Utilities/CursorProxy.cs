using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CursorProxy", menuName = "Util/CursorProxy", order = 0)]
public class CursorProxy : ScriptableObject
{
    public void HideCursor() => Cursor.lockState = CursorLockMode.Locked;
    
    public void ShowCursor() => Cursor.lockState = CursorLockMode.Confined;
}

