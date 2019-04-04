using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour {

	void Start () {
                		
	}
	
	void Update () {

        // 画面タッチでゲームシーンのロード
        if (Input.GetMouseButton(0)) SceneManager.LoadScene("GameScene");

    }
}
