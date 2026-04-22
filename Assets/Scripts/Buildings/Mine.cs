using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour, IProducer
{
    ResourceManager resourceManager;
    public int OreAmount = 1;
    public int powerCost = 10;
    public float Interval = 1f;

    WaitForSeconds oreGenerationInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;

        Produce();
    }

    void OnEnable()
    {
        Debug.Log("Mine enabled, starting production.");
    }


    IEnumerator GenerateOre()
    {
        while (true)
        {
            yield return oreGenerationInterval;
            resourceManager.ore += OreAmount;
        }
    }

    public void Produce()
    {
        oreGenerationInterval = new WaitForSeconds(Interval);
        StartCoroutine(GenerateOre());
    }
}
