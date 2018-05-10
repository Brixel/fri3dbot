using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ledFace_Game2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "ledFace_Game2")
        {
            Invoke("changeScene", 0.5f);
        }
        else
        {
            Debug.Log("destroyed script ledFace_Game2");
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
                SceneManager.LoadScene("ledFace_Game201");
                break;
            case "01":
                SceneManager.LoadScene("ledFace_Game202");
                break;
            case "02":
                SceneManager.LoadScene("ledFace_Game203");
                break;
            case "03":
                SceneManager.LoadScene("ledFace_Game204");
                break;
            case "04":
                SceneManager.LoadScene("ledFace_Game205");
                break;
            case "05":
                SceneManager.LoadScene("ledFace_Game206");
                break;
            case "06":
                SceneManager.LoadScene("ledFace_Game207");
                break;
            case "07":
                SceneManager.LoadScene("ledFace_Game208");
                break;
            case "08":
                SceneManager.LoadScene("ledFace_Game209");
                break;
            case "09":
                SceneManager.LoadScene("ledFace_Game210");
                break;
            case "10":
                SceneManager.LoadScene("ledFace_Game211");
                break;
            case "11":
                SceneManager.LoadScene("ledFace_Game212");
                break;
            case "12":
                SceneManager.LoadScene("ledFace_Game213");
                break;
            case "13":
                SceneManager.LoadScene("ledFace_Game214");
                break;
            case "14":
                SceneManager.LoadScene("ledFace_Game215");
                break;
            case "15":
                SceneManager.LoadScene("ledFace_Game216");
                break;
            case "16":
                SceneManager.LoadScene("ledFace_Game217");
                break;
            case "17":
                SceneManager.LoadScene("ledFace_Game218");
                break;
            case "18":
                SceneManager.LoadScene("ledFace_Game219");
                break;
            case "19":
                SceneManager.LoadScene("ledFace_Game220");
                break;
            case "20":
                SceneManager.LoadScene("ledFace_Game221");
                break;
            case "21":
                SceneManager.LoadScene("ledFace_Game222");
                break;
            case "22":
                SceneManager.LoadScene("ledFace_Game223");
                break;
            case "23":
                SceneManager.LoadScene("ledFace_Game224");
                break;
            case "24":
                SceneManager.LoadScene("ledFace_Game225");
                break;
            case "25":
                SceneManager.LoadScene("ledFace_Game200");
                break;
            default:
                SceneManager.LoadScene("ledFace_Game200");
                break;
        }
    }
}
