using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SimpleGameManager : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    private int currentScore = 0;

    public void AddToScore(int amountToAdd)
    {   
        currentScore += amountToAdd;
        scoreText.text = $"Score: {currentScore}";
    }


    void TestScoreUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AddToScore(1);
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
