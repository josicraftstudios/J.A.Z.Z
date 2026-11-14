using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Spiders = 0;
    public int Birds = 0;
    public int Ground = 0;

    public void Add_spider()
    {
        Spiders++;
    }

    public void Add_bird()
    {
        Birds++;
    }
    public void Add_ground()
    {
        Ground++;
    }
}
