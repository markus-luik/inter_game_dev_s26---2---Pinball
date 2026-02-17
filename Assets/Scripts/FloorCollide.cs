using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class FloorCollide : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float forceValue = 1.0f;
    private AudioSource audioSource;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); //Gets audio source
    }

    void ChangeColor() {
        // spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
    }

     private void PlaySound()
    {
        if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip); //plays the clip assigned
            }else{
                Debug.Log("AudioSource or AudioResource is missing on flipper!");
                return;
            }
    }

    void OnCollisionEnter2D(Collision2D col) {
        ChangeColor();
        col.rigidbody.AddForce(Vector2.up * forceValue, ForceMode2D.Impulse);
        PlaySound();//plays sound
    }

    void FixedUpdate()
    {
        
    }
}