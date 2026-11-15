using NUnit;
using UnityEngine;
using UnityEngine.Audio;

public class Frog : MonoBehaviour
{
    public Transform Head;
    private Transform Player;

    public GameObject Bullet;

    public SpriteRenderer Spr;
    public AudioSource audioSource;
    public AudioClip soundEffect1;
    public AudioClip soundEffect2;

    public Sprite Face;
    public Sprite FaceReady;
    public Sprite FaceFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject[] I = GameObject.FindGameObjectsWithTag("Player");
        Player = I[0].GetComponent<Transform>();
        BacktoBlack();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Player.position-Head.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Head.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void ReadyUp()
    {
        audioSource.PlayOneShot(soundEffect1);
        Invoke("Fire", .8f);
        Spr.sprite = FaceReady;
    }

    private void Fire()
    {
        audioSource.PlayOneShot(soundEffect2);
        Invoke("BacktoBlack", .5f);
        Spr.sprite = FaceFire;
        for(float i = 0; i < .7f; i += .1f)
        {
            Invoke("Shoot", i);
        }
    }

    private void Shoot()
    {
        GameObject spawnedNet = Instantiate(Bullet, Head.position, Head.rotation);
    }

    private void BacktoBlack()
    {
        Invoke("ReadyUp", 5);
        Spr.sprite= Face;
    }
}
