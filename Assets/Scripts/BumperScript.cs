using UnityEngine;

public class BumperScript : MonoBehaviour
{
    [SerializeField] private int amountToAdd;
    SimpleGameManager GM;
    
    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SimpleGameManager>(); //finds ONE game object with GameManager tag and gets its script. 
    } 


    void TestUpdateScore()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GM.AddToScore(amountToAdd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TestUpdateScore();
    }
}
