using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour {

    private float delata = 0;
    float span = 3.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.delata += Time.deltaTime;
        if (this.delata > this.span) {

            Destroy(gameObject);

        }

    }

    public void destroy() {

        //Destroy(gameObject);

    }

}
