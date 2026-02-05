using UnityEngine; //allows UNITY to be used - don't touch this yet


    //SimpleMoveScript is TitleCase which is used for classes and functions
public class MySimpleMove : MonoBehaviour //for a class to be used in a scene, it NEEDS to be a MONOBEHAVIOR //Keep the names of classes simple
{

    /*
        [SerializeField] - makes even PRIVATE variables accessible in the Unity editor; encapsulation (keep in mind, any, )
        private - accessor; if PRIVATE, nothing outside of this script can access this variable; if PUBLIC, the variable is accessible in the Unity editor by default BUT if something is public other things can also mess with this variable
        float - type of variable
        playerSpeed - name of variable; camelCase is used for variables
    */
    ///<summary>
    ///This is the Player SPEED.
    ///</summary>
    [SerializeField] private float playerSpeed = 1.0f; //private doesn't need to necessarily be here

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //Start will run first IN THIS PIECE OF CODE (first stir of the soup)
    {
        Debug.Log("Hello, this is start");
        
    } //there are also other voids 

    /*This 
    is
    a
    block
    comment
    */

    /*
        private - accessor; who can access it (you don't have to write this here, it defaults to private)
        Void - return type; what the function returns; void means None
        PrintHello - name of the function
        () - arguments
        {} - actual code fo function
        Where this function is, doesn't matter but it NEEDS to be in the monobehavior class
    */
    ///<summary>
    ///This function prints out "Hello" when we hit the spacebar.
    ///</summary>
    private void PrintHello(){
        if (Input.GetKeyDown(KeyCode.Space)){ //this is the simplest/most basic way to check input in Unity
            //GetKey (keeps checking every frame) is different from GetKeyDown (checks once)
            Debug.Log("Hello!");
        }
    }

    /// <summary>
    /// Controls the Player MOVEMENT.
    /// </summary>
    private void PlayerInput()
    {
        //right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(translation:Vector3.right*playerSpeed*Time.deltaTime);
        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(translation:Vector3.left*playerSpeed*Time.deltaTime);
        }
        //up
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(translation:Vector3.up*playerSpeed*Time.deltaTime);
        }
        //down
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(translation:Vector3.down*playerSpeed*Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if we press the space bar, we print out 'space bar'
        PrintHello();
        PlayerInput();
        // Debug.Log("Hello, this is update");
    }
}
