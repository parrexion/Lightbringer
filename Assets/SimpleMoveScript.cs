using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveScript : MonoBehaviour {

    public float speed = 1f;


	void FixedUpdate () {
         Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
         GetComponent<Rigidbody2D>().velocity=targetVelocity * speed;
    }

}
