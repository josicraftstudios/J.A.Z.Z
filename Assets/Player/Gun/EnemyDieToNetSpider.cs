using System;
using UnityEngine;

public class EnemyDieToNetSpider : MonoBehaviour
{
    private Inventory Inv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        GameObject[] I = GameObject.FindGameObjectsWithTag("Inventory");
        Inv = I[0].GetComponent<Inventory>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Net"))
        {
            print(gameObject.name);
            //Destroy(transform.parent.gameObject);
            Destroy(gameObject);
            switch (gameObject.name)
            {
                case "Spider(Clone)":
                    Inv.Add_spider();
                    break;
                case "GroundEnemy(Clone)":
                    Inv.Add_ground();
                    break;

            }
            //print("Wow");
        }
    }
}
