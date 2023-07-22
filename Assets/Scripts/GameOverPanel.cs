using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScore;
    [SerializeField] private YandexInGame yandexInGame;

    private void Start()
    {
        finalScore.text = "Ñ÷¸ò: " + ScoreManager.Instance.finalScore.ToString();
        yandexInGame.TryToRateGame();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
