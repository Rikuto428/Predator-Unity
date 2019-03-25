using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid2D;
    GameObject gameDirector;
    public float speed = 5;

    void Start () {

        this.rigid2D = GetComponent<Rigidbody2D>();
        this.gameDirector = GameObject.Find("GameDirector");

    }
	
	void Update () {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        this.rigid2D.velocity = direction * this.speed;

    }

    private void OnTriggerEnter2D(Collider2D other) {

        // ゴールに到達
        if (other.gameObject.tag == "Goal") {
            SceneManager.LoadScene("ClearScene");
        }

        // 敵の攻撃に被弾
        if (other.gameObject.tag == "Attack") {
            Destroy(gameObject);
            this.gameDirector.GetComponent<GameDirector>().died();
            //Debug.Log("死亡");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        // 敵と衝突
        if (collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
            this.gameDirector.GetComponent<GameDirector>().died();
            //Debug.Log("死亡");
        }

    }

}
