using UnityEngine;

public class BallManagerScript : MonoBehaviour
{

    private Vector3 startingPosition;

    void Awake()
    {
        //saves starting position
        startingPosition = transform.position;

        //couldn't figure this debug message out
        Debug.Log("Player started at " + startingPosition);
    }

    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = startingPosition;
        }
    }

    void Update()
    {
        PlayerInput();
    }
}
