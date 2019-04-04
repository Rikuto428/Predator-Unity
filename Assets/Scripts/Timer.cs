using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private bool diedTrigger = false;

    public GameObject score_object = null;

    float timer;

    // ClearDirector.csにクリアタイムを渡す
    public static string time;
    public static string getTime() {
        return time;
    }

    void Start () {
		
	}
	
	void Update () {

        // 経過時間
        if (diedTrigger == false) {
            // 小数点第2位まで取得
            this.timer += Time.deltaTime;
            time = this.timer.ToString("F2");
            // オブジェクトからTextコンポーネントを取得
            Text score_text = score_object.GetComponent<Text>();
            // テキストの表示を入れ替える
            score_text.text = time;
        }

    }

    // タイマーのリセット
    public void reset() {
        this.timer = 0.0f;
    }

    // 死亡時
    public void died() {
        // タイマーのカウントを止める
        diedTrigger = true;
    }

}
