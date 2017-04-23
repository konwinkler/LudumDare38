using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public GameObject blur;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setGrabbed(bool isGrabbed)
    {
        blur.GetComponent<SpriteRenderer>().enabled = isGrabbed;
    }
}
