using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Component
    private PlayerMove playerMove;
    private PlayerInput playerInput;

    public Transform GrabPoint { get => grabPoint; }
    [SerializeField] private Transform grabPoint;

    [SerializeField] private Gun gun;

    private enum ViewSide
    {
        Left,
        Right,
    }
    private ViewSide lastViewSide = ViewSide.Right;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        playerInput.OnPressJump += playerMove.Jump;
        playerInput.OnPressMove += playerMove.Move;
        playerInput.OnPressMove += CharacterViewChange;
        playerInput.OnPressFire += gun.Fire;
    }

    private void Update()
    {
        playerInput.Input();
    }

    private void CharacterViewChange(Vector2 inputVec)
    {
        ViewSide currentViewSide = ViewSide.Left;

        if (!Mathf.Approximately(inputVec.x, 0))
        {
            currentViewSide = inputVec.x > 0 ? ViewSide.Right : ViewSide.Left;
        }
        else
        {
            return;
        }

        if (currentViewSide == lastViewSide)
        {
            return;
        }

        switch (currentViewSide)
        {
            case ViewSide.Left:
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                break;
            case ViewSide.Right:
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                break;
        }

        lastViewSide = currentViewSide;
    }

    private void FixedUpdate()
    {
        playerMove.Move(playerInput.GetInputVector());
    }

    private void ChangeWeapon()
    {

    }
}
