using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class eeveScript : MonoBehaviour {
    private int moodID;
    private int newMoodID;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 9) == "eeve-init")
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
                moodID = 6; // change to max emotions
            }
            newMoodID = moodID;
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < 6) // change to max emotions
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

        newMoodID = UnityEngine.Random.Range(0, 7); // choose next mood between x (inclusive) and x (exclusive)
        if (newMoodID == moodID)
        {
            determineMood();
        }
        changeMood();
    }

    void changeMood()
    {
        if (newMoodID != moodID)
        {
            // scene is not ready for change yet... (animation not done yet)
            if (moodID == 4)
            {
                moodID = newMoodID;
                changeMood();
            }

        }
        else
        {
            int moodTime = UnityEngine.Random.Range(5, 60); // time between moods (applied below, so certain animations can override ifneedbe)
            switch (moodID)
            {
                case 0:
                    //idle
                    SceneManager.LoadScene("eeve-idle");
                    break;
                case 1:
                    //Happy
                    SceneManager.LoadScene("eeve-happy");
                    break;
                case 2:
                    //fri3d
                    SceneManager.LoadScene("eeve-fri3d");
                    break;
                case 3:
                    //idle2
                    SceneManager.LoadScene("eeve-idle2");
                    break;
                case 4:
                    //glitch
                    moodTime = UnityEngine.Random.Range(2, 6);
                    //beter not to show errors too long, they so sad :(
                    SceneManager.LoadScene("eeve-glitch");
                    break;
                case 5:
                    //idle3
                    SceneManager.LoadScene("eeve-idle3");
                    break;
                case 6:
                    //error
                    moodTime = UnityEngine.Random.Range(2, 6);
                    //beter not to show errors too long, they so sad :(
                    SceneManager.LoadScene("eeve-error");
                    break;

                default:
                    //idle
                    SceneManager.LoadScene("eeve-idle");
                    break;
            }
            Debug.Log("new mood in: " + moodTime.ToString() + " seconds");
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
        if (moodID != newMoodID)
        {
            moodID = newMoodID;
            changeMood();
        }
    }
}
