using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float heroSpeed;
    public float jumpForce;
    public Transform groundTester;
    public LayerMask layersToTest;

    Animator anim;

    Rigidbody2D rb2D;

    bool dirToRight = true;

    private bool onTheGround;
    private float radius = 0.1f;

    private void Start()
    {
        anim = GetComponent<Animator>();

        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        onTheGround = Physics2D.OverlapCircle(groundTester.position, radius, layersToTest);

        float horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("jump");
        }

        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        //{
        //    anim.SetTrigger("melee");
        //}

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("shoot");
        }

        anim.SetFloat("speed", Mathf.Abs(horizontalMove));

        rb2D.velocity = new Vector2(horizontalMove * heroSpeed, rb2D.velocity.y);

        if (horizontalMove < 0 && dirToRight)
        {
            Flip();
        }
        
        if (horizontalMove > 0 && !dirToRight)
        {
            Flip();
        }

    }

    private void Flip()
    {
        dirToRight = !dirToRight;

        Vector3 heroScale = gameObject.transform.localScale;

        heroScale.x *= -1;

        gameObject.transform.localScale = heroScale;
    }
}
