using UnityEngine;
using UnityEngine.UIElements;

public class ButtonsMenuManager : MonoBehaviour
{
    UIDocument uiDocument;
    Button buildButton;
    VisualElement buildingButtonsPanel;

    void Awake()
    {
        uiDocument = FindAnyObjectByType<UIDocument>();

    }

    void OnEnable()
    {
        buildButton = uiDocument.rootVisualElement.Q<Button>("BuildButton");
        buildButton.clicked += OnBuildButtonClicked;

        buildingButtonsPanel = uiDocument.rootVisualElement.Q<VisualElement>("BuildingButtonsPanel");
        buildingButtonsPanel.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));

        Button mineButton = uiDocument.rootVisualElement.Q<Button>("MineButton");
        mineButton.clicked += () => FindAnyObjectByType<BuildingPlacer>().PlaceBuilding(BuildingType.Mine);

        Button powerPlantButton = uiDocument.rootVisualElement.Q<Button>("PowerPlantButton");
        powerPlantButton.clicked += () => FindAnyObjectByType<BuildingPlacer>().PlaceBuilding(BuildingType.PowerPlant);

        Button researchLabButton = uiDocument.rootVisualElement.Q<Button>("ResearchLabButton");
        researchLabButton.clicked += () => FindAnyObjectByType<BuildingPlacer>().PlaceBuilding(BuildingType.ResearchLab);
    }

    void OnBuildButtonClicked()
    {

        if (buildingButtonsPanel.resolvedStyle.scale.value.y > 0)
            buildingButtonsPanel.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
        else
            buildingButtonsPanel.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
    }
}
