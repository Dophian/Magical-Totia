using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public Vector3 rigidVelocity;
    Rigidbody2D rigidbody;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetWalkTrigger();
        rigidVelocity = rigidbody.velocity;
    }

    public void SetWalkTrigger()
    {
        if (rigidbody.velocity.normalized.x == 0)
            animator.SetBool("isWalking", false);
        else
            animator.SetBool("isWalking", true);

        if (Input.GetButtonDown("Jump"))
            animator.SetBool("isJumping", true);
    }

}
    