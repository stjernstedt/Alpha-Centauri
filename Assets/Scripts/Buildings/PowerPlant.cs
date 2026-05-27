using UnityEngine;

public class PowerPlant : MonoBehaviour, IProducer, IPlacable
{
    [field: SerializeField] public Material ghostMaterial { get; private set; }
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
        resourceManager.power -= PowerAmount;
    }

    public void Produce()
    {
        resourceManager.power += PowerAmount;
    }
}
