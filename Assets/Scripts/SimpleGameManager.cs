using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SimpleGameManager : MonoBehaviour
{
    //Score
    private int currentScore = 0;
    private int highScore = 0;
    [SerializeField] private TMP_Text scoreText;

    //Life text
    [SerializeField] private TMP_Text livesText;
    //Ball reference
    public GameObject ball;
    BallManagerScript ballScript;
    //Lives
    [SerializeField] private int startingLives = 3;
    private int lives;
    private int minimumLives = 0;
    public bool ballCanLive = true;

    //Sound
    private bool musicPlaying = false;
    private AudioSource audioSource;

    void Awake()
    {
        lives = startingLives;
        ballCanLive = true;
        audioSource = GetComponent<AudioSource>(); //Gets audio source

        //find game manager
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallManagerScript>();
    }

    /// <summary>
    /// Adds 1 to the sore if you press down the F key
    /// </summary>
    public void AddToScore(int amountToAdd)
    {   
        currentScore += amountToAdd;
        UpdateScore();
    }

    /// <summary>
    /// Updates score text
    /// </summary>
    void UpdateScore()
    {
        scoreText.text = $"Score: {currentScore} (Highscore: {highScore})";
    }
    
    /// <summary>
    /// Manages lives
    /// </summary>
    public void lifeManager()
    {   
        livesText.text = $"{lives} balls remaining";

        if (lives <= minimumLives)
        {
            DisableBall();
            livesText.text = $"0 balls remaining! Press R to restart.";
            if (currentScore > highScore)
            {
                highScore = currentScore;
            }
        }
    }

    /// <summary>
    /// Reduces life by 1
    /// </summary>
    public void lifeReducer()
    {
        lives -= 1;
        lifeManager();
        Debug.Log("Life is reduced!");
        ballScript.ResetBallPosition();
    }

    /// <summary>
    /// Hides Ball
    /// </summary>
    void DisableBall()
    {
        if (ball != null && ballCanLive)
        {
            ballCanLive = false;
            ball.SetActive(false); // false to hide, true to show
            //Destroy(GameObject.FindWithTag("Ball"));
        }
    }
    /// <summary>
    /// Shows object
    /// </summary>
    void EnableBall()
    {
        if (ball != null && !ballCanLive)
        {
            ballCanLive = true;
            ball.SetActive(true);
            ballScript.ResetBallPosition();
        }
    }

    void RestartGame()
    {
        Debug.Log("Game restarting....");
        lives = startingLives;
        Debug.Log($"Lives {lives}");
        currentScore = 0;
        Debug.Log($"Score {currentScore}");
        Debug.Log($"Highscore {highScore}");
        EnableBall();
        Debug.Log("Ball Enables");
        UpdateScore();
        Debug.Log("Score redrawn");
        Debug.Log("....Restarted!");
    }

    /// <summary>
    /// DEBUG: Adds 1 to score if F is pressed, 40 if G is pressed   
    /// </summary>
    void TestScoreUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            AddToScore(1);
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            AddToScore(40);
        }
    }

    private void ToggleMusic()
    {   
        if (audioSource != null)
        {
            if (!musicPlaying){
                audioSource.Play(); //plays the clip assigned
                musicPlaying = true;
            }else{
                audioSource.Stop();   
                musicPlaying = false;
            }
        }else{
            Debug.Log("AudioSource or AudioResource is missing on GameManager!");
            return;
        }
    }

    /// <summary>
    /// DEBUG: Reloads the scene when you hold leftShift and press down R on the keyboard
    /// </summary>
    void ReloadSceneInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reloads the current scene that we are in
            }
        }
    }

    /// <summary>
    /// Restarts game if ball can not live and R is pressed
    /// </summary>
    void GameRestartInput()
    {
        if (!ballCanLive && Input.GetKey(KeyCode.R))
        {
            RestartGame();
        }
    }

    void Update()
    {
        //TestScoreUpdate();
        //ReloadSceneInput();
        GameRestartInput();
        lifeManager();

        if (Input.GetKey(KeyCode.Alpha4))
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ToggleMusic();
            }
        }
    }
}


///IN CLASS
// 
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;

// public class SimpleGameManager : MonoBehaviour {
//     [SerializeField] private TMP_Text scoreText;
//     private int currentScore = 0;

//     public void AddToScore(int amt) {
//         currentScore += amt;
//         scoreText.text = $"Score: {currentScore}";
//     }

//     /// <summary>
//     /// Adds 1 to the sore if you press down the F key
//     /// </summary>
//     public void AddToScore() {
//         currentScore += 1;
//         scoreText.text = $"Score: {currentScore}";
//         // scoreText.text = "Score:" + currentScore.ToString();
//         // scoreText.text = "Hello, Mr: " + currentScore +". I love to you!" + currentScore + ", do you love me?";
//         // scoreText.text = $"Hello, Mr {currentScore}! I love you! {currentScore}, do you love me?";
//     }

//     void TestScoreInput() {
//         if (Input.GetKeyDown(KeyCode.F)) {
//             AddToScore();
//         }
//         if (Input.GetKeyDown(KeyCode.G)) {
//             AddToScore(40);
//         }
//     }
    
//     /// <summary>
//     /// Reloads the scene when you press down R on the keyboard
//     /// </summary>
//     void ReloadSceneInput() {
//         if (Input.GetKey(KeyCode.LeftShift))
//             if (Input.GetKeyDown(KeyCode.R)) {
//                 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//             }
//     }

//     private void Update() {
//         TestScoreInput();
//         ReloadSceneInput();
//     }
// }