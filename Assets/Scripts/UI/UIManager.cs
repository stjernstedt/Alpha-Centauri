using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    UIDocument uiDocument;
    Button buildButton;
    Button researchButton;
    VisualElement buildingButtonsPanel;
    VisualElement researchPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiDocument = FindAnyObjectByType<UIDocument>();
        uiDocument.rootVisualElement.Q<VisualElement>("ResourcesPanel").dataSource = Managers.Instance.ResourceManager;
        InitUI();
    }

    void InitUI()
    {
        Debug.Log("UIManager enabled");
        buildButton = uiDocument.rootVisualElement.Q<Button>("BuildButton");
        buildButton.clicked += OnBuildButtonClicked;

        researchButton = uiDocument.rootVisualElement.Q<Button>("ResearchButton");
        researchButton.clicked += OnResearchButtonClicked;

        // Initially hide the building buttons and research panel
        // setting the scale to 0 causes a bug where the text becomes invisible, so it's set it to a very small value instead
        buildingButtonsPanel = uiDocument.rootVisualElement.Q<VisualElement>("BuildingButtonsPanel");
        buildingButtonsPanel.style.scale = new StyleScale(new Scale(new Vector2(0.0001f, 0.0001f)));

        researchPanel = uiDocument.rootVisualElement.Q<VisualElement>("ResearchPanel");
        researchPanel.style.scale = new StyleScale(new Scale(new Vector2(0.0001f, 0.0001f)));

        InitBuildingButtons();
    }

    private void InitBuildingButtons()
    {
        BuildingPlacer buildingPlacer = FindAnyObjectByType<BuildingPlacer>();

        Button mineButton = uiDocument.rootVisualElement.Q<Button>("MineButton");
        mineButton.clicked += () => buildingPlacer.PlaceBuilding(BuildingType.Mine);

        Button powerPlantButton = uiDocument.rootVisualElement.Q<Button>("PowerPlantButton");
        powerPlantButton.clicked += () => buildingPlacer.PlaceBuilding(BuildingType.PowerPlant);

        Button researchLabButton = uiDocument.rootVisualElement.Q<Button>("ResearchLabButton");
        researchLabButton.clicked += () => buildingPlacer.PlaceBuilding(BuildingType.ResearchLab);
    }

    private void OnResearchButtonClicked()
    {
        if (researchPanel.resolvedStyle.scale.value.y > 0.0001f)
            researchPanel.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
        else
            researchPanel.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
    }

    void OnBuildButtonClicked()
    {

        if (buildingButtonsPanel.resolvedStyle.scale.value.y > 0.0001f)
            buildingButtonsPanel.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
        else
            buildingButtonsPanel.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
    }

}
