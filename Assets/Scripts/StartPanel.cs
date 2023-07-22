using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text recordText;

    private void Start()
    {
        //recordText.text = "������: " + PlayerPrefs.GetInt("record").ToString();
        recordText.text = "������: " + Progress.Instance.PlayerInfo.score;
    }

    public void onStartButtonDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //private void OnEnable()
    //{
    //    StartCoroutine(GetScore());
    //}

    //IEnumerator GetScore()
    //{
    //    yield return new WaitForSeconds(.01f);
    //    recordText.text = "������: " + ScoreManager.Instance.recordScore.ToString();
    //}
}
