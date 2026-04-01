using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] int ore = 0;
    [SerializeField] int power = 0;

    public void AddOre(int amount)
    {
        ore += amount;
    }
    public void AddPower(int amount)
    {
        power += amount;
    }

    public int GetOre()
    {
        return ore;
    }

    public int GetPower()
    {
        return power;
    }
}
