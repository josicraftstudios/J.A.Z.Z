using UnityEngine;

public class GunArt : MonoBehaviour
{
    public Sprite Gun1_0;
    public Sprite Gun1_1;
    public Sprite Gun2_0;
    public Sprite Gun2_1;
    public Sprite Gun2_2;

    private GunScript data;
    private SpriteRenderer spriteRenderer;
    private Transform body;

    private void Awake()
    {
        data = GetComponent<GunScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (data.Net2) {
            if (data.Loaded > 1)
            {
                spriteRenderer.sprite = Gun2_2;
            }
            else if (data.Loaded > 0) {
                
                    spriteRenderer.sprite = Gun2_1;
                }else{
                    spriteRenderer.sprite = Gun2_0;
                }
            } else
            {
                if (data.Loaded > 0)
                {
                    spriteRenderer.sprite = Gun1_1;
                }
                else
                {
                    spriteRenderer.sprite = Gun1_0;
                }
            }

        if (body.eulerAngles.z >= 90 && body.eulerAngles.z <= 270)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY=false;
        }
    }
}
