using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ResearchManager : MonoBehaviour
{
    ResourceManager resourceManager;
    public VisualTreeAsset techCardTemplate;
    UIDocument uiDocument;
    ResearchItem selectedTech;
    Dictionary<string, ResearchItem> researchItems = new Dictionary<string, ResearchItem>();

    int researchLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = Managers.Instance.ResourceManager;
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
            item.researched = false; // Reset research status on game start, change to load status from save file later
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
        if (selectedTech != null)
        {
            Debug.Log($"Starting research on: {selectedTech.techName}");
            researchLeft = selectedTech.techCost;
            Research();
        }
        else
        {
            Debug.Log("No tech selected for research.");
        }
    }

    async void Research()
    {
        researchLeft -= resourceManager.research;
        if (researchLeft <= 0)
        {
            Debug.Log($"Research completed for: {selectedTech.techName}");
            selectedTech.researched = true;
            PopulateTechTree();
        }
        else
        {
            Debug.Log($"Research in progress for: {selectedTech.techName}, research left: {researchLeft}");
            await Awaitable.WaitForSecondsAsync(1f);
            Research();
        }
    }
}
