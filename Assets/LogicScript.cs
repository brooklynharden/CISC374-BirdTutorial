using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    AudioManager audioManager;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    private bool isGameOver = false;

    public GameObject highScoreScreen;

    public Text highScoreText;

    private const string HighSCORE = "HighScore";

    void Start()
    {
        int savedScore = PlayerPrefs.GetInt(HighSCORE,0);
        highScoreText.text = "High Score: " + savedScore.ToString();
        highScoreScreen.SetActive(false);
        Time.timeScale = 0;
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    [ContextMenu("Increase Score")]
   public void addScore(int scoreToAdd){
    if(!isGameOver){
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
         audioManager.playSFX(audioManager.pointCheck);
    }
   }
    
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void gameOver(){
        isGameOver = true;
        gameOverScreen.SetActive(true);
        audioManager.playSFX(audioManager.over);
        updateHighScore();
       
    }

    //This updates the players highest score, it keeps track as well
    //If the person doesnt beat the highest score, no high score will show, but if they do 'New High Score' will pop up
    private void updateHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt(HighSCORE,0);
        if(playerScore > savedHighScore){
            PlayerPrefs.SetInt(HighSCORE,playerScore);
            PlayerPrefs.Save();
            highScoreText.text = "New High Score: " + playerScore.ToString();
            highScoreScreen.SetActive(true);
        }
    }
}
