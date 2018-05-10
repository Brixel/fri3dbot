using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ledFace_Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 12) == "ledFace_Game")
        {
            Invoke("changeScene", 0.5f);
        }
        else
        {
            Debug.Log("destroyed script ledFace_Game");
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void changeScene()
    {
        switch (SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 2, 2))
        {
            case "00":
                SceneManager.LoadScene("ledFace_Game01");
                break;
            case "01":
                SceneManager.LoadScene("ledFace_Game02");
                break;
            case "02":
                SceneManager.LoadScene("ledFace_Game03");
                break;
            case "03":
                SceneManager.LoadScene("ledFace_Game04");
                break;
            case "04":
                SceneManager.LoadScene("ledFace_Game05");
                break;
            case "05":
                SceneManager.LoadScene("ledFace_Game06");
                break;
            case "06":
                SceneManager.LoadScene("ledFace_Game07");
                break;
            case "07":
                SceneManager.LoadScene("ledFace_Game08");
                break;
            case "08":
                SceneManager.LoadScene("ledFace_Game09");
                break;
            case "09":
                // animation only runs once
                GameObject.Find("scriptHolder").GetComponent<ledFaceScript>().determineMood();
                break;
            default:
                SceneManager.LoadScene("ledFace_Error00");
                break;
        }
    }
}
