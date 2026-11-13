using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int Speed;
    public int Jump;
    private Rigidbody2D body;

    public Transform GroundedRay;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.linearVelocityY);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Jumpping();
        }
    }

    private void Jumpping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, Jump);
        }
    }


}