using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class MyPlayerMovement : MonoBehaviour
{
    [Header("Player Property")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpForce;

    private float currentPlayerSpeed;
    private Rigidbody2D rb;
    private bool groundCheck;

    [SerializeField] private GameObject animObject;
    [SerializeField] private Animator animator;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = animObject.GetComponent<SpriteRenderer>();
        animator = animObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
            rb.velocity = new Vector2(currentPlayerSpeed * Time.deltaTime, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(currentPlayerSpeed));
    }
    public void RightMove()
    {
        currentPlayerSpeed = playerSpeed;       
        sr.flipX = false;
    }                    
    public void LeftMove()
    {
        currentPlayerSpeed = -playerSpeed;
        sr.flipX = true;    
    }
    public void StopMove()
    {
        currentPlayerSpeed = 0f;  
    }
    public void Jump()
    {
        if(groundCheck)
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, playerJumpForce);          //rb.velocity.x - не меняет значение х
            groundCheck = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        groundCheck = true;

        if(collision.gameObject.tag == "water")
        {
            transform.position = new Vector2(0,0);
        }
    }
    
}
