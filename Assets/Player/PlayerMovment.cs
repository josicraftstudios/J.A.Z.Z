using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    //move stuff
    public float Speed;
    float Speed_change = 2;
    public int Jump;
    private Rigidbody2D body;
    public Transform GroundedRay;

    public AudioSource audioSource;
    public AudioClip Realod;
    public AudioSource WalkAudio;
    public AudioSource ZiplineAudio;


    //Player stuff
    private PlayerState state = PlayerState.Norm;
    public GameObject Gun;

    // Zipline stuff
    private int ZipDir = 1;
    private int ZipSpeed = 3;   
    private float LookForZip = 0;
    private bool SpaceBarPrees = false;
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

                if (SpaceBarPrees)
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
        //zipline spacebar
        SpaceBarPrees = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceBarPrees = true;
        }


    }

    /*if (state == PlayerState.Zipline)
        {

            ZiplineAudio.Play();
        }
        else if (state == PlayerState.Norm)
{
    ZiplineAudio.Stop();
}*/

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
                        ZiplineAudio.Play();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NewNet"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(Realod);
            Gun.GetComponent<GunScript>().Loaded++;
            
        }

        if (collision.CompareTag("Web"))
        {
            print(Speed);
            Speed = Speed / Speed_change;
            print(Speed);


        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block" && body.linearVelocity.x != 0 && !WalkAudio.isPlaying)
        {
            WalkAudio.Play();

        }
        else if (collision.gameObject.tag != "Block" || collision.gameObject.tag == "Block" && body.linearVelocity.x == 0)
        {
            WalkAudio.Stop();

        }
        

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
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (state == PlayerState.Zipline && collision.transform == currentZipline)
        {
            LeavZip();
        }
        if (collision.CompareTag("Web"))
        {
            Speed = Speed*Speed_change;


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
        ZiplineAudio.Stop();
    }
    enum PlayerState { Norm, Zipline };

}