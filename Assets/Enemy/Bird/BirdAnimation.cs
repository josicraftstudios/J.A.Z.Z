using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    private SpriteRenderer Spr;
    public Sprite WingsUp;
    public Sprite WingsDown;
    private int wings;

    private void Awake()
    {
        Spr = GetComponent<SpriteRenderer>();
        InvokeRepeating("Flap", .4f, .4f);
    }

    public void Flap()
    {
        if (wings == 1){ Spr.sprite = WingsUp; wings = 0; } else {  Spr.sprite = WingsDown; wings = 1; }
    }
}
