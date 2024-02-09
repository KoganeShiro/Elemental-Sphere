using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float velocity;
    public Sprite spriteFlame; 
    public Sprite spriteIce;
    private SpriteRenderer spriteRenderer;
    private float previousYposition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousYposition = transform.position.y;
    }

    void Update()
    {
        float currentYPosition = transform.position.y;
        float currentXPosition = transform.position.x;

        if (currentYPosition >= 7.4)
        {
            spriteRenderer.sprite = spriteIce;
        }
        else if (currentYPosition <= -6.5)
        {
            spriteRenderer.sprite = spriteFlame;
        }
        //previousYPosition = currentYPosition;
        if (spriteRenderer.sprite == spriteIce)
            myRigidBody.gravityScale = -1;
        else
            myRigidBody.gravityScale = 1;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            myRigidBody.velocity = Vector2.up * velocity;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            myRigidBody.velocity = Vector2.down * velocity;

        if (currentXPosition <= -15.5)
            Debug.Log("Le personnage est mort.");
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (spriteRenderer.sprite == spriteFlame)
        {
            if (collision.gameObject.name == "ice_plate" || collision.gameObject.name == "water_plate")
            {
                Debug.Log("Le personnage est mort.");
                // Ajoutez ici le code pour gérer la mort du personnage
            }
            // Si le personnage est de type "spriteFlame" et entre en collision avec une plateforme de feu,
            // on désactive la collision entre le personnage et la plateforme de feu.
            else if (collision.gameObject.name == "fire_plate")
            {
                // Désactiver la collision entre le personnage et la plateforme de feu
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
            }
        }
        else if (spriteRenderer.sprite == spriteIce)
        {
            if (collision.gameObject.name == "fire_plate" || collision.gameObject.name == "lava_plate")
            {
                Debug.Log("Le personnage est mort.");
                // Ajoutez ici le code pour gérer la mort du personnage
            }
            else if (collision.gameObject.name == "water_plate")
            {
                // Désactiver la collision entre le personnage et la plateforme de feu
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
            }
        }
    }
}
