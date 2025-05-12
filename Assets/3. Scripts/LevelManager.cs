using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int levelDurationInSeconds = 300;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text text;
    public string nextLevelName = "Level 02";
    public bool gameOver = false;
    public bool levelCompleted = false;
    private float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(gameOver || time >= levelDurationInSeconds)
        {
            if (nextLevelName == "Level 06" || nextLevelName == "Last")
                Invoke("GameOver", 8);
            else
                GameOver();
        }
        else if(levelCompleted)
        {
            LoadNextLevel();
        }

        int timeLeft = levelDurationInSeconds - (int)time;
        timerText.text =  timeLeft / 60 + " : " + timeLeft % 60;
    }

    private void GameOver()
    {
        text.text = "Game Over";
        Time.timeScale = 0;
    }

    private void LoadNextLevel()
    {
        text.text = "Level Accomplished";
        if (nextLevelName != "Last")
            SceneManager.LoadScene(nextLevelName);
        else
            Time.timeScale = 0;
    }
}
