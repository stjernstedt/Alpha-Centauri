using UnityEngine;

public class PowerPlant : MonoBehaviour, IProducer
{
    ResourceManager resourceManager;
    public int PowerAmount = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;
        Produce();
    }

    private void OnDestroy()
    {
        resourceManager.AddPower(-PowerAmount);
    }

    public void Produce()
    {
        resourceManager.AddPower(PowerAmount);
    }
}
