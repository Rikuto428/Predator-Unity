using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
                		
	}
	
	// Update is called once per frame
	void Update () {

        // 画面タッチでゲームシーンのロード
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("GameScene");
        }

    }
}
