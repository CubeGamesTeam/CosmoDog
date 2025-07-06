using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _recordText;

    private void Start()
    {
        _recordText.text = YG2.saves.scores.ToString();
    }

    private void Update()
    {
        if (Input.GetButton("Submit"))
        {
            OnStartButtonDown();
        }
    }

    public void OnStartButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void SwitchLang(string lang)
    {
        YG2.SwitchLanguage(lang);
    }
}
