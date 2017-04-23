using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    private Collision2D collision;
    private GameObject grabbedBlock;
    private Vector3 dist;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && (collision != null))
        {
            Debug.Log("Grab " + collision.collider.name);

            grabbedBlock = collision.collider.gameObject;
            grabbedBlock.GetComponent<Block>().setGrabbed(true);
            dist = collision.collider.gameObject.transform.position - transform.position;
        }

        if (Input.GetKeyUp(KeyCode.Space) && grabbedBlock != null)
        {
            Debug.Log("Release Block");

            grabbedBlock.GetComponent<Block>().setGrabbed(false);
            grabbedBlock = null;
        }

        if (grabbedBlock != null)
        {
            grabbedBlock.transform.position = transform.position + dist;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Block")
        {
            this.collision = collision;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Block")
        {
            this.collision = null;
        }
    }

}
