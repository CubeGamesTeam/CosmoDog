using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScore;
    [SerializeField] private YandexInGame yandexInGame;

    [SerializeField] private GameObject MobileReloadButton;
    [SerializeField] private GameObject MobileMenuButton;

    [SerializeField] private GameObject tryagainText;
    [SerializeField] private GameObject menuText;

    private void Awake()
    {
        if(GameUI.Instance.deviceType > 0)
        {
            menuText.gameObject.SetActive(false);
            tryagainText.gameObject.SetActive(false);
            MobileReloadButton.gameObject.SetActive(true);
            MobileMenuButton.gameObject.SetActive(true);
        }
        else
        {
            menuText.gameObject.SetActive(true);
            tryagainText.gameObject.SetActive(true);
            MobileReloadButton.gameObject.SetActive(false);
            MobileMenuButton.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        finalScore.text = "Ñ÷¸ò: " + ScoreManager.Instance.finalScore.ToString();
        yandexInGame.TryToRateGame();

    }
    private void Update()
    {
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        //else if (Input.GetKeyDown(KeyCode.V))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //}
    }

    public void MobileReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MobileMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
