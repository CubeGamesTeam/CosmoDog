using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScore;

    [SerializeField] private GameObject MobileReloadButton;
    [SerializeField] private GameObject MobileMenuButton;

    [SerializeField] private GameObject tryagainText;
    [SerializeField] private GameObject menuText;

    private void Awake()
    {
        if (!YG2.envir.isDesktop)
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
        finalScore.text = ScoreManager.Instance.finalScore.ToString();
    }
    private void Update()
    {
        if (Input.GetButton("Submit"))
        {
            YG2.InterstitialAdvShow();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void MobileReload()
    {
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MobileMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
