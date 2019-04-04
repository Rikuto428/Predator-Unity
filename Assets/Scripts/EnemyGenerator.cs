using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public GameObject enemy_oPrefab;

    void Start () {

        // ステージを6つに区分し、それぞれの区分に4匹ずつランダムに配置
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 4; j++) {
                GameObject go = Instantiate(enemy_oPrefab) as GameObject;
                float pxX = Random.Range(-1.5f, 1.5f);
                float pxY = Random.Range(9.0f * i, 9.0f * i + 10);
                go.transform.position = new Vector3(pxX, pxY, 0);
            }
        }

    }
	
	void Update () {
		
	}
}
