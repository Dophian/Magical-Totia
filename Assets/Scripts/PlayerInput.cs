using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Input Axes
    private const string INPUT_HORIZONTAL = "Horizontal";
    private const string INPUT_JUMP = "Jump";
    private const string INPUT_FIRE = "Fire1";

    // Events
    public event Action<Vector2> OnPressMove;
    public event Action OnPressJump;
    public event Action OnPressFire;

    public Vector2 inputVec;

    public void Input()
    {
        float inputHorizontal = UnityEngine.Input.GetAxisRaw(INPUT_HORIZONTAL);
        inputVec = new Vector2(inputHorizontal, 0);

        if (inputVec != Vector2.zero)
        {
            OnPressMove?.Invoke(inputVec);
        }

        if (UnityEngine.Input.GetButtonDown(INPUT_JUMP))
        {
            OnPressJump?.Invoke();
        }

        if (UnityEngine.Input.GetButton(INPUT_FIRE))
        {
            OnPressFire?.Invoke();
        }
    }

    public Vector2 GetInputVector()
    {
        return inputVec;
    }
}
