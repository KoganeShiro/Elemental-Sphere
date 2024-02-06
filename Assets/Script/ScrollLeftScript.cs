using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeftScript : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Renderer bg_renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bg_renderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        //transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
