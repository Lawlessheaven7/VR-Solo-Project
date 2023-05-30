using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image timerImage;
    [SerializeField] private Image healthImage;
    [SerializeField] private float maxhealth;
    [SerializeField] private float gameTime;
    private float currentFillAmount = 1f;
    public float currentHealthAmount;

    private int playerScore = 0;
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Game Over Components")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("Gameplay Audio")]
    [SerializeField] private AudioSource gameplayAudio;
    [SerializeField] private AudioClip[] IGM;

    [Header("High Score Storing")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;
    public enum gameStates
    {
        waiting,
        playing,
        end
    }

    public static gameStates currentGamestatus;

    private void Awake()
    {
        currentGamestatus = gameStates.waiting;

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = highScore.ToString();
        }
    }

    private void Start()
    {
        currentHealthAmount = maxhealth;
    }


    private void Update()
    {
        if (currentGamestatus == gameStates.playing)
        {
            adjustTimer();
        }
    }



    private void adjustTimer()
    {
        timerImage.fillAmount = currentFillAmount - (Time.deltaTime / gameTime);
        currentFillAmount = timerImage.fillAmount;
        if(currentFillAmount <= 0f)
        {
            GameOver();
        }
    }

    public void UpdatePlayerScore(int enemyHitPoints)
    {
        if(currentGamestatus != gameStates.playing)
        
        return;
        

        playerScore += enemyHitPoints;
        scoreText.text = playerScore.ToString();
    }

    public void updateHealth()
    {
        if (currentGamestatus != gameStates.playing)

        return;

        healthImage.fillAmount = currentHealthAmount / maxhealth;

        if(currentHealthAmount <= 0f)
        {
            GameOver();
        }

    }

    public void StartGame()
    {
       currentGamestatus = gameStates.playing;
        gameplayAudio.clip = IGM[1];
        gameplayAudio.Play();
    }
    public void GameOver()
    {
        currentGamestatus = gameStates.end;

        //show game over panel
        gameOverPanel.SetActive(true);

        if(currentHealthAmount <= 0f)
        {
            gameplayAudio.clip = IGM[3];
            gameplayAudio.Play();
            gameplayAudio.loop = false;
        }else if (currentHealthAmount > 0f)
        {
            gameplayAudio.clip = IGM[2];
            gameplayAudio.Play();
            gameplayAudio.loop = false;
        }
       
        //Check high score
        if(playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = playerScore.ToString();
        }
    }

    public void ResetGame()
    {
        currentGamestatus = gameStates.waiting;
        //reset Timer
        timerImage.fillAmount = 1f;
        currentFillAmount = 1f;
        //reset score
        playerScore= 0;
        scoreText.text = 0.ToString();
        //reset health
        currentHealthAmount = maxhealth;
        healthImage.fillAmount = 1f;

        //reset music
        gameplayAudio.clip = IGM[0];
        gameplayAudio.Play();
        gameplayAudio.loop = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
