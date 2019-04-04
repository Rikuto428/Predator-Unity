using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    private bool resetTrigger = false;

    public GameObject score_object = null;

    GameObject mainBgm;

    void Start () {

        this.mainBgm = GameObject.Find("MainBGM");

    }
	
	void Update () {

        if (resetTrigger == true) {
            // 画面タッチでスタートシーンのロード
            if (Input.GetMouseButton(0)) {
                if (Input.GetMouseButton(0)) SceneManager.LoadScene("StartScene");
            }
        }

    }

    public void died() {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Restart the touch screen";
        // メインBGMを止める
        this.mainBgm.GetComponent<MainBGM>().stop();
        // 死亡SE
        GetComponent<AudioSource>().Play();
        GetComponent<Timer>().died();
        // スタートシーンに戻れるようにする
        resetTrigger = true;
    }

}
