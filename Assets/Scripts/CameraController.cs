using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;

	void Start () {

        this.player = GameObject.Find("Circle");
		
	}
	
	void Update () {

        Vector3 playerPos = this.player.transform.position;
        // カメラの中心にプレイヤーを置く（縦方向のステージ外は見せない）
        if (playerPos.y >= 0 && playerPos.y <= 54) transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
		
	}
}
