using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    private Transform body;
    public int speed=4;
    private float leftBound;
    private float rightBound;
    private int direction = 1;


    private void Awake()
    {
        body = GetComponent<Transform>();
    }

    private void Start()
    {
        Camera cam = Camera.main;
        float distanceToCamera = Mathf.Abs(cam.transform.position.z - transform.position.z);
        leftBound = cam.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + .5f;
        rightBound = cam.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - .5f;
    }
    void Update()
    {
        body.position += new Vector3(1,0,0)*Time.deltaTime*speed*direction;

        if (transform.position.x >= rightBound && direction == 1)
        {
            direction = -1;
        }
        else if (transform.position.x <= leftBound && direction == -1)
        {
            direction = 1;
        }

    }
}
