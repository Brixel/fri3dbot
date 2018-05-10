using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class _webPoller : MonoBehaviour
{
    private List<string> _lastUsedScenes = new List<string>();

    public float Timeout = 5f;

    // Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "_startup")
        {
            // don't destroy this object
            DontDestroyOnLoad(this);

        }

	    StartCoroutine("PollHndler");
	}
	
	// Update is called once per frame
    void Update ()
    {
    }

    private IEnumerator PollHndler()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:59576/api/scenes/new"))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var response = request.downloadHandler.text;
                if (!string.IsNullOrEmpty(response))
                {
                    _lastUsedScenes.Add(response);
                }
            }
        }

        yield return new WaitForSeconds(Timeout);
        StartCoroutine("PollHndler");
    }
}
