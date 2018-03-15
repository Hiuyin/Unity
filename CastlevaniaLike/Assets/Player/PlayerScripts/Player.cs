using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public Rigidbody2D rb;
	public bool isGrounded;
	protected int runSpeed;
	protected int walkSpeed;
	protected int jumpPower;
	protected bool wall;
	private SideOf near;
	void Awake()
    {
		//rb = GetComponent<Rigidbody2D> ();
    }
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		isGrounded = true;
		runSpeed = 25;
		walkSpeed = 10;
		jumpPower = 35;
		wall = near.touchingWall;
	
	}
	
	// Update is called once per frame
	void Update () {
		Movimento ();
	}

	void FixedUpdate(){
		//Movimento ();
	}

    void Movimento()
    {
		if (Input.GetKey ("a")) {
			Vector2 velocity;
			velocity = rb.velocity;
			velocity.x = -walkSpeed;
			rb.velocity = velocity;
		}
		if (Input.GetKeyUp ("a")) {
			Vector2 velocity;
			velocity = rb.velocity;
			velocity.x = 0;
			rb.velocity = velocity;
		}
		if (Input.GetKey ("d")) {
			Vector2 velocity;
			velocity = rb.velocity;
			velocity.x = walkSpeed;
			rb.velocity = velocity;
		}
		if (Input.GetKeyUp ("d")) {
			Vector2 velocity;
			velocity = rb.velocity;
			velocity.x = 0;
			rb.velocity = velocity;
		}
		if (Input.GetKeyDown ("space") && isGrounded && !wall ) {
			rb.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
		}
    }
	void OnCollisionEnter2D(Collision2D col){
		var direction = transform.InverseTransformPoint (col.transform.position);
		if (direction.x > 0f) {
			print ("Bateu na direita");
		} else if (direction.x < 0f) {
			print ("bateu na esquerda");
		}
		if (col.gameObject.tag == "Ground" ) {
			isGrounded = true;
		}
	}	
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ground" )  {
			isGrounded = false;
		}
	}
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Ground" && wall) {
			this. isGrounded = true;
		}
		this. isGrounded = true;
	}



}
