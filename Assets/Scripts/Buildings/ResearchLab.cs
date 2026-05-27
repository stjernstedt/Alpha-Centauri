using UnityEngine;

public class ResearchLab : MonoBehaviour, IProducer, IPlacable
{
    [field: SerializeField] public Material ghostMaterial { get; private set; }

    ResourceManager resourceManager;
    public int ResearchAmount = 10;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;
        Produce();
    }

    public void Produce()
    {
        resourceManager.research += ResearchAmount;
    }

}
