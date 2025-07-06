using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LoadAfterGetData : MonoBehaviour
{
    private void OnEnable()
    {
        YG2.onGetSDKData += LoadGame;
    }
    private void OnDisable()
    {
        YG2.onGetSDKData -= LoadGame;
    }

    private void LoadGame()
    {
        YG2.GameReadyAPI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
