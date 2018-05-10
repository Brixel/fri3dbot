using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _OverlayScript : MonoBehaviour
{

    public GameObject canvasPrefab = null;
    public float lastPosition = 0f;
    private GameObject thisCanvas = null;
    private GameObject thisTextField = null;
    private GameObject thisCodeField = null;
    public int currentSecurityCode = 123;
    public int lastSecurityCode = 321;
    public float securityCodeTime = 60f;
    public string overlayText = "";


    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            //create hook for scenechange
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
            //set overlay text for startup
            overlayText = "Loading fri3dbot";
            //spawn overlay
            spawnOverlay();
            //reset overlay text
            overlayText = "";
        }
        else
        {
            //spawn overlay
            spawnOverlay();
        }

        //trigger security code
        Invoke("generateSecurityCode", 0.1f);
    }

    void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        //unless it's a transition scene, apply overlay
        if (SceneManager.GetActiveScene().name.Substring(0, 6) != "_trans")
        {
            //set scene name as overlay text
            //overlayText = SceneManager.GetActiveScene().name.ToString();
            spawnOverlay();
        }
    }





    // Update is called once per frame
    void Update()
    {

    }
    
    public void spawnOverlay()
    {
        //instantiate overlay object
        thisCanvas = Instantiate(canvasPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        //set canvas rendermode to camera
        thisCanvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        //assign main camera to canvas
        thisCanvas.GetComponent<Canvas>().worldCamera = Camera.main;

        //OverlayText
        thisTextField = GameObject.Find("bottomText").gameObject;
        thisTextField.GetComponent<Text>().text = overlayText;

        //security code
        thisCodeField = GameObject.Find("topText").gameObject;
        thisCodeField.GetComponent<Text>().text = currentSecurityCode.ToString();

        //override colors for some faces
        //bend-r (background is gray)
        if (SceneManager.GetActiveScene().name.Substring(0,6) == "bend-r")
        {
            thisTextField.GetComponent<Text>().color = Color.black;
            thisCodeField.GetComponent<Text>().color = Color.black;
        }
    }

    public void generateSecurityCode()
    {
        //move current code to lastcode
        lastSecurityCode = currentSecurityCode;
        //generate new code
        currentSecurityCode = Random.Range(100, 999);
        //updateOverlay
        thisCodeField = GameObject.Find("topText").gameObject;
        thisCodeField.GetComponent<Text>().text = currentSecurityCode.ToString() ;
        //run this function again in <x> time
        Invoke("generateSecurityCode", securityCodeTime);
    }

    public void setOverlayText(string text)
    {
        overlayText = text;
        //update OverlayText
        thisTextField = GameObject.Find("bottomText").gameObject;
        thisTextField.GetComponent<Text>().text = overlayText;
    }
}