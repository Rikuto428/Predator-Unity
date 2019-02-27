using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_StandEnemy : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed = 5;

    private int moveType = 0;

    private bool isIdle;
    private bool isWalk;
    private bool isAttack;

    float span = 1.0f;
    float delata = 0;
    float x;
    float y;

    void Start () {

        this.rigid2D = GetComponent<Rigidbody2D>();

    }
	
	void Update () {

        // 1秒ごとに待機・移動・攻撃の判定
        this.delata += Time.deltaTime;
        if(this.delata > this.span) {

            this.delata = 0;
            this.moveType = Random.Range(0, 3);

        }

        if (this.moveType == 0) {

            this.isIdle = true;
            this.isWalk = false;
            this.isAttack = false;

        }
        else if (this.moveType == 1) {

            this.isIdle = false;
            this.isWalk = true;
            this.isAttack = false;

        }
        else{

            this.isIdle = false;
            this.isWalk = false;
            this.isAttack = true;

        }

        if (isIdle) {

            idle();
            // 移動を止める
            Vector2 direction = new Vector2(this.x, this.y).normalized;
            this.rigid2D.velocity = direction * this.speed;

        }
        else if (isWalk) {

            walk();

        }
        else {

            attack();

        }

    }

    void idle() {

        this.x = 0;
        this.y = 0;

    }

    void walk() {

        int walkDirection = 0;
        walkDirection = Random.Range(0, 4);

        if (walkDirection == 0) {

            this.x = 1;
            this.y = 0;

        }else if(walkDirection == 1) {

            this.x = -1;
            this.y = 0;

        }
        else if (walkDirection == 2) {

            this.x = 0;
            this.y = 1;

        }
        else {

            this.x = 0;
            this.y = -1;

        }

        Vector2 direction = new Vector2(x, y).normalized;
        this.rigid2D.velocity = direction * this.speed;

        this.moveType = 0;

    }

    void attack() {

        this.moveType = 0;

    }

}
