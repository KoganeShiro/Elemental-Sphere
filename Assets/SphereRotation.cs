using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Empêcher la rotation de la sphère
    }

    private void FixedUpdate()
    {
        // Supprimer le mouvement horizontal
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
}