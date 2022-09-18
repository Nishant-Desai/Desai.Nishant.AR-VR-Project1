using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Networking;

public class ClassTimeScript : MonoBehaviour
{
    
    public GameObject Class_timeText;
    string url = "https://worldtimeapi.org/api/timezone/Asia/Singapore";

    void Start()
    {
    InvokeRepeating("UpdateTime", 0f, 60f);   
    }

   
    void UpdateTime()
    {
        StartCoroutine(getRequest(url));
    }

    IEnumerator getRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                int dateTime = webRequest.downloadHandler.text.IndexOf("datetime",0);
                int startTime = webRequest.downloadHandler.text.IndexOf("T",dateTime);
                int endTime = startTime + 5;
                string time = webRequest.downloadHandler.text.Substring(startTime+1,5);
                Debug.Log("Time: "+time);
                Class_timeText.GetComponent<TextMeshPro>().text = "" + time;
            }
        }
    }
}
