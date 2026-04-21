using UnityEngine;
using UnityEngine.UIElements;

public class ResearchManager : MonoBehaviour
{
    public VisualTreeAsset techCardTemplate;
    ResearchItem[] researchItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIDocument document = FindAnyObjectByType<UIDocument>();
        VisualElement techTree = document.rootVisualElement.Q<VisualElement>("TechTree");
        researchItems = Resources.LoadAll<ResearchItem>("Tech");
        foreach (var item in researchItems)
        {
            Debug.Log($"Loaded research item: {item.name} with cost {item.techCost}");
            VisualElement techCard = techCardTemplate.Instantiate();
            techCard.Q<IntegerField>("NameCost").label = item.techName;
            techCard.Q<IntegerField>("NameCost").value = item.techCost;

            techTree.Add(techCard);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
