using UnityEngine;

public class EnemySpawnerScribt : MonoBehaviour
{
    public GameObject Bird;

    // Update is called once per frame
    void Update()
    {
        //spawn new bird
        GameObject[] pickupPoints = GameObject.FindGameObjectsWithTag("Enemy");
        if (pickupPoints.Length <= 0)
        {
            GameObject[] f = GameObject.FindGameObjectsWithTag("BirdSpawn");
            int randomIndex = Random.Range(0, f.Length);

            Instantiate(Bird, f[randomIndex].transform.position, Quaternion.identity);
        }
        
    }
}
