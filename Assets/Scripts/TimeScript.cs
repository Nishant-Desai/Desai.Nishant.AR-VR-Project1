using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Networking;

public class TimeScript : MonoBehaviour
{
    public GameObject TimeText;
    string url = "https://worldtimeapi.org/api/timezone/Europe/London";

    void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 60f);
    }

    void UpdateTime()
    {
        StartCoroutine(get_Request(url));
    }

    IEnumerator get_Request(string uri)
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
                int dateTime = webRequest.downloadHandler.text.IndexOf("datetime", 0);
                int startTime = webRequest.downloadHandler.text.IndexOf("T", dateTime);
                int endTime = startTime + 5;
                string time = webRequest.downloadHandler.text.Substring(startTime + 1, 5);
                string ampm = "am";
                if ((Int32.Parse(time.Substring(0, 2)) > 12))
                {
                    int new_hour = Int32.Parse(time.Substring(0, 2)) - 12;
                    time = new_hour.ToString() + time.Substring(2);
                    ampm = "pm";
                }
                Debug.Log("Time: " + time);
                TimeText.GetComponent<TextMeshPro>().text = "" + time + "" + ampm;
            }
        }
    }
}
