using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int Speed;
    public int Jump;
    private Rigidbody2D body;

    public Transform GroundedRay;

    private PlayerState state;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (state)
        {
            case PlayerState.Norm:
                body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.linearVelocityY);
                break;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (state)
        {
            case PlayerState.Norm:
                if (collision.gameObject.tag == "Zipline")
                {
                    Jumpping();
                }
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (state)
        {
            case PlayerState.Norm:
                if (collision.gameObject.tag == "Block")
                {
                    Jumpping();
                }
                break;
        }
    }

    private void Jumpping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, Jump);
        }
    }

    enum PlayerState { Norm, Zipline };

}