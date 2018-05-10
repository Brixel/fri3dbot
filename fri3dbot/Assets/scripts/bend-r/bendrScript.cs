using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class bendrScript : MonoBehaviour {
    private int moodID;
    private int newMoodID;


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0,11) == "bend-r-init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            moodID = 0;
            newMoodID = 0;
            Invoke("determineMood", 1f);
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }


	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name.Substring(0, 5) == "_tran")
        {
            Destroy(this.gameObject);
        }

        //listen for keys to change mood
        if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            CancelInvoke();
            if (moodID > 0)
            {
                moodID--;
            }
            else
            {
                moodID = 8; // change to max emotions
            }
            newMoodID = moodID;
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < 8) // change to max emotions
            {
                moodID++;
            }
            else
            {
                moodID = 0;
            }
            newMoodID = moodID;
            changeMood();
        }
    }

    void determineMood()
    {      
        newMoodID = UnityEngine.Random.Range(0, 9); // choose next mood between 0(inclusive) and 9 exclusive)
        if (newMoodID == moodID)
        {
            determineMood();
        }
        changeMood();
    }

    void changeMood()
    {
        if(newMoodID != moodID)
        {
            // scene is not ready for change yet... (animation not done yet)
            if(moodID == 5)
            {
                moodID = newMoodID;
                changeMood();
            }
        }
        else
        {
            // change the scene
            int moodTime = UnityEngine.Random.Range(20, 120); // time between moods (applied below, so certain animations can override ifneedbe)
            switch (moodID)
            {
                case 0:
                    //happy (animation)
                    SceneManager.LoadScene("bend-rHappy");
                    break;
                case 1:
                    //angry (animation)
                    SceneManager.LoadScene("bend-rAngry00");
                    break;
                case 2:
                    //Error (animation)
                    moodTime = UnityEngine.Random.Range(2, 6);
                    //beter not to show errors too long, they so sad :(
                    SceneManager.LoadScene("bend-rError00");
                    break;
                case 3:
                    //Error2 (animation)
                    //beter not to show errors too long, they so sad :(
                    //except this one... cuz it's funny :)
                    SceneManager.LoadScene("bend-rError200");
                    break;
                case 4:
                    //drunk (animation)
                    moodTime = 15;
                    SceneManager.LoadScene("bend-rDrunk");
                    break;
                case 5:
                    //coding (animation)
                    SceneManager.LoadScene("bend-rCoding00");
                    break;
                case 6:
                    //fri3d (animation)
                    SceneManager.LoadScene("bend-rFried");
                    break;
                case 7:
                    //smoking (animation)
                    SceneManager.LoadScene("bend-rSmoking");
                    break;
                case 8:
                    //looking (animation)
                    SceneManager.LoadScene("bend-rLooking");
                    break;
                default:
                    // Happy
                    SceneManager.LoadScene("bend-rHappy");
                    break;
            }

            //apply mood time
            Invoke("determineMood", moodTime);
        }
    }

    public void triggerBusy()
    {
    }

    public void triggerReady()
    {
        //only change if needed
        if(moodID != newMoodID)
        {
            moodID = newMoodID;
            changeMood();
        }
    }
}