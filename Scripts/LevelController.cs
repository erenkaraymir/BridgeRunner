using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController levelController;
    public GameObject startMenu, gameMenu, gameOverMenu, finishMenu;
    public Text currentLevelText, nextLevelText;
    public int currentLevel;
    public Slider levelProgressBar;
    public float maxDistance;
    public GameObject finishLine;

    public enum GameState
    {
        Startmenu,
        GameMenu,
        GameOverMenu,
        FinishMenu,

    }
    public GameState gameState;

    void Start()
    {
        levelController = this;
        gameState = GameState.Startmenu;

        
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        //currentLevel = 0;
        if (SceneManager.GetActiveScene().name != "Level " + currentLevel)
        {
            SceneManager.LoadScene("Level " + currentLevel);
        }
        else
        {
            currentLevelText.text = (currentLevel + 1).ToString();
            nextLevelText.text = (currentLevel + 2).ToString();
        }
    }

    void Update()
    {
        if (gameState == GameState.GameMenu)
        {
           // PlayerController player = PlayerController.playerController;
            float distance = finishLine.transform.position.z - PlayerController.playerController.transform.position.z;
            levelProgressBar.value = 1 - (distance * 1 / maxDistance);
        }
    }

    public void StartLevel()
    {
        maxDistance = finishLine.transform.position.z - PlayerController.playerController.transform.position.z;
        //PlayerMovementController.playerMovementController._forwardSpeed = 10;
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        PlayerController.playerController.animator.SetBool("running",true);
        gameState = GameState.GameMenu;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level " + (currentLevel + 1));
    }

    public void GameOver()
    {
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        gameState = GameState.GameOverMenu;
        PlayerController.playerController.animator.SetBool("running", false);
    }

    public void FinishGame()
    {
        PlayerPrefs.SetInt("currentLevel", (currentLevel + 1));
        gameMenu.SetActive(false);
        finishMenu.SetActive(true);
        gameState = GameState.FinishMenu;
    }
}
