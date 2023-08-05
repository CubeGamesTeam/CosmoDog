using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text recordText;
    [SerializeField] private GameObject PlayerName;
    [SerializeField] private GameObject PlayerIcon;


    private void Start()
    {
        if (YandexGame.auth == true)
        {
            PlayerName.SetActive(true);
            PlayerIcon.SetActive(true);
        }
        else
        {
            PlayerName.SetActive(false);
            PlayerIcon.SetActive(false);
        }
        recordText.text = YandexGame.savesData.scores.ToString();
    }

    private void Update()
    {
        if (Input.GetButton("Submit"))
        {
            onStartButtonDown();
        }
    }

    public void onStartButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void onAuthButtonDown()
    {
        YandexGame.AuthDialog();
    }

    public void SwitchLang(string lang)
    {
        YandexGame.SwitchLanguage(lang);
    }
}
