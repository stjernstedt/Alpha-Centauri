using UnityEngine;
using UnityEngine.UIElements;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] public int ore = 0;
    [SerializeField] int power = 0;

    UIDocument uiDocument;

    void Start()
    {
        uiDocument = FindAnyObjectByType<UIDocument>();
        uiDocument.rootVisualElement.Q<IntegerField>("OreDisplay").dataSource = this;
        uiDocument.rootVisualElement.Q<IntegerField>("PowerDisplay").dataSource = this;

    }

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
