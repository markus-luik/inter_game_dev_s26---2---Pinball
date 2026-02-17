using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SimpleGameManager : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    private int currentScore = 0;

    /// <summary>
    /// Adds 1 to the sore if you press down the F key
    /// </summary>
    public void AddToScore(int amountToAdd)
    {   
        currentScore += amountToAdd;
        scoreText.text = $"Score: {currentScore}";
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



    /// <summary>
    /// Reloads the scene when you hold leftShift and press down R on the keyboard
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

    void Update()
    {
        TestScoreUpdate();
        ReloadSceneInput();
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