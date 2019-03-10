using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_O : MonoBehaviour {

    Animator animator;

    public GameObject insideAttackPrefab;

    // Use this for initialization
    void Start () {

        this.animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void idle() {

        this.animator.SetTrigger("IdleTrigger");

    }

    public void attack() {

        float positionX = transform.position.x;
        float positionY = transform.position.y;

        this.animator.SetTrigger("AttackTrigger");
        GameObject go = Instantiate(insideAttackPrefab) as GameObject;
        go.transform.position = new Vector3(positionX, positionY, 0);

    }

}
