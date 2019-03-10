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

        //Debug.Log(this.delata);

        // 1秒ごとに待機・移動・攻撃の判定
        this.delata += Time.deltaTime;
        if (this.attackTrigger == false) {
            if (this.delata > this.span) {

                this.delata = 0;
                this.moveType = Random.Range(0, 3);

            }
        }

        if (this.moveType == 0) {

        }
        else if (this.moveType == 1) {

            walk();

        }
        else if (this.moveType == 2) {

            attack();

        }
        else if (this.moveType == 3) {

            // spanMove後に速度0
            if (this.delata > this.spanMove) idle();

        }
        else {

            // spanAttack後に攻撃モーション解除→攻撃
            if (this.delata > this.spanAttack) {

                float positionX = transform.position.x;
                float positionY = transform.position.y;

                GameObject go = Instantiate(insideAttackPrefab) as GameObject;
                go.transform.position = new Vector3(positionX, positionY, 0);
                GetComponent<Enemy_O>().idle();
                this.attackTrigger = false;

            }

        }

    }

    void idle() {

        // 移動を止める
        this.directionX = 0;
        this.directionY = 0;
        Vector2 direction = new Vector2(this.directionX, this.directionY).normalized;
        this.rigid2D.velocity = direction * this.speed;

    }

    void walk() {

        int walkDirection = 0;
        walkDirection = Random.Range(0, 4);

        if (walkDirection == 0) {

            this.directionX = 1;
            this.directionY = 0;

        }else if(walkDirection == 1) {

            this.directionX = -1;
            this.directionY = 0;

        }else if (walkDirection == 2) {

            this.directionX = 0;
            this.directionY = 1;

        }else {

            this.directionX = 0;
            this.directionY = -1;

        }

        Vector2 direction = new Vector2(this.directionX, this.directionY).normalized;
        this.rigid2D.velocity = direction * this.speed;

        this.moveType = 3;

    }

    void attack() {

        GetComponent<Enemy_O>().attack();
        this.attackTrigger = true;

        this.moveType = 4;

    }

}
