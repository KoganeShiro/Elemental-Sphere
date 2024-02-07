using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformSpawn : MonoBehaviour
{
    public GameObject plateform;
    public float spawn_rate = 2;
    private float timer = 0;
    public float height = 10;
    // Start is called before the first frame update
    void Start()
    {
        spwan_plateform();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawn_rate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spwan_plateform();
            timer = 0;
        }
    }
    void spwan_plateform()
    {
        float lower_point = transform.position.y - height;
        float higher_point = transform.position.y + height;
        Instantiate(plateform, new Vector3(transform.position.x, Random.Range(lower_point, higher_point), 0), transform.rotation);
    }
}
