using System;
using UnityEngine;

public class EnemyDieToNetSpider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Net"))
        {
            Destroy(gameObject);
            print("Wow");
        }
    }
}
