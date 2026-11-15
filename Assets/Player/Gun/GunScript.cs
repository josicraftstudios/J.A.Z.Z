using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform Player;
    private Vector3 TargetPos;
    private Transform body;

    public bool Net2 = true;

    public GameObject Net;
    public GameObject NetPickup;
    public ParticleSystem burstPrefab;


    //audio
    public AudioSource audioSource;
    public AudioClip soundEffect;
    public AudioClip soundNewNet;
    public int Loaded = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        body = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Pos
        float lagSpeed = 30f;
        TargetPos= Player.position+new Vector3(0,-.1f,0)+body.right*.5f;
        body.position = Vector3.Lerp(body.position, TargetPos, lagSpeed * Time.deltaTime);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - body.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        body.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        #endregion


        #region Shooting
        if(Loaded>0 && Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(soundEffect);
            Loaded--;
            //spawn new net
            Invoke("NewNet", 5f);

            //Shoot Net
            GameObject spawnedNet = Instantiate(Net, body.position, body.rotation);
            Rigidbody2D playerRb = Player.GetComponent<Rigidbody2D>();
            Vector2 playerVelocity = playerRb != null ? playerRb.linearVelocity : Vector2.zero;

            //momentum
            Vector2 gunDirection = body.right;
            Vector2 moveDirection = playerRb.linearVelocity.sqrMagnitude > 0.001f
                ? playerRb.linearVelocity.normalized
                : Vector2.zero;
            float alignmentFactor = Vector2.Dot(gunDirection, moveDirection);
            float currentSpeed = playerRb.linearVelocity.magnitude;
            float carriedSpeed = currentSpeed * alignmentFactor;
            NetScribt netScript = spawnedNet.GetComponent<NetScribt>();
            if (netScript != null)
            {
                netScript.InitializeMomentum(carriedSpeed);
            }
        }
        #endregion
    }

    private void NewNet()
    {
       
        GameObject[] pickupPoints = GameObject.FindGameObjectsWithTag("PickupPoint");
        int randomIndex = Random.Range(0, pickupPoints.Length);

        Vector3 Pos = pickupPoints[randomIndex].transform.position;
        Instantiate(NetPickup, Pos,Quaternion.identity);
        if (burstPrefab != null)
        {
            ParticleSystem spawnedEffect = Instantiate(burstPrefab, Pos, Quaternion.identity);
            spawnedEffect.Play();
            Destroy(spawnedEffect.gameObject, .41f);
            audioSource.PlayOneShot(soundNewNet,.5f);
        }
    }
}
