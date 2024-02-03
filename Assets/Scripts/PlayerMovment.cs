using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;

    [SerializeField] private float speed = 5f;
    [SerializeField] float jumpForce = 400f;
    float horizontalMove = 0f;
    bool jump = false;

    private Rigidbody2D body;
    private Vector2 axisMovement;

    private void Awake()
    {
        body = transform.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("AnimState", 1);
    }

    private void Update()
    {
        //animator.SetBool("Grounded", controller.m_Grounded);
    }

    private void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        //Debug.Log(controller.m_Grounded);
        if (controller.m_Grounded)
        {
            animator.SetBool("Grounded", controller.m_Grounded);
        }
        else
        {
            animator.SetBool("Grounded", controller.m_Grounded);
            animator.SetTrigger("Jump");
        }
    }

    public void Jump()
    {
        jump = true;
        animator.SetTrigger("Jump");
    }

    public void Move(int position)
    {
        horizontalMove = position * speed;
        if (horizontalMove != 0)
        {
            animator.SetInteger("AnimState", 2);
        }
        else if (horizontalMove == 0)
        {
            animator.SetInteger("AnimState", 1);
        }
    }
}
