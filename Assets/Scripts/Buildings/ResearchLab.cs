using System.Collections;
using UnityEngine;

public class ResearchLab : MonoBehaviour, IProducer
{
    ResourceManager resourceManager;
    public int ResearchAmount = 1;
    public float Interval = 1f;

    WaitForSeconds researchGenerationInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;
        Produce();
    }

    IEnumerator GenerateResearch()
    {
        while (true)
        {
            yield return researchGenerationInterval;
            resourceManager.research += ResearchAmount;
        }
    }

    public void Produce()
    {
        researchGenerationInterval = new WaitForSeconds(Interval);
        StartCoroutine(GenerateResearch());
    }

}
