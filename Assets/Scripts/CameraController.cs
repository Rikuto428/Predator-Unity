﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {

        this.player = GameObject.Find("Circle");
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 playerPos = this.player.transform.position;
        if (playerPos.y >= 0 && playerPos.y <= 54) transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
		
	}
}
