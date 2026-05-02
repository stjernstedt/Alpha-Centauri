using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class ResearchManager : MonoBehaviour
{
    public VisualTreeAsset techCardTemplate;
    UIDocument uiDocument;
    ResearchItem selectedTech;
    Dictionary<string, ResearchItem> researchItems = new Dictionary<string, ResearchItem>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Init();
        PopulateTechTree();

        Button startResearchButton = uiDocument.rootVisualElement.Q<Button>("StartResearchButton");
        startResearchButton.clicked += StartResearch;
    }

    void Init()
    {
        uiDocument = FindAnyObjectByType<UIDocument>();
        researchItems = Resources.LoadAll<ResearchItem>("Tech").ToDictionary(item => item.id, item => item);
        foreach (var item in researchItems.Values)
        {
            item.researched = false; // Reset research status on game start
        }
    }

    void PopulateTechTree()
    {
        VisualElement techTree = uiDocument.rootVisualElement.Q<VisualElement>("TechTree");
        techTree.Clear();
        foreach (var item in researchItems)
        {
            if (item.Value.prerequisites.All(preReq => researchItems[preReq].researched) && !item.Value.researched)
            {
                VisualElement techCard = techCardTemplate.Instantiate();
                techCard.RegisterCallback<ClickEvent>(evt => OnTechCardClicked(item.Value));
                techCard.Q<IntegerField>("NameCost").label = item.Value.techName;
                techCard.Q<IntegerField>("NameCost").value = item.Value.techCost;
                techTree.Add(techCard);
            }
        }
    }

    private void OnTechCardClicked(ResearchItem item)
    {
        selectedTech = item;
        VisualElement techDetails = uiDocument.rootVisualElement.Q<VisualElement>("TechDetails");
        //techDetails.Q<Label>("TechName").text = item.techName;
        //techDetails.Q<Label>("TechCost").text = item.techCost.ToString();
        techDetails.Q<Label>("TechDescription").text = item.description;
        techDetails.Q<Image>("TechIcon").style.backgroundImage = item.techIcon;
    }

    private void StartResearch()
    {
        if (selectedTech != null && Managers.Instance.ResourceManager.research >= selectedTech.techCost)
        {
            Debug.Log($"Starting research on: {selectedTech.techName}");
            Managers.Instance.ResourceManager.research -= selectedTech.techCost;
            Research();
            // Implement research logic here (e.g., deduct resources, start timers, etc.)
        }
        else
        {
            Debug.Log("No tech selected for research or insufficient resources.");
        }
    }

    async void Research()
    {
        await Task.Delay(2000);

        Debug.Log($"Research completed for: {selectedTech.techName}");
        selectedTech.researched = true;
        PopulateTechTree();
    }
}
