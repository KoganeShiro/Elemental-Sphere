using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMcScript : MonoBehaviour
{
    public Rigidbody2D fire_rigidbody;
    public float jump_strenght;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            fire_rigidbody.velocity = Vector2.up * jump_strenght;
        }
    }
}
