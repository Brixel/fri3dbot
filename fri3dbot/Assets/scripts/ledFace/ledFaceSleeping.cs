using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFaceSleeping : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 16) == "ledFace_Sleeping")
        {
            float randomTime = Random.Range(0.5f, 5f);
            Invoke("changeScene", randomTime);
        }
        else
        {
            Debug.Log("destroyed script ledFace_Sleeping");
            Destroy(this.gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        int randomScene = Random.Range(0, 3);
        switch (randomScene)
        {
            case 0:
                SceneManager.LoadScene("ledFace_Sleeping00");
                break;
            case 1:
                SceneManager.LoadScene("ledFace_Sleeping01");
                break;
            case 2:
                SceneManager.LoadScene("ledFace_Sleeping02");
                break;
            default:
                SceneManager.LoadScene("ledFace_Sleeping00");
                break;
        }
    }
}
