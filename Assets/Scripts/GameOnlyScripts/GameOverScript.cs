using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //reference to pause button to then hide it in game over
    public GameObject pauseButton;
    //reference to gameOverScreen as a game object 
    public GameObject gameOverScreen;

    public bool pauseShowing = true;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseShowing == false)
        {
            pauseButton.SetActive(true);
            pauseShowing = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        pauseButton.SetActive(false);
        pauseShowing = false;
    }
}
