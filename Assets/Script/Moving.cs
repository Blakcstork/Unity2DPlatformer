using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{


    public float movePower = 10f;
    public float jumpPower = 10f;
    public bool isGround = false;
    bool isJumping = false;

    public int score = 0;

    Rigidbody2D rigid;
    

    Vector3 movement;





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        else if (collision.gameObject.tag == "item")
        {
            score++;
            collision.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
            }
        }

    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }




    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }

        this.transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        if (!isJumping)
            return;
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
        isGround = false;

    }
}
