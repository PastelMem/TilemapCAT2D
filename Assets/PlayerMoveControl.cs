using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    
    public float speed = 5f;
    public GatherInput gatherInput;
    private Rigidbody2D rigidbody2D2;

    public int  jumpForce = 5;
    private int direction = 1;

    public Animator animator;
    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    private bool grounded = false;
    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

 private void SetAnimatorValues() 
    {
        animator.SetFloat("speed", Mathf.Abs(rigidbody2D2.velocity.x));
        animator.SetFloat("vspeed", rigidbody2D2.velocity.y);
        animator.SetBool("Grounded", grounded);
    }
    // Update is called once per frame
    void Update()
    {
        SetAnimatorValues();
        CheckStatus();
        move();
        
    }

    private void FixedUpdate() {
        flip();
        JumpPlayer();
    }
    private void move(){
        rigidbody2D2.velocity = new Vector2(speed * gatherInput.value, rigidbody2D2.velocity.y);
    }

    private void JumpPlayer() 
    {
        if (gatherInput.jumpInput && grounded)
        {
            rigidbody2D2.velocity = new Vector2(gatherInput.value * speed, jumpForce);
        }
        gatherInput.jumpInput = false;
    }

    private void flip(){
        if(gatherInput.value * direction < 0) 
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
    private void CheckStatus()
    {

        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        grounded = leftCheckHit;
        Debug.Log(grounded);

    }
}
