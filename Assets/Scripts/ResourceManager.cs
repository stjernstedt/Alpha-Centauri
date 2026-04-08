using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] int ore = 0;
    [SerializeField] int power = 0;
    [SerializeField] int research = 0;

    void Start()
    {

    }

    public void AddOre(int amount)
    {
        ore += amount;
    }
    public void AddPower(int amount)
    {
        power += amount;
    }

    public void AddResearch(int amount)
    {
        research += amount;
    }

    public int GetOre()
    {
        return ore;
    }

    public int GetPower()
    {
        return power;
    }

    public int GetResearch()
    {
        return research;
    }
}
