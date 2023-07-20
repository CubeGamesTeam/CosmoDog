using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }

    [SerializeField] private HeartPanel healthPanel;
    [SerializeField] private TMP_Text score;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

        RepaintHearts(Player.Instance.health);
        RepaintScore(ScoreManager.Instance.score);
    }

    private void Update()
    {
        
    }

    private void RepaintHearts(int hp)
    {
        healthPanel.CheckHearts(hp);  
    }

    private void RepaintScore(int num)
    {
        score.text = num.ToString();
    }

    public void GameOverUI()
    {
        gameOverPanel.gameObject.SetActive(true);
        healthPanel.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
    }

}
