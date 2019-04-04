using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour {

    private float delata = 0;
    float span = 3.0f;

    void Start () {
		
	}
	
	void Update () {

        // 攻撃して3秒後に消える
        this.delata += Time.deltaTime;
        if (this.delata > this.span) Destroy(gameObject);

    }

}
