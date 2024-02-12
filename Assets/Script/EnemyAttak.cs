using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EnemyAttak : MonoBehaviour
{
    public GameObject attack;
    public Rigidbody2D AttackRigidbody2D;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        AttackRigidbody2D = Vector2.left * 10;
    }
}
*/

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemyAttack;
    public GameObject sphere;
    public float spawner = 2;
    public float timer = 0;
    public float timer2 = 0;
    public float speed = 5f;
    public float heightOfSpawn = 7;

    void Update()
    {
        /*timer2 += Time.deltaTime;
        if (timer2 > 10)
            spawner = 0.9F;
        if (timer2 > 20)
            spawner = 0.8F;
        if (timer2 > 30)
            spawner = 0.7F;
        if (timer2 > 40)
            spawner = 0.6F;
        if (timer2 > 50)
            spawner = 0.5F;
        if (timer2 > 60)
            spawner = 0.3F;
        if (timer2 > 70)
            spawner = 0.2F;
        if (timer2 > 80)
            spawner = 0.1F;
        if (timer2 > 90)
            spawner = 0.05F;
*/
        if (timer >= spawner)
        {
            SpawnEnemyAttack();
            timer = 0;
        }
        else
            timer += Time.deltaTime;
    }
    void SpawnEnemyAttack()
{
    float y = sphere.transform.position.y;
    float highestPoint = transform.position.y + heightOfSpawn;

    // Sélection aléatoire d'un indice pour choisir une attaque parmi les enfants
    int randomChildIndex = Random.Range(0, enemyAttack.transform.childCount);

    // Récupérer l'attaque enfant sélectionnée aléatoirement
    Transform selectedAttack = enemyAttack.transform.GetChild(randomChildIndex);

    // Spawning at the rightmost point of the screen
    float screenRightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    GameObject newAttack = Instantiate(selectedAttack.gameObject, new Vector3(screenRightBoundary, y, 0), selectedAttack.rotation);

    // Access the sprite renderer of the attack
    SpriteRenderer attackRenderer = newAttack.GetComponent<SpriteRenderer>();

    // Set the sorting order to ensure the attack appears behind other objects
    attackRenderer.sortingOrder = -1;

    // Access the collider of the attack
    Collider2D attackCollider = newAttack.GetComponent<Collider2D>();

    // Disable the collider temporarily to prevent immediate collision
    attackCollider.enabled = false;

    // Move the attack to the left
    StartCoroutine(MoveAttackToLeft(newAttack));

    // Enable the collider after a delay
    StartCoroutine(EnableColliderDelayed(attackCollider));

    // Remove the attack after a specified duration
    StartCoroutine(RemoveAttackDelayed(newAttack, 5f)); // Adjust the time as needed
}

IEnumerator MoveAttackToLeft(GameObject attack)
{
    // Move the attack to the left
    while (attack.transform.position.x > -Screen.width)
    {
        attack.transform.Translate(Vector3.left * speed * Time.deltaTime);
        yield return null;
    }

    // Destroy the attack when it's off-screen to the left
    Destroy(attack);
}

IEnumerator EnableColliderDelayed(Collider2D collider)
{
    // Wait for a short delay before enabling the collider
    yield return new WaitForSeconds(0.1f);

    // Enable the collider
    collider.enabled = true;
}

IEnumerator RemoveAttackDelayed(GameObject attack, float delay)
{
    // Wait for the specified duration before removing the attack
    yield return new WaitForSeconds(delay);

    // Destroy the attack
    Destroy(attack);
}



    /*
    void SpawnEnemyAttack()
    {
        float lowestPoint = transform.position.y - heightOfSpawn;
        float highestPoint = transform.position.y + heightOfSpawn;

        // Sélection aléatoire d'un indice pour choisir une attack parmi les enfants
        int randomChildIndex = Random.Range(0, enemyAttack.transform.childCount);

        // Récupérer l'attack enfant sélectionnée aléatoirement
        Transform selectedAttack = enemyAttack.transform.GetChild(randomChildIndex);
        GameObject newAttack = Instantiate(selectedAttack.gameObject, new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, Random.Range(lowestPoint, highestPoint), 0), selectedAttack.rotation);
        Rigidbody2D attackRigidbody = newAttack.GetComponent<Rigidbody2D>();
        attackRigidbody.velocity = new Vector2(-speed, 0f);
    }
    */
}
