using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOf : Player {

	public bool touchingWall;
	float checkRadius = 2.30f;
	public Transform wallCheck;
	public LayerMask whatisGround;
	public LayerMask whatisWall;
	// Use this for initialization
	void Start () {
	}

	void FixedUpdate(){
		touchingWall = Physics2D.OverlapCircle (wallCheck.position, checkRadius, whatisWall);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
	}

}
