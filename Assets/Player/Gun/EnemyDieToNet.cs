using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDieToNet : MonoBehaviour
{
    private Inventory Inv;
    public AudioSource audioSource;
    public AudioClip soundEffect1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        GameObject[] I = GameObject.FindGameObjectsWithTag("Inventory");
        Inv = I[0].GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered by: " + collision.gameObject.name);

        if (collision.CompareTag("Net"))
        {
            //Debug.Log("Net detected! Destroying object.");
            Debug.Log(gameObject);
            Inv.Add_bird();
            audioSource.PlayOneShot(soundEffect1);
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
