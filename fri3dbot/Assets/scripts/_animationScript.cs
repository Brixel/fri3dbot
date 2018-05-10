using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class _animationScript : MonoBehaviour {

    public bool isBusy = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void end_anim()
    {
        isBusy = false;
        switch (SceneManager.GetActiveScene().name.Substring(0,4))
        {
            //triggerReady
            case "bend":
                //bender script
                GameObject.Find("bendRScriptHolder").GetComponent<bendrScript>().triggerReady();
                break;
            case "eeve":
                //eeve script
                GameObject.Find("eeveScriptHolder").GetComponent<eeveScript>().triggerReady();
                break;
            case "gear":
                //gearhead script
                GameObject.Find("gearHeadScriptHolder").GetComponent<gearheadScript>().triggerReady();
                break;
            case "ledF":
                //ledFace script
                // ledface does not have end_anim but is time-based
                break;
            case "robo":
                //roboHead script
                GameObject.Find("roboScriptHolder").GetComponent<roboFaceScript>().triggerReady();
                break;
            case "foxk":
                //foxkeh script
                GameObject.Find("foxkehScriptHolder").GetComponent<foxkehScript>().triggerReady();
                break;
            default:
                //do nothing
                Debug.Log("unexpected state 'default' in _animationScript.cs");
                break;
        }
    }
    public void begin_anim()
    {
        isBusy = true;
    }
}
