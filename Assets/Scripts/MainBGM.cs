using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBGM : MonoBehaviour {

    public bool DontDestroyEnabled = true;

    // Use this for initialization
    void Start () {

        GetComponent<AudioSource>().Play();

        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void stop()
    {

        Destroy(gameObject);
        //GetComponent<AudioSource>().Stop();

    }

}
