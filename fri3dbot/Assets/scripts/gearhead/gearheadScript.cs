﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class gearheadScript : MonoBehaviour {
    private int moodID;

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name.Substring(0, 13) == "gearHead_init")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
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
                moodID = 4; // change to max emotions
            }
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < 4) // change to max emotions
            {
                moodID++;
            }
            else
            {
                moodID = 0;
            }
            changeMood();
        }
    }

    void determineMood()
    {      
        int moodID = UnityEngine.Random.Range(0, 5); // choose next mood between x (inclusive) and x (exclusive)
        changeMood();
    }

    void changeMood()
    {
        int moodTime = UnityEngine.Random.Range(2, 60); // time between moods (applied below, so certain animations can override ifneedbe)
        switch (moodID)
        {
            case 0:
                //idle
                SceneManager.LoadScene("gearHead_idle");
                break;
            case 1:
                //idle2
                SceneManager.LoadScene("gearHead_idle2");
                break;
            case 2:
                //happy (more like derpy)
                SceneManager.LoadScene("gearHead_happy");
                break;
            case 3:
                //stuck
                SceneManager.LoadScene("gearHead_gearStuck");
                break;
            case 4:
                //fri3d
                SceneManager.LoadScene("gearHead_fri3d");
                break;

            default:
                // idle
                SceneManager.LoadScene("gearHead_idle");
                break;
        }

        //apply mood time
        Invoke("determineMood", moodTime);
    }
}
