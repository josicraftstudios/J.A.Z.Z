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

        RaycastHit2D hit = Physics2D.Raycast(GroundedRay.position, Vector2.down, 1.2f);
        bool isGrounded = hit.collider != null && hit.collider.CompareTag("Block");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, Jump);
        }

    }


}