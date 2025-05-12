using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    // Assign all the buttons directly through the inspector
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button level6Button;

    void Start()
    {
        // Check PlayerPrefs to unlock levels
        CheckAndUnlockLevels();

        // Add listeners for the buttons
        level1Button.onClick.AddListener(() => LoadLevel(1));
        level2Button.onClick.AddListener(() => LoadLevel(2));
        level3Button.onClick.AddListener(() => LoadLevel(3));
        level4Button.onClick.AddListener(() => LoadLevel(4));
        level5Button.onClick.AddListener(() => LoadLevel(5));
        level6Button.onClick.AddListener(() => LoadLevel(6));
    }

    void CheckAndUnlockLevels()
    {
        // Check if each level is unlocked and enable/disable buttons
        level1Button.interactable = true;  // Level 1 is always unlocked
        level2Button.interactable = PlayerPrefs.GetInt("Level2", 0) == 1;
        level3Button.interactable = PlayerPrefs.GetInt("Level3", 0) == 1;
        level4Button.interactable = PlayerPrefs.GetInt("Level4", 0) == 1;
        level5Button.interactable = PlayerPrefs.GetInt("Level5", 0) == 1;
        level6Button.interactable = PlayerPrefs.GetInt("Level6", 0) == 1;
    }

    // Load the level when a button is clicked
    void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);  // Make sure your scenes are named Level1, Level2, etc.
    }
}
