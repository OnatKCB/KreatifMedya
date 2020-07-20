using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SocialPlatforms;


public class Puzzle_Manager : MonoBehaviour
{

    // THESE CODES ARE HAD TAKEN FROM CONDITIONS.CS
    GameObject Puzzle;
    GameObject Obstacle;
    GameObject Ball;
    GameObject Danger;
    Button startButton;
    //----------------------------------------//
    //[SerializeField]
    //int level;
    [SerializeField]
    int totalScore;
    [SerializeField]
    int score = 0;
    public Text ScoreText;
    //public Text levelText;
    public Text totalScoreText;

    public bool puzzleSolved = false;
    //----------------------------------------//
    public Text puzzlebody;
    public Text puzzleobstacle;
    public Text puzzleDanger;

    //----------------------------------------//


    //THESE CODES ARE OLD BUT THEY ARE WORKING, SO I WILL PUT THEM HERE FOR NOW

    //[SerializeField]
    //GameObject[] puzzles; //ARRAY BURADA!
    int randomPuzzle;
    
    //GameObject thePuzzle;

    [SerializeField]
    List<GameObject> puzzleBodies = new List<GameObject>();
    [SerializeField]
    List<GameObject> puzzleObstacles = new List<GameObject>();
    [SerializeField]
    List<GameObject> puzzleDangers = new List<GameObject>();
    //----------------------//
    GameObject thePuzzleBody;
    GameObject thePuzzleObstacle;
    GameObject thePuzzleDanger;

    int randomPuzzleBody;
    int randomPuzzleObstacle;
    int randomPuzzleDanger;

    //----------------------//

    UI_Menu uimenu;
    GoogleMobileAdsScript ads;

    //----------------------//


    void Awake()
    {
        Puzzle = GameObject.FindGameObjectWithTag("Puzzle");
        Obstacle = GameObject.FindGameObjectWithTag("Obstacle");
        Ball = GameObject.FindGameObjectWithTag("Ball");
        Danger = GameObject.FindGameObjectWithTag("Danger_Object");

    }
    void Start()
    {
        //newPuzzle();
        //puzzleLoop();
        PlayerPrefs.SetInt("Score", score);
        ScoreText.text = score.ToString();
        totalScoreText.text = PlayerPrefs.GetInt("Total Score", 0).ToString();
        ScoreText.text = score.ToString();
        
        //startButton.transform.Find("Start_Button");
        uimenu = (UI_Menu)FindObjectOfType(typeof(UI_Menu));
        ads = (GoogleMobileAdsScript)FindObjectOfType(typeof(GoogleMobileAdsScript));

        //gameads = (GameADS)FindObjectOfType(typeof(GameADS));
        //gameads.RequestBanner();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPrefs.SetInt("Score", score);
        ScoreText.text = score.ToString();
        puzzlebody.text = randomPuzzleBody.ToString();
        puzzleobstacle.text = randomPuzzleObstacle.ToString();
        puzzleDanger.text = randomPuzzleDanger.ToString();
}
    public void newPuzzle()
    {
        Destroy(thePuzzleBody);
        Destroy(thePuzzleObstacle);
        Destroy(thePuzzleDanger);
        //Environment ve development production eklenecek.
        thePuzzleBody = Instantiate(puzzleBodies[0]);
        thePuzzleObstacle = Instantiate(puzzleObstacles[0]);
        thePuzzleDanger = Instantiate(puzzleDangers[0]);
        //startButton.gameObject.SetActive(true);
    }
    public void nextPuzzle() 
    {
        Destroy(thePuzzleBody);
        Destroy(thePuzzleObstacle);
        Destroy(thePuzzleDanger);
        //level++;
        //Debug.Log(level);
        randomPuzzleBody = Random.Range(0, puzzleBodies.Count);
        randomPuzzleObstacle = Random.Range(0, puzzleObstacles.Count);
        randomPuzzleDanger = Random.Range(0, puzzleDangers.Count);
        thePuzzleBody = Instantiate(puzzleBodies[randomPuzzleBody]);
        thePuzzleObstacle = Instantiate(puzzleObstacles[randomPuzzleObstacle]);
        thePuzzleDanger = Instantiate(puzzleDangers[randomPuzzleDanger]);
        totalScoreText.text = score.ToString();
        //startButton.gameObject.SetActive(true);
        //levelText.text = level.ToString();
    }
    public void Succeed()
    {
        Destroy(Puzzle);
        Destroy(Obstacle);
        Destroy(Ball);
        Destroy(Danger);
        Destroy(Danger);
        Destroy(Danger);
        Destroy(Danger);
        Destroy(Danger);
        score++;
        PlayerPrefs.SetInt("Score", score);
        ScoreText.text = score.ToString();
        uimenu.GetHereSuccessScreen();
    }
    public void Failure()
    {
        Destroy(Puzzle);
        Destroy(Obstacle);
        Destroy(Ball);
        Destroy(Danger);
        totalScore = score;
        PlayerPrefs.SetInt("Total Score", totalScore);
        if(score > PlayerPrefs.GetInt("Total Score", totalScore))
        {
            totalScoreText.text = score.ToString();
            PlayerPrefs.SetInt("Total Score", score);
        }
        this.puzzleSolved = false;
        score = 0;
        //level = 0;
        uimenu.EndTheGame();
        ads.GameOver();
        //gameads.GameOver();
        //endgamepanel.setactive(true);
        //startButton.gameObject.SetActive(false);
    }
}