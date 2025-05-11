using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float levelDurationInSeconds = 300;
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
    }

    private void GameOver()
    {
        Time.timeScale = 0;
    }

    private void LoadNextLevel()
    {
        if (nextLevelName != "Last")
            SceneManager.LoadScene(nextLevelName);
    }
}
