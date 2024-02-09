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
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousYposition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float currentYPosition = transform.position.y;

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

        //Touches pour bouger le personnage
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            myRigidBody.velocity = Vector2.up * velocity;
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
            myRigidBody.velocity = Vector2.down * velocity;
    }
}
