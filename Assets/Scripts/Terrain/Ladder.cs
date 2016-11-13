using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Player")
		{
			Rigidbody2D playerBody = ((Rigidbody2D)(other.transform.GetComponent("Rigidbody2D")));
			playerBody.gravityScale = 0;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.tag == "Player")
		{
			Rigidbody2D playerBody = ((Rigidbody2D)(other.transform.GetComponent("Rigidbody2D")));
			playerBody.gravityScale = 1;
		}
	}
}
