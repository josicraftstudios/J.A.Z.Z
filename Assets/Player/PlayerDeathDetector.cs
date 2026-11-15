using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathDetector : MonoBehaviour
{
    private int DeathTimer = 150;
    public GameObject Blood;
    // Update is called once per frame
    void Update()
    {
        GameObject[] I = GameObject.FindGameObjectsWithTag("Player");
        if (I.Length <= 0)
        {
            DeathTimer--;
            Instantiate(Blood, new Vector3(Random.Range(-25, 25), Random.Range(-5, 30), 0), Quaternion.identity);
        }

        if (DeathTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
        }
    }
}
