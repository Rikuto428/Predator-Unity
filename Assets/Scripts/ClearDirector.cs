using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour {

    private string bestTime;
    // PlayerPrefsで保存するためのキー
    private string bestTimeKey = "bestTime";

    public GameObject score_object = null;

    // Timer.csからクリアタイムを取得
    string clearTime = Timer.getTime();

    GameObject mainBgm;

    void Start () {

        this.mainBgm = GameObject.Find("MainBGM");

        // クリアSE
        GetComponent<AudioSource>().Play();

        // ベストタイムの削除
        //PlayerPrefs.DeleteKey("bestTime");
        // ベストタイムの取得
        getTime();
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Clear Time " + clearTime + "           Best Time  " + bestTime;

    }
	
	void Update () {

        // 画面タッチでスタートシーンのロード
        if (Input.GetMouseButton(0)) {
            SceneManager.LoadScene("StartScene");
            // メインBGMを止める
            this.mainBgm.GetComponent<MainBGM>().stop();
        }

    }

    // ベストタイムの取得
    public void getTime() {
        // ベストタイムを取得する。保存されてなければ20秒を取得する。
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