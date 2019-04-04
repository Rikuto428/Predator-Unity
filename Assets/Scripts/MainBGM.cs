using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBGM : MonoBehaviour {

    public bool DontDestroyEnabled = true;

    void Start () {

        // メインBGM
        GetComponent<AudioSource>().Play();

        // Sceneを遷移してもオブジェクトが消えないようにする（メインBGMが流れ続ける）
        if (DontDestroyEnabled) DontDestroyOnLoad(this);

    }
	
	void Update () {
		
	}

    public void stop() {
        // オブジェクトの削除（メインBGMを止める）
        Destroy(gameObject);
    }

}
