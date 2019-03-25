using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour {

    public GameObject score_object = null;
    private string bestTime;
    // PlayerPrefsで保存するためのキー
    private string bestTimeKey = "bestTime";

    GameObject mainBgm;

    // Timer.csからクリアタイムを取得
    string clearTime = Timer.getTime();

    // Use this for initialization
    void Start () {

        GetComponent<AudioSource>().Play();

        // ベストタイムの削除
        //PlayerPrefs.DeleteKey("bestTime");

        // ベストタイムの取得
        getTime();

        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Clear Time " + clearTime + "           Best Time  " + bestTime;

        this.mainBgm = GameObject.Find("MainBGM");

    }
	
	// Update is called once per frame
	void Update () {

        // 画面タッチでスタートシーンのロード
        if (Input.GetMouseButton(0)) {
            SceneManager.LoadScene("StartScene");
            this.mainBgm.GetComponent<MainBGM>().stop();
        }

    }

    // ベストタイムの取得
    public void getTime() {
        // ベストタイムを取得する。保存されてなければ300秒を取得する。
        bestTime = PlayerPrefs.GetString(bestTimeKey, "20.00");
        // タイムがベストタイムより早ければ
        double num1 = double.Parse(bestTime);
        Console.WriteLine(num1);
        double num2 = double.Parse(clearTime);
        Console.WriteLine(num2);
        if (num1 > num2) {
            bestTime = clearTime;
            // ベストタイムの保存
            save();
        }

    }

    // ベストタイムの保存
    public void save() {
        // ベストタイムを保存する
        PlayerPrefs.SetString(bestTimeKey, bestTime);
        PlayerPrefs.Save();

    }

}