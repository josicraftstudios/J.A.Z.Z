using UnityEngine;

public class FrogBulletScribt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform body;
    private float Speed = 20;
    private float Range = 1.5f;

    private void Awake()
    {
        body = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        body.position += body.right*Speed * Time.deltaTime;

        Range -= Time.deltaTime;
        if(Range<0)
        {
            Destroy(gameObject);
        }

    }

}
