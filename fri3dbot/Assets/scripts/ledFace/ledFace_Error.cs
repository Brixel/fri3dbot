using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Error : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "ledFace_Error")
        {
            Invoke("changeScene", 0.3f);
        }
        else
        {
            Debug.Log("destroyed script ledface_Error");
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        switch (SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 2,2))
        {
            case "00":
                SceneManager.LoadScene("ledFace_Error01");
                break;
            case "01":
                SceneManager.LoadScene("ledFace_Error02");
                break;
            case "02":
                SceneManager.LoadScene("ledFace_Error00");
                break;
            default:
                SceneManager.LoadScene("ledFace_Error00");
                break;
        }
    }
}
