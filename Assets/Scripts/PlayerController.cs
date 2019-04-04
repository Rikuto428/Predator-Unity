using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 5;

    Rigidbody2D rigid2D;
    GameObject gameDirector;

    void Start () {

        this.rigid2D = GetComponent<Rigidbody2D>();
        this.gameDirector = GameObject.Find("GameDirector");

    }
	
	void Update () {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        // 移動
        Vector2 direction = new Vector2(x, y).normalized;
        this.rigid2D.velocity = direction * this.speed;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ゴールに到達
        if (other.gameObject.tag == "Goal") SceneManager.LoadScene("ClearScene");
        // 敵の攻撃に被弾
        if (other.gameObject.tag == "Attack") {
            // オブジェクトの削除
            Destroy(gameObject);
            // 死亡時の動作いろいろ
            this.gameDirector.GetComponent<GameDirector>().died();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // 敵と衝突
        if (collision.gameObject.tag == "Enemy") {
            // オブジェクトの削除
            Destroy(gameObject);
            // 死亡時の動作いろいろ
            this.gameDirector.GetComponent<GameDirector>().died();
        }
    }

}
