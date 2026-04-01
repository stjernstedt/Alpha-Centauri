using UnityEngine;

public class PowerPlant : MonoBehaviour
{
    ResourceManager resourceManager;
    public int PowerAmount = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;
        resourceManager.AddPower(PowerAmount);
    }

    private void OnDestroy()
    {
        resourceManager.AddPower(-PowerAmount);
    }

}
