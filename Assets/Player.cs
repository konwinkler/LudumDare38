using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Sprite eyesOpen;
    public Sprite eyesClosed;
    public GameObject eyes;
    private float eyesClosedTime;
    private float jumpCoolDown;
    public float jumpForce = 5.6f;
    private bool grounded = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        updateEyes();
        updateMovement();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach(ContactPoint2D contact in collision.contacts)
        {
            Debug.Log("Contact " + contact.point + " p " + transform.position);
            if (contact.point.y <= (transform.position.y - 0.3f) &&
                contact.point.x >= (transform.position.x - 0.2f) &&
                contact.point.x <= (transform.position.x + 0.2f))
            {
                Debug.Log("Grounded " + contact.point + " p " + transform.position);
                grounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    private void updateMovement()
    {
        var rb = GetComponent<Rigidbody2D>();

        if (jumpCoolDown >= 0)
        {
            jumpCoolDown -= Time.deltaTime;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCoolDown = .5f;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-3f, rb.velocity.y);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(3f, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y); 
        }

    }

    private void updateEyes()
    {
        if (eyesClosedTime >= 0)
        {
            eyesClosedTime -= Time.deltaTime;
        }
        else
        {
            SpriteRenderer sr = eyes.GetComponent<SpriteRenderer>();
            sr.sprite = eyesOpen;
        }

        if (UnityEngine.Random.Range(1, 150) == 1)
        {
            Debug.Log("Close eyes.");
            SpriteRenderer sr = eyes.GetComponent<SpriteRenderer>();
            sr.sprite = eyesClosed;
            eyesClosedTime = 0.5f;
        }
    }

}
