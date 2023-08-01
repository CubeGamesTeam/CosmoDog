using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void TryToInitYSDKFromUnity();

    [DllImport("__Internal")]
    private static extern void TryToGetPlayerFromUnity();

    [DllImport("__Internal")]
    private static extern void TryToGetDeviceFromUnity();



    [SerializeField] private bool isPlayerReady = false;

    [SerializeField] private TMP_Text initYSDKText;
    [SerializeField] private TMP_Text initPlayerText;
    [SerializeField] private TMP_Text initDeviceText;


    private void Awake()
    {
        TryToInitYSDKFromUnity();
        //TryToGetPlayerFromUnity();
        //TryToGetDeviceFromUnity();
    }


    public void YSDKReady(int ready)
    {
        if(ready == 1)
        {
            initYSDKText.color = Color.green;
            initYSDKText.text = "YSDK ready";
            TryToGetPlayerFromUnity();
        }
        else
        {
            initYSDKText.color = Color.red;
            initYSDKText.text = "YSDK not ready";
        }
    }

    public void PlayerReady(int isReady)
    {
        if(isReady == 1)
        {
            isPlayerReady = true;
        }
        else
        {
            isPlayerReady = false;
        }

        
        if (isPlayerReady)
        {
            Debug.Log("Player ready");
            initPlayerText.text = "Player ready";
            initPlayerText.color = Color.green;
            //StartCoroutine("GiveMePlayerCoroutine");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            TryToGetDeviceFromUnity();
        }
        else
        {
            initPlayerText.text = "Player not ready";
            initPlayerText.color = Color.red;
            Debug.Log("Player NOT ready");
        }
    }

    public void GetDeviceType(string type)
    {
        initDeviceText.color = Color.green;
        initDeviceText.text = type;
        switch (type)
        {
            case "desktop":
                PlayerPrefs.SetInt("deviceType", 0);
                break;
            case "mobile":
                PlayerPrefs.SetInt("deviceType", 1);
                break;
            case "tablet":
                PlayerPrefs.SetInt("deviceType", 2);
                break;
            default:
                PlayerPrefs.SetInt("deviceType", 0);
                break;
        }
        StartCoroutine("GiveMePlayerCoroutine");
    }

    IEnumerator GiveMePlayerCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
