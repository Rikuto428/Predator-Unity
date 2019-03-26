using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    public GameObject score_object = null;
    GameObject mainBgm;
    private bool resetTrigger = false;

    // Use this for initialization
    void Start () {

        this.mainBgm = GameObject.Find("MainBGM");

    }
	
	// Update is called once per frame
	void Update () {

        if (resetTrigger == true) {
            if (Input.GetMouseButton(0))
            {
                //// 現在のScene名を取得する
                //Scene loadScene = SceneManager.GetActiveScene();
                //// Sceneの読み直し
                //SceneManager.LoadScene(loadScene.name);
                //GetComponent<Timer>().reset();
                // 画面タッチでスタートシーンのロード
                if (Input.GetMouseButton(0))
                {
                    SceneManager.LoadScene("StartScene");
                }
            }
        }

    }

    public void died() {

        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Restart the touch screen";
        this.mainBgm.GetComponent<MainBGM>().stop();
        GetComponent<AudioSource>().Play();
        GetComponent<Timer>().died();
        resetTrigger = true;

    }

}
