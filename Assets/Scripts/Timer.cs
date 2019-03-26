using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject score_object = null;
    float timer;
    private bool diedTrigger = false;

    public static string time; 
    // getter
    public static string getTime() {
        return time;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (diedTrigger == false)
        {
            this.timer += Time.deltaTime;
            time = this.timer.ToString("F2");

            // オブジェクトからTextコンポーネントを取得
            Text score_text = score_object.GetComponent<Text>();
            // テキストの表示を入れ替える
            score_text.text = time;

        }

    }

    public void reset() {

        this.timer = 0.0f;

    }

    public void died()
    {

        diedTrigger = true;

    }

}
