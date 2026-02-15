using UnityEngine;

public class BallManagerScript : MonoBehaviour
{

    private Vector3 startingPosition;

private Rigidbody2D rb;

    void Awake()
    {
        //saves starting position
        startingPosition = transform.position;

        //couldn't figure this debug message out
        Debug.Log("Player started at " + startingPosition);

        //changing center of mass
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = new Vector2(0f, -0.1f);
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
