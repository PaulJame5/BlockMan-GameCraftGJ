using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
    public float speed;
    public float maxSpeed = 10;
    public float acceleration = 15;
    public float airDeceleration = 3f;

    [Space(10)]
    public LayerMask terrain;
    public float rayLength = 5;
    public float offsetVertical = 0.32f;
    public bool grounded;
    [Space(10)]
    public float jumpPower;

    public AudioClip jump;
    public AudioSource aud;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (speed > -maxSpeed)
            {
                if (grounded)
                {
                    speed += -acceleration * Time.deltaTime;
                }
                else
                {
                    speed += -acceleration/2 * Time.deltaTime;
                }
            }
            else 
            {
                speed = -maxSpeed;
            }

                
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (speed < maxSpeed)
            {
                if (grounded)
                {
                    speed += acceleration * Time.deltaTime;
                }
                else
                {
                    speed += acceleration/2 * Time.deltaTime;
                }
            }
            else
            {
                speed = maxSpeed;
            }
        }

        else
        {
            if (grounded)
            {
                speed = 0;
            }
            else
            {
                if(speed > 0.2f)
                {
                    speed -= airDeceleration * Time.deltaTime;
                }
                else if(speed < -.2f)
                {
                    speed -= airDeceleration * Time.deltaTime;
                }
                else
                {
                    speed = 0;
                }
            }
        }

        CheckSide();
        CheckGrounded();
        Jump();
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
	}


    void CheckGrounded()
    {
        
        grounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, terrain) ||
          Physics2D.Raycast(new Vector2(transform.position.x + offsetVertical, transform.position.y), Vector2.down, rayLength, terrain) ||
          Physics2D.Raycast(new Vector2(transform.position.x - offsetVertical, transform.position.y), Vector2.down, rayLength, terrain) ||
           Physics2D.Raycast(new Vector2(transform.position.x + (offsetVertical * 2), transform.position.y), Vector2.down, rayLength, terrain) ||
           Physics2D.Raycast(new Vector2(transform.position.x - (offsetVertical * 2), transform.position.y), Vector2.down, rayLength, terrain)
            ? true
            : false;
    }

    void CheckSide()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, rayLength * .7f, terrain) ||
           Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + offsetVertical * 2), Vector2.right * transform.localScale.x, rayLength * .7f, terrain) ||
           Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - offsetVertical * 2), Vector2.right * transform.localScale.x, rayLength * .7f, terrain))
        {
            speed = 0;
        }

        Debug.DrawRay(transform.position, Vector2.right * transform.localScale.x * rayLength * .7f, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + offsetVertical * 2), Vector2.right * transform.localScale.x * rayLength * .7f, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - offsetVertical * 2), Vector2.right * transform.localScale.x * rayLength * .7f, Color.red);
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
                aud.PlayOneShot(jump);
            }
        }

    }
}
