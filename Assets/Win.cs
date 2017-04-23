using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y >= 3.5f && 
          (player.transform.position.x <= -1f ||
           player.transform.position.x >= 1f))
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
	}

}
