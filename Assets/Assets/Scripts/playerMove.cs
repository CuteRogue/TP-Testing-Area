using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
	Animator anim;
	float speed;
	float turnSpeed;
	bool onWall;

	void Awake () {
		anim = GetComponent<Animator>();
		onWall = false;
	}

	void Update () {
		speed = Input.GetAxisRaw ("Vertical");
		turnSpeed = Input.GetAxisRaw ("Horizontal");
		if (Input.GetKey(KeyCode.LeftShift)) {
			speed *= 2;
		}
		anim.SetFloat ("speed", speed);
		anim.SetFloat ("turnSpeed", turnSpeed);

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool("isJumping", true);
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			onWall = !onWall;
		}
		
		anim.SetBool("onWall", onWall);

		if (onWall) {
			// do something
		}
		else {
			if (speed <= 1) {
				transform.Rotate (new Vector3 (0, turnSpeed, 0));
			}
		}
	}
}
