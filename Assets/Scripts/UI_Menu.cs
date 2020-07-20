using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject pGenerator;
    //public GameObject nextPuzzleButton;
    public GameObject SuccessPanel;
    public GameObject EndGamePanel;

    Puzzle_Manager pm;
    Ball_Conditions bc;

    public GameObject pausebutton;
    public GameObject continuebutton;
    public GameObject exitbutton;

    Button startButton;



    void Start()
    {
        pm = (Puzzle_Manager)FindObjectOfType(typeof(Puzzle_Manager));
        bc = (Ball_Conditions)FindObjectOfType(typeof(Ball_Conditions));
        startButton = (Button)FindObjectOfType(typeof(Button));
    }
    public void StartTheGame() 
    {
        Time.timeScale = 1.0f;
        StartPanel.SetActive(false);
        //pGenerator.SetActive(true);
        pm.newPuzzle();
        startButton.gameObject.SetActive(true);
        pausebutton.SetActive(true);
        //nextPuzzleButton.SetActive(true);
    }

    public void pauseTheGame() 
    {
        Time.timeScale = 0f;
        continuebutton.SetActive(true);
        pausebutton.SetActive(false);
    }

    public void continueTheGame()
    {
        Time.timeScale = 1f;
        continuebutton.SetActive(false);
        pausebutton.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EndTheGame() 
    {
        Time.timeScale = 0f;
        EndGamePanel.SetActive(true);
        startButton.gameObject.SetActive(false);
        pGenerator.SetActive(false);
    }

    public IEnumerator GetHereSuccessScreen()
    {
        SuccessPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        SuccessPanel.SetActive(false);
        yield return new WaitForSeconds(1);
    }
    public void restartPuzzle()
    {
        Time.timeScale = 1.0f;
        EndGamePanel.SetActive(false);
        pm.newPuzzle();
        pGenerator.SetActive(true);
        bc.resetTime();
        startButton.gameObject.SetActive(true);
    }
}