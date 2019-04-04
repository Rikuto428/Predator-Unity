using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_O : MonoBehaviour {

    public GameObject insideAttackPrefab;

    Animator animator;
    
    void Start () {

        this.animator = GetComponent<Animator>();
		
	}
	
	void Update () {
		
	}

    public void idle() {
        // 待機状態のアニメーション
        this.animator.SetTrigger("IdleTrigger");
    }

    public void attack() {
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        // 攻撃準備のアニメーション
        this.animator.SetTrigger("AttackTrigger");
        // 攻撃範囲の予兆の表示
        GameObject go = Instantiate(insideAttackPrefab) as GameObject;
        go.transform.position = new Vector3(positionX, positionY, 0);
    }

}
