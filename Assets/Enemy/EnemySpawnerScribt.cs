using UnityEngine;

public class EnemySpawnerScribt : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Ground;
    public GameObject Spider;
    public int level = 0;
    public int Spider_spawn_offset = 2;



    // Update is called once per frame
    void Update()
    {
        //spawn new bird
        GameObject[] pickupPoints = GameObject.FindGameObjectsWithTag("Enemy");
        if (pickupPoints.Length <= 0)
        {
            level++;

            /*for(int i = 0; i < Mathf.Max(1, Mathf.RoundToInt(level / 5));i++)
            {
                GameObject[] f = GameObject.FindGameObjectsWithTag("BirdSpawn");
                int randomIndex = Random.Range(0, f.Length);

                Instantiate(Bird, f[randomIndex].transform.position, Quaternion.identity);
            }
            */
            GameObject[] f = GameObject.FindGameObjectsWithTag("BirdSpawn");
            int randomIndex = Random.Range(0, f.Length);

            GameObject[] Leaves = GameObject.FindGameObjectsWithTag("Block");
            int RandomLeaf = Random.Range(0, Leaves.Length);
            //print(Leaves[RandomLeaf]);
            Vector2 SpawnPoint = new Vector2(Leaves[RandomLeaf].transform.position.x, Leaves[RandomLeaf].transform.position.y + Spider_spawn_offset);


            Instantiate(Bird, f[randomIndex].transform.position, Quaternion.identity);
            //print(level);

            if(level==3 || level == 8)
            {
                print(level + "true");
                Instantiate(Ground, new Vector3(-20.18f, -3, 0), Quaternion.identity);
            }
            if (level % 2 == 0)
            {
                Instantiate(Spider,SpawnPoint, Quaternion.identity);
                
            }
        }
        
    }
}
