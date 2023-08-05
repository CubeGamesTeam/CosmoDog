using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LoadAfterGetData : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadGame;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadGame;
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
