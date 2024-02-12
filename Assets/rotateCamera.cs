using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotateCamera : MonoBehaviour
{
    private rotateCamera cameraShaker;
    public float duration = 0.5f;
    public float magnitude = 0.1f;
    private float timeSinceLastShake = 0f;
    //private bool IsShaking = false;
    private void Start()
    {
        cameraShaker = GetComponent<rotateCamera>();
    }
    private void Update()
    {
        if (timeSinceLastShake >= (Random.Range(10, 42)))
        {
            //IsShaking = true;
            StartCoroutine(Shake(duration, magnitude));
            //call a function to rotate the image;
            timeSinceLastShake = 0f;
            //IsShaking = false;
        }
        else
        {
            timeSinceLastShake += Time.deltaTime;
        }
    }
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}