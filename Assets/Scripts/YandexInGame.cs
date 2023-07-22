using System.Runtime.InteropServices;
using UnityEngine;


public class YandexInGame : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateGame();

    public void TryToRateGame()
    {
        int rand = Random.Range(0, 10);
        if(rand < 8)
        {
            RateGame();
        }
    }
//#endif
}
