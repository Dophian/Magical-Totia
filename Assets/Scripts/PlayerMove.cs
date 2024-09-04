using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    // Components
    private Rigidbody2D rigid;

    // Properties
    public float speed = 200f;
    public float jumpStrength = 15f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 inputVec)
    {
        Vector2 moveVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.velocity = new Vector2(moveVec.x, rigid.velocity.y);
    }

    public void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.velocity = new Vector2(rigid.velocity.x, jumpStrength);
    }
}
