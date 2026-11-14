using UnityEngine;

public class EnemySpawnerScribt : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Ground;
    public static int level = 0;

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

            Instantiate(Bird, f[randomIndex].transform.position, Quaternion.identity);

            if(level==3 || level == 8)
            {
                Instantiate(Ground, new Vector3(-20.18f, -3, 0), Quaternion.identity);
            }
        }
        
    }
}
