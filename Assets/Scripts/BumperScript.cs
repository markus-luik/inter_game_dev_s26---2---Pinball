using UnityEngine;

public class BumperScript : MonoBehaviour
{
    [SerializeField] private int amountToAdd;
    [SerializeField] private float bounceForce = 5f;
    [SerializeField] private float cooldownTime = 0.2f;
    private bool canBounce = true;
    private SpriteRenderer spriteRenderer;

    SimpleGameManager GM;

    
    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SimpleGameManager>(); //finds ONE game object with GameManager tag and gets its script. 

        spriteRenderer = GetComponent<SpriteRenderer>();
    } 

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!canBounce) return;

        Rigidbody2D rb = col.rigidbody;
        if (rb != null)
        {
            Vector2 bounceDir = col.GetContact(0).normal; //gets bounce direction
            rb.AddForce(-bounceDir * bounceForce, ForceMode2D.Impulse); //adds bounc force

            StartCoroutine(BounceCooldown()); //starts bounce cooldown
        }
    }

    private System.Collections.IEnumerator BounceCooldown()
    {
        //updates if can bounce, changes color accordingly
        canBounce = false;
        spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f);
        yield return new WaitForSeconds(cooldownTime);
        canBounce = true;
        spriteRenderer.color = new Color(1.0f,1.0f,1.0f);
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
