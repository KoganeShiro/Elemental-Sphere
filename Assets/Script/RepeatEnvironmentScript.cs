using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatEnvironmentScript : MonoBehaviour
{
    public Vector3  start_pos;
    //public float    edge;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        //edge = gameObject.GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < start_pos.x - 5)
        {
            transform.position = start_pos;
        }
    }
}
