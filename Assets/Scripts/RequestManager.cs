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

    private void Awake()
    {
        instance = this;
    }

    public void SendRequest(string command)
    {
        StartCoroutine(Upload(command));
    }

    IEnumerator Upload(string command)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        UnityWebRequest request = UnityWebRequest.Post(baseUrl + command, formData);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
    }
}
