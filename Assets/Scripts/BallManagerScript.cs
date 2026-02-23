using UnityEngine;

public class BallManagerScript : MonoBehaviour
{

    //GameManager reference
    SimpleGameManager GM;
    private Vector3 startingPosition;
    private Rigidbody2D rb;

    //life boolean
    private bool lifeAlreadyLost = false;

    void Awake()
    {
        //saves starting position
        startingPosition = transform.position;

        //couldn't figure this debug message out
        Debug.Log("Player started at " + startingPosition);

        //changing center of mass
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = new Vector2(0f, -0.1f);

        //find game manager
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SimpleGameManager>();
    }

    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ResetBallPosition();
        }
    }

    /// <summary>
    /// Resets ball to where it started
    /// </summary>
    public void ResetBallPosition()
    {
        rb.position = startingPosition;
    }

    /// <summary>
    /// Reduces life if ball goes into life reducer
    /// </summary>
    /// <param name="col">Other objects collider</param>
    void OnTriggerEnter2D(Collider2D col) {
       if (col.CompareTag("LifeReducer") && !lifeAlreadyLost)
        {
            GM.lifeReducer();
            lifeAlreadyLost = true;
            Debug.Log("Life lost. Lives can not be lost right now.");
        }
    }

    void OnTriggerExit2D(Collider2D col) {
       if (col.CompareTag("LifeReducer") && lifeAlreadyLost)
        {
            lifeAlreadyLost = false;
            Debug.Log("Lives can be lost again");
        }
    }

    void Update()
    {
        //PlayerInput();
    }
}
