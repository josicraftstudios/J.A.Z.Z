using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    //move stuff
    public int Speed;
    public int Jump;
    private Rigidbody2D body;
    public Transform GroundedRay;

    //Player stuff
    private PlayerState state = PlayerState.Norm;

    // Zipline stuff
    private int ZipDir = 1;
    private int ZipSpeed = 3;
    public float LookForZip = 0;
    private Transform currentZipline;

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

            case PlayerState.Zipline:

                transform.rotation = currentZipline.rotation;
                body.linearVelocity = currentZipline.right * ZipSpeed * ZipDir;

                if (Input.GetKey(KeyCode.Space))
                {
                    LeavZip();
                    Jumpping();
                }

                if (Input.GetKeyUp(KeyCode.E))
                {
                    LeavZip();
                }


                break;
        }

        if (Input.GetKeyDown(KeyCode.E)) { LookForZip = .4f; }
        LookForZip= Mathf.Max(0f,LookForZip-Time.deltaTime);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (state)
        {
            case PlayerState.Norm:
                if (collision.CompareTag("Zipline"))
                {
                    if (LookForZip > 0)
                    {
                        currentZipline = collision.transform;
                        state = PlayerState.Zipline;
                        transform.position = collision.ClosestPoint(transform.position);

                        ZipSpeed = Mathf.RoundToInt(body.linearVelocity.magnitude);

                        //Left or Right
                        if(body.linearVelocityX<0)//if (transform.position.x > collision.transform.position.x)
                        {
                            ZipDir = -1;
                        }
                        else
                        {
                            ZipDir = 1;
                        }

                        body.linearVelocity = Vector2.zero;
                        body.gravityScale = 0f;
                        LookForZip = 0;
                    }

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
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Jumpping();
                    }
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (state == PlayerState.Zipline && collision.transform == currentZipline)
        {
            LeavZip();
        }
    }

    private void Jumpping()
    {
        
            body.linearVelocity = new Vector2(body.linearVelocityX, Jump);
    }

    private void LeavZip()
    {
        state = PlayerState.Norm;

        transform.rotation = Quaternion.identity;
        body.gravityScale = 3;
    }
    enum PlayerState { Norm, Zipline };

}