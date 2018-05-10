using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Happy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "ledFace_Happy")
        {
            float randomTime = Random.Range(0.5f, 5f);
            Invoke("changeScene", randomTime);
        }
        else
        {
            Debug.Log("destroyed script ledFace_Happy");
            Destroy(this.gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        int randomScene = Random.Range(0, 4);
        switch (randomScene)
        {
            case 0:
                SceneManager.LoadScene("ledFace_Happy00");
                break;
            case 1:
                SceneManager.LoadScene("ledFace_Happy01");
                break;
            case 2:
                SceneManager.LoadScene("ledFace_Happy02");
                break;
            case 3:
                SceneManager.LoadScene("ledFace_Happy03");
                break;
            default:
                SceneManager.LoadScene("ledFace_Happy00");
                break;
        }
    }
}
