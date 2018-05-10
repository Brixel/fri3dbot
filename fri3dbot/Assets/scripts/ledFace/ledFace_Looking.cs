using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Looking : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 15) == "ledFace_Looking")
        {
            float randomTime = Random.Range(0.5f, 5f);
            Invoke("changeScene", randomTime);
        }
        else
        {
            Debug.Log("destroyed script ledFace_Looking");
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
                SceneManager.LoadScene("ledFace_Looking00");
                break;
            case 1:
                SceneManager.LoadScene("ledFace_Looking01");
                break;
            case 2:
                SceneManager.LoadScene("ledFace_Looking02");
                break;
            case 3:
                SceneManager.LoadScene("ledFace_Looking03");
                break;
            default:
                SceneManager.LoadScene("ledFace_Looking00");
                break;
        }
    }
}
