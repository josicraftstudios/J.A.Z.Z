using Unity.VisualScripting;
using UnityEngine;



public class Seeking : MonoBehaviour
{

    Rigidbody2D EnemyBody;
   
    public float speed = 1.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Current_player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 direction = new Vector2 (Current_player_pos.x - transform.position.x, Current_player_pos.y - transform.position.y);
        //print(Current_player_pos);

        EnemyBody.linearVelocity = (new Vector2(direction.x, direction.y).normalized)*speed;
        //print(EnemyBody.linearVelocity);
        
        //Vector2 test = new Vector2(direction.x, direction.y);

        //print(test);
        //print(Current_player_pos);

    }
}
