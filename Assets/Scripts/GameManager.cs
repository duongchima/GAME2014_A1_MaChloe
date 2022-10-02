using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
GameManager
Name: Chloe Ma 
Student #: 101260013
Date last modified: 02/10/22
Description: Used to manage the game and game flow.
 */
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel, pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameOverPanel.SetActive(true);
        }
    }
    // resumes the game
    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    // creating function for pause button to call
    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
}
