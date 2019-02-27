using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed = 5;

    void Start () {

        this.rigid2D = GetComponent<Rigidbody2D>();

    }
	
	void Update () {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        this.rigid2D.velocity = direction * this.speed;

    }
}
