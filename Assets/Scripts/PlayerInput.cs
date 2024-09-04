using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnPressJump;
    public event Action<Vector2> OnPressMove;

    private const string INPUT_HORIZONTAL = "Horizontal";
    private float inputHorizontal;
    private const string INPUT_JUMP = "Jump";
    private bool inputJump;

    public Vector2 inputVec;

    public void Input()
    {
        inputHorizontal = UnityEngine.Input.GetAxisRaw(INPUT_HORIZONTAL);
        inputVec = new Vector2(inputHorizontal, 0);

        if (inputVec != Vector2.zero)
        {
            OnPressMove?.Invoke(inputVec);
        }

        if (UnityEngine.Input.GetButtonDown(INPUT_JUMP))
        {
            OnPressJump?.Invoke();
        }
    }

    public Vector2 GetInputVector()
    {
        return inputVec;
    }
}
