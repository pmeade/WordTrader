using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService : MonoBehaviour
{
    private const string BaseUrl = "http://example.com/api/";

    public void Get(string endpoint, System.Action<string> onSuccess, System.Action<string> onError)
    {
        StartCoroutine(GetCoroutine(endpoint, onSuccess, onError));
    }

    private IEnumerator GetCoroutine(string endpoint, System.Action<string> onSuccess, System.Action<string> onError)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(BaseUrl + endpoint))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }
    }

    public void Post(string endpoint, string jsonData, System.Action<bool> onSuccess, System.Action<string> onError)
    {
        StartCoroutine(PostCoroutine(endpoint, jsonData, onSuccess, onError));
    }

    private IEnumerator PostCoroutine(string endpoint, string jsonData, System.Action<bool> onSuccess, System.Action<string> onError)
    {
        using (UnityWebRequest request = new UnityWebRequest(BaseUrl + endpoint, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(true);
            }
            else
            {
                onError?.Invoke(request.error);
            }
        }
    }
}