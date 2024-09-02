using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

    public Vector2 inputVec;
    public float speed;
    public float jumpStrength;

    private const string INPUT_HORIZONTAL= "Horizontal";
    private float inputHorizontal;
    private const string INPUT_JUMP = "Jump";
    private bool inputJump;

    private enum ViewSide
    {
        Left,
        Right,
    }
    private ViewSide lastViewSide = ViewSide.Right;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Input();
    }

    private void Input()
    {
        inputHorizontal = UnityEngine.Input.GetAxisRaw(INPUT_HORIZONTAL);
        inputVec = new Vector2(inputHorizontal, 0);

        ViewSide currentViewSide = ViewSide.Left;

        if (inputVec.x != 0)
        {
            currentViewSide = inputVec.x > 0 ? ViewSide.Right : ViewSide.Left;
        }
        else
        {
            currentViewSide = lastViewSide;
        }
        
        if (currentViewSide != lastViewSide)
        {
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

        if (UnityEngine.Input.GetButtonDown(INPUT_JUMP))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.velocity = new Vector2(rigid.velocity.x, jumpStrength);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.velocity = new Vector2(moveVec.x, rigid.velocity.y);
    }
}
