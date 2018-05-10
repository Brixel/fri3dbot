using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class _sceneDirector : MonoBehaviour {

    public string nextSceneName = "ledFace_Off";
    public int currentScenenumber = 0;

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            Invoke("loadRandomScene", 5f);
        }
    }

    void showTransition()
    {
        int transitionNumber = UnityEngine.Random.Range(0, 6);
        float waitingTime = UnityEngine.Random.Range(2f, 5f);
        switch (transitionNumber)
        {
            case 0:
                SceneManager.LoadScene("_transition_static");
                break;
            case 1:
                SceneManager.LoadScene("_transition_testbeeld1");
                break;
            case 2:
                SceneManager.LoadScene("_transition_testbeeld2");
                break;
            case 3:
                SceneManager.LoadScene("_transition_xpScreensaver");
                break;
            case 4:
                SceneManager.LoadScene("_transition_blocks");
                waitingTime = 8f;
                break;
            case 5:
                SceneManager.LoadScene("_transition_Fri3dlogo");
                break;

            default:
                SceneManager.LoadScene("_transition_static");
                break;
        }
        
        Invoke("loadScene",waitingTime);
    }
	
	// Update is called once per frame
	void Update () {
		//listen for keys to change face
        if(Input.GetKeyUp(KeyCode.F1) == true)
        {
            nextSceneName = "ledFace_Off";
            currentScenenumber = 0;
            showTransition();
        }
        if(Input.GetKeyUp(KeyCode.F2) == true)
        {
            nextSceneName = "bend-r-init";
            currentScenenumber = 1;
            showTransition();
        }
        if (Input.GetKeyUp(KeyCode.F3) == true)
        {
            nextSceneName = "eeve-init";
            currentScenenumber = 2;
            showTransition();
        }
        if (Input.GetKeyUp(KeyCode.F4) == true)
        {
            nextSceneName = "gearHead_init";
            currentScenenumber = 3;
            showTransition();
        }
        if(Input.GetKeyUp(KeyCode.F5) == true)
        {
            nextSceneName = "roboFace-init";
            currentScenenumber = 4;
            showTransition();
        }
        if (Input.GetKeyUp(KeyCode.F6) == true)
        {
            nextSceneName = "foxkeh-Init";
            currentScenenumber = 5;
            showTransition();
        }
    }


    public void loadScene()
    {
        SceneManager.LoadScene(nextSceneName);
        // load another random scene
        float newSceneTime = UnityEngine.Random.Range(120f, 600f); //random between 2 and 10 minutes       
        TimeSpan newTime = new TimeSpan(System.DateTime.Now.TimeOfDay.Hours,System.DateTime.Now.TimeOfDay.Minutes,System.DateTime.Now.TimeOfDay.Seconds + Mathf.RoundToInt(newSceneTime));
        Debug.Log("New scene in " + newSceneTime.ToString() + " Seconds (= " + newTime.ToString()  + " )");

        //load new scene in <x> time
        Invoke("loadRandomScene", newSceneTime);
    }


    public void loadRandomScene()
    {
        int randomScene = UnityEngine.Random.Range(0, 6);
        switch(randomScene)
        {
            case 0:
                // led matrix face
                nextSceneName = "ledFace_Off";
                currentScenenumber = 0;
                break;
            case 1:
                //bend-r rodruigez
                nextSceneName = "bend-r-init";
                currentScenenumber = 1;
                break;
            case 2:
                //eeve
                nextSceneName = "eeve-init";
                currentScenenumber = 2;
                break;
            case 3:
                //gearhead
                nextSceneName = "gearHead_init";
                currentScenenumber = 3;
                break;
            case 4:
                //roboface
                nextSceneName = "roboFace-init";
                currentScenenumber = 4;
                break;
            case 5:
                //foxkeh
                nextSceneName = "foxkeh-Init";
                currentScenenumber = 5;
                break;
            default:
                // led matrix face
                nextSceneName = "ledFace_Off";
                currentScenenumber = 5;
                break;

        }
        Invoke("showTransition", 1f);
    }
}
