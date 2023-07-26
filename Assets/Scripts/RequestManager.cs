using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestManager : MonoBehaviour
{
    [SerializeField] private string baseUrl;

    private static RequestManager instance;

    public static RequestManager Instance
    {
        get { return instance; }
        set
        {
            if (instance == null)
            {
                instance = value;
            }
        }
    }

    public virtual void Awake()
    {
        Instance = this;
    }

    public void SendRequest(string command)
    {
        StartCoroutine(Upload(command));
    }

    IEnumerator Upload(string command)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        UnityWebRequest www = UnityWebRequest.Post(baseUrl + command, formData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
    }
}
