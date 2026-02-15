using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class FloorCollide : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float forceValue = 1.0f;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void ChangeColor() {
        // spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
    }

    void OnCollisionEnter2D(Collision2D col) {
        ChangeColor();
        col.rigidbody.AddForce(Vector2.up * forceValue, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        
    }
}