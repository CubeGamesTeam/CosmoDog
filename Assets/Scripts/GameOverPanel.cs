using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScore;

    private void Start()
    {
        finalScore.text = "����: " + ScoreManager.Instance.finalScore.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
