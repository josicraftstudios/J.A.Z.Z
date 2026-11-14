using UnityEngine;

public class EnemySpawnerScribt : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Ground;
    public GameObject Spider;
    public int level = 0;
    public int Spider_spawn_offset = 4;

    public GameObject shopUI;
    private bool Shoping=false;

    // Update is called once per frame
    void Update()
    {
        //spawn new bird
        GameObject[] pickupPoints = GameObject.FindGameObjectsWithTag("Enemy");
        if (pickupPoints.Length <= 0)
        {
            NextLevel();
            /*if (Shoping == true)
            {
                // 1. Activate the Shop UI panel
                shopUI.SetActive(true);

                // 2. Freeze the game time so nothing happens in the background while shopping
                Time.timeScale = 0f;
            }
            else
            {
                Shoping = true;
                NextLevel();
            }*/
        }
        
    }

    public void NextLevel()
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

        if (level == 3 || level == 8)
        {
            print(level + "true");
            Instantiate(Ground, new Vector3(-20.18f, -3, 0), Quaternion.identity);
        }
        if (level % 2 == 0)
        {
            Instantiate(Spider, SpawnPoint, Quaternion.identity);

        }
    }
}
