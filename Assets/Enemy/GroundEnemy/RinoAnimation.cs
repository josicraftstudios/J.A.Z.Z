using UnityEngine;

public class RinoAnimation : MonoBehaviour
{
    private SpriteRenderer Spr;
    public Sprite WingsUp;
    public Sprite WingsDown;
    private double xx;
    private Transform body;
    private int wings;

    private void Awake()
    {
        Spr = GetComponent<SpriteRenderer>();
        body = GetComponent<Transform>();
        InvokeRepeating("Flap", .2f, .2f);
        xx = body.position.x;
    }

    public void Flap()
    {
        if (wings == 1){ Spr.sprite = WingsUp; wings = 0; } else {  Spr.sprite = WingsDown; wings = 1; }

        if(xx< body.position.x)
        {
            Spr.flipX = true;
        }
        else
        {
            Spr.flipX = false;
        }
        xx = body.position.x;
    }
}
