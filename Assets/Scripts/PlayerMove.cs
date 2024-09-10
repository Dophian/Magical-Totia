using System;
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
    public LayerMask groundLayer;

    // Events
    public event Action OnCollisionGround;

    private const string GROUND_LAYER = "Ground";

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(GROUND_LAYER))
        {
            Debug.Log("바닥에 충돌함");
        }
    }
}
