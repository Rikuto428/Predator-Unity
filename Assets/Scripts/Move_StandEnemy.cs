using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_StandEnemy : MonoBehaviour {

    Rigidbody2D rigid2D;

    private int moveType = 0;
    private float delata = 0;
    private bool attackTrigger = false;

    public GameObject insideAttackPrefab;
    public float speed = 5;

    float span = 1.0f;
    float spanMove = 0.5f;
    float spanAttack = 3.0f;
    float directionX;
    float directionY;

    void Start () {

        this.rigid2D = GetComponent<Rigidbody2D>();

    }
	
	void Update () {

        // 1秒ごとに待機・移動・攻撃準備の判定
        this.delata += Time.deltaTime;
        if (this.attackTrigger == false) {
            if (this.delata > this.span) {
                this.delata = 0;
                this.moveType = Random.Range(0, 3);
            }
        }

        // 初期状態
        if (this.moveType == 0) {
        }
        // 移動
        else if (this.moveType == 1) {
            walk();
        }
        // 攻撃準備
        else if (this.moveType == 2) {
            attack();
        }
        // 待機
        else if (this.moveType == 3) {
            // spanMove後に速度0
            if (this.delata > this.spanMove) idle();
        }
        // 攻撃
        else {
            // spanAttack後に攻撃モーション解除→攻撃
            if (this.delata > this.spanAttack) {
                float positionX = transform.position.x;
                float positionY = transform.position.y;
                // 攻撃（オブジェクトの生成）
                GameObject go = Instantiate(insideAttackPrefab) as GameObject;
                go.transform.position = new Vector3(positionX, positionY, 0);
                // 待機状態のアニメーション
                GetComponent<Enemy_O>().idle();
                // 攻撃終了と共に再び待機・移動・攻撃準備の判定開始
                this.attackTrigger = false;
            }
        }

    }

    // 待機
    void idle() {
        this.directionX = 0;
        this.directionY = 0;
        // 移動を止める
        Vector2 direction = new Vector2(this.directionX, this.directionY).normalized;
        this.rigid2D.velocity = direction * this.speed;
    }

    // 移動
    void walk() {
        int walkDirection = 0;
        // 移動する方向
        walkDirection = Random.Range(0, 4);
        // →
        if (walkDirection == 0) {
            this.directionX = 1;
            this.directionY = 0;
        // ←
        }else if(walkDirection == 1) {
            this.directionX = -1;
            this.directionY = 0;
        // ↑
        }else if (walkDirection == 2) {
            this.directionX = 0;
            this.directionY = 1;
        // ↓
        }else {
            this.directionX = 0;
            this.directionY = -1;
        }
        // 選ばれた方向に移動
        Vector2 direction = new Vector2(this.directionX, this.directionY).normalized;
        this.rigid2D.velocity = direction * this.speed;
        // 待機状態に移行（速度を0にして移動を止める）
        this.moveType = 3;
    }

    // 攻撃準備
    void attack() {
        // 攻撃準備のアニメーション、攻撃範囲の予兆の表示
        GetComponent<Enemy_O>().attack();
        // 攻撃準備中は1秒ごとの行動の判定は行わない
        this.attackTrigger = true;
        // 攻撃に移行
        this.moveType = 4;
    }

}
