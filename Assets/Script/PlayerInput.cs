using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static readonly string moveXAxisName = "Vertical";
    public static readonly string moveZAxisName = "Horizontal";
    public static readonly string fireAxisName = "Fire1";
    public float MoveX { get; private set; }
    public float MoveZ { get; private set; }
    public bool Fire { get; private set; }
    private void Update()
    {
        MoveX = Input.GetAxis(moveXAxisName);
        MoveZ = Input.GetAxis(moveZAxisName);
        Fire = Input.GetButton(fireAxisName);
    }
}
