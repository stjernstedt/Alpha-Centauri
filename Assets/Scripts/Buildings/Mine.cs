using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    ResourceManager resourceManager;
    public int OreAmount = 1;
    public float Interval = 1f;

    WaitForSeconds oreGenerationInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;
        oreGenerationInterval = new WaitForSeconds(Interval);
        StartCoroutine(GenerateOre());
    }

    IEnumerator GenerateOre()
    {
        while (true)
        {
            yield return oreGenerationInterval;
            resourceManager.AddOre(OreAmount);
        }
    }
}
