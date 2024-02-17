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
    public GameObject enemyAttack;
    private GameOverScript gameOverScript; // Référence au script GameOverScript
    public GameObject gameOverObject; // Référence au GameObject "GameOver"
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousYposition = transform.position.y;
        // Obtenez une référence au script GameOverScript attaché à l'objet GameOver
        gameOverScript = GameObject.Find("GameOver").GetComponent<GameOverScript>();
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

        if (currentXPosition <= -13.5)
        {
            Debug.Log("Le personnage est mort.");

            // Activez le GameOverRenderer dans le script GameOverScript
            gameOverObject.GetComponent<GameOverScript>().isOff = true;
            Destroy(gameObject);
        }

    }

/*void OnCollisionEnter2D(Collision2D collision)
{
    if (spriteRenderer.sprite == spriteFlame)
    {
        HandleFlameCollisions(collision);
    }
    else if (spriteRenderer.sprite == spriteIce)
    {
        HandleIceCollisions(collision);
    }
}

void HandleFlameCollisions(Collision2D collision)
{
    string collidedObjectName = collision.gameObject.name;

    switch (collidedObjectName)
    {
        case "ice_plate":
        case "water_plate" || "water-attack":
            HandlePlayerDeath();
            break;
    }
    if (collidedObjectName == "fire_plate")
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
    if (collidedObjectName == "water-attack")
        HandlePlayerDeath();
}

void HandleIceCollisions(Collision2D collision)
{
    string collidedObjectName = collision.gameObject.name;

    switch (collidedObjectName)
    {
        case "fire_plate":
        case "lava_plate":
            HandlePlayerDeath();
            break;

        case "water_plate":
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
            break;

        case "fire-attack":
        case "ice-attack":
            HandlePlayerDeath();
            break;
    }
}

void HandlePlayerDeath()
{
    Debug.Log("Le personnage est mort.");
    
    gameOverObject.GetComponent<GameOverScript>().isOff = true;
    Destroy(gameObject);
}
}*/


void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log(collision.gameObject.name);
    if (spriteRenderer.sprite == spriteFlame)
    {
        if (collision.gameObject.name == "ice_plate" || collision.gameObject.name == "water_plate" || collision.gameObject.name == "ice-attack(Clone)" || collision.gameObject.name == "water-attack(Clone)")
        {
            Debug.Log("dfsjhsfdsjd");
            Debug.Log("Le personnage est mort.");
            // Ajoutez ici le code pour gérer la mort du personnage
            gameOverObject.GetComponent<GameOverScript>().isOff = true;
            Destroy(gameObject);
        }
        // Si le personnage est de type "spriteFlame" et entre en collision avec une plateforme de feu,
        // on désactive la collision entre le personnage et la plateforme de feu.
        else if (collision.gameObject.name == "fire_plate")
        {
            // Désactiver la collision entre le personnage et la plateforme de feu
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
        }
        else if (collision.gameObject.name == "ice-attack" || collision.gameObject.name == "water-attack")
        {
            Debug.Log("Le personnage est mort ?.");
            // Ajoutez ici le code pour gérer la mort du personnage
            gameOverObject.GetComponent<GameOverScript>().isOff = true;
            Destroy(gameObject);
        }
    }
    else if (spriteRenderer.sprite == spriteIce)
    {
        if (collision.gameObject.name == "fire_plate" || collision.gameObject.name == "lava_plate")
        {
            Debug.Log("Le personnage est mort.");
            // Ajoutez ici le code pour gérer la mort du personnage
            gameOverObject.GetComponent<GameOverScript>().isOff = true;
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "water_plate")
        {
            // Désactiver la collision entre le personnage et la plateforme d'eau
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, true);
        }
        else if (collision.gameObject.name == "fire-attack(Clone)" || collision.gameObject.name == "ice-attack(Clone)")
        {
            Debug.Log("Le personnage est mort ?.");
            // Ajoutez ici le code pour gérer la mort du personnage
            gameOverObject.GetComponent<GameOverScript>().isOff = true;
            Destroy(gameObject);
        }
        // Réactiver la collision lorsque le personnage quitte la plateforme d'eau
        else if (collision.gameObject.name == "water_plate")
        {
            // Réactiver la collision entre le personnage et la plateforme d'eau
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider, false);
        }
    }
}
}
