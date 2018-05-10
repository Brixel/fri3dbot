using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFaceParty_start_drinking : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("goToNextScene",1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void goToNextScene()
    {
        SceneManager.LoadScene("ledFace_Party01");

    }
}
