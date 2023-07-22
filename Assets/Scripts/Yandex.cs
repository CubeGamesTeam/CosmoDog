using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GiveMePlayerData();

    [SerializeField] private RawImage playerImage;
    [SerializeField] private TMP_Text playerNameText;

//#if USE_WEBGL_2_0
    private void Start()
    {
        GiveMePlayerData();
    }

    public void SetName(string name)
    {
        playerNameText.text = name;
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            playerImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
//#endif
}
