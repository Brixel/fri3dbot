using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ledFaceScript : MonoBehaviour {
    private int moodID;
    private int newMoodID;


    // Use this for initialization
    void Start () {
        
        if (SceneManager.GetActiveScene().name.Substring(0,11) == "ledFace_Off")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);
            //Debug.Log(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "> " + "ledFaceScript started without being destroyed!-----------------------------");
            moodID = 0;
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
            return;
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
                moodID = 14; // change to max emotions
            }
            changeMood();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            CancelInvoke();
            if (moodID < 14) // change to max emotions
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

    public void determineMood()
    {
        //Debug.Log(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "> " + "determineMood triggered");
        newMoodID = UnityEngine.Random.Range(0, 14); // choose next mood between 0(inclusive) and 13(exclusive)
        if (newMoodID == moodID) // make sure same mood is never selected twice in a row.
        {
            //Debug.Log(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "> " + "same mood as last time... trying again...");
            determineMood();
            return;
        }
        moodID = newMoodID;
        changeMood();
    }

    void changeMood()
    {
        //Debug.Log(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "> " + " Trying to change to new id: " + moodID + "");
        int moodTime = UnityEngine.Random.Range(2, 60); // time between moods (applied below, so certain animations can override ifneedbe)
            switch (moodID)
            {
                case 0:
                    //happy (random)
                    SceneManager.LoadScene("ledFace_Happy00");
                    break;
                case 1:
                    //angry (random)
                    SceneManager.LoadScene("ledFace_Angry00");
                    break;
                case 2:
                    //Error (sequence)
                    SceneManager.LoadScene("ledFace_Error00");
                    break;
                case 3:
                    //Looking (random)
                    SceneManager.LoadScene("ledFace_Looking00");
                    break;
                case 4:
                    //Sleeping (random)
                    //only trigger between 19:00 and 7:00
                    TimeSpan start = new TimeSpan(07, 0, 0);
                    TimeSpan end = new TimeSpan(19, 0, 0);
                    TimeSpan now = DateTime.Now.TimeOfDay;

                    if ((now > start) && (now < end))
                    {
                        // can't trigger now, choose another mood
                        determineMood();
                    return; //exit the routine instead of re-calculating moodtimes
                }
                    else
                    {
                        // it's between 19:00 and 7:00, so go right ahead sleepy...
                        moodTime = UnityEngine.Random.Range(60, 300); // sleep for 1 to 5 minutes
                        SceneManager.LoadScene("ledFace_Sleeping00");
                    }
                    break;
                case 5:
                    //Special (blow kiss)
                    //override new mood time
                    moodTime = 2;
                    SceneManager.LoadScene("ledFace_Love00");
                    break;
                case 6:
                    //Party-drink (fixed sequence)
                    //only trigger between 22:00 and 4:00
                    start = new TimeSpan(04, 0, 0);
                    end = new TimeSpan(22, 0, 0);
                    now = DateTime.Now.TimeOfDay;

                    if ((now > start) && (now < end))
                    {
                        // can't trigger now, choose another mood
                        determineMood();
                    return; //exit the routine instead of re-calculating moodtimes
                }
                    else
                    {
                        // it's between 22:00 and 4:00, so Party on!
                        moodTime = 10; //fixed animation time
                        SceneManager.LoadScene("ledFace_Party00");
                    }
                    break;
                case 7:
                    //Special2 (love fri3d)
                    //override new mood time
                    moodTime = 5;
                    SceneManager.LoadScene("ledFace_Love01");
                    break;
                case 8:
                    //Game (sequence once)
                    moodTime = 15;
                    SceneManager.LoadScene("ledFace_Game00");
                    break;
                case 9:
                    //Robot (sequence)
                    SceneManager.LoadScene("ledFace_Robot00");
                    break;
                case 10:
                    //Leughing (random)
                    SceneManager.LoadScene("ledFace_Laughing00");
                    break;
                case 11:
                    //Crash (single frame with unity physx)
                    moodTime = 15;
                    SceneManager.LoadScene("ledFace_Crash00");
                    break;
                case 12:
                    //Special (heart eyes)
                    //override new mood time
                    moodTime = 2;
                    SceneManager.LoadScene("ledFace_Love02");
                    break;
                case 13:
                    //Game2 (sequence)
                    SceneManager.LoadScene("ledFace_Game200");
                    break;


                default:
                    // Happy
                    SceneManager.LoadScene("ledFace_Happy00");
                    break;
            }

            //apply mood time
            //Debug.Log(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "> " + "Mood changed to ID " + moodID + " for " + moodTime.ToString() + " seconds");
            Invoke("determineMood", moodTime);
        }
}
