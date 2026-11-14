using UnityEngine;

public class NetScribt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform body;
    private float Speed = 30;
    private float Range = .2f;

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

    public void InitializeMomentum(float velocity)
    {
        Speed += velocity;
    }

}
