using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int score;


    //ещё какие-нибудь переменные

}


public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);


    public PlayerInfo PlayerInfo;
    public static Progress Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

//#if !UNITY_EDITOR && UNITY_WEBG
            LoadExtern();
//#endif
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
        SetToLeaderboard(PlayerInfo.score);
    }

    public void Load(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }
}
