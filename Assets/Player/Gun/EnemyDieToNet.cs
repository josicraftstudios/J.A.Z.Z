using System;
using UnityEngine;

public class EnemyDieToNet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered by: " + collision.gameObject.name);

        if (collision.CompareTag("Net"))
        {
            //Debug.Log("Net detected! Destroying object.");
            Debug.Log(gameObject);
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
