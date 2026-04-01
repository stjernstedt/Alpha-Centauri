using TMPro;
using UnityEngine;

public class ResourcesUIManager : MonoBehaviour
{
    public GameObject Ore;
    public GameObject Power;
    ResourceManager resourceManager;

    TextMeshProUGUI oreText;
    TextMeshProUGUI powerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;
        oreText = Ore.GetComponent<TextMeshProUGUI>();
        powerText = Power.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        oreText.text = "Ore: " + resourceManager.GetOre();
        powerText.text = "Power: " + resourceManager.GetPower();
    }


}
