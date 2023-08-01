using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }

    [SerializeField] public int deviceType;

    [SerializeField] private HeartPanel healthPanel;
    [SerializeField] private TMP_Text score;

    [SerializeField] private GameObject MobileUpButton;
    [SerializeField] private GameObject MobileDownButton;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private DOTweenAnimation uiCameraShake;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            deviceType = PlayerPrefs.GetInt("deviceType");
            return;
        }
        Destroy(this.gameObject);
    }

    private void Start()
    {
        Player.Instance.onHealthChanged += RepaintHearts;
        Player.Instance.onGameOver += GameOverUI;
        ScoreManager.Instance.onScoreChanged += RepaintScore;

        gameOverPanel.SetActive(false);

        if (deviceType > 0)
        {
            MobileUpButton.gameObject.SetActive(true);
            MobileDownButton.gameObject.SetActive(true);
        }
        else
        {
            MobileUpButton.gameObject.SetActive(false);
            MobileDownButton.gameObject.SetActive(false);
        }

        FirstRepaintHearts(Player.Instance.health);
        RepaintScore(ScoreManager.Instance.score);
    }

    private void FirstRepaintHearts(int hp)
    {
        healthPanel.CheckHearts(hp);
    }

    private void RepaintHearts(int hp)
    {
        uiCameraShake.DOPlayForward();
        healthPanel.CheckHearts(hp);  
    }

    private void RepaintScore(int num)
    {
        score.text = num.ToString();
    }

    public void GameOverUI()
    {
        MobileUpButton.gameObject.SetActive(false);
        MobileDownButton.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        healthPanel.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
    }

}
