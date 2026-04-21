using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] GameObject minePrefab;
    [SerializeField] GameObject powerPlantPrefab;
    [SerializeField] GameObject researchLabPrefab;
    GameObject buildingPrefab;
    GameObject buildingGhost = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGhostPosition();
    }

    //TODO rebuild UI using UI Toolkit and use events to trigger this method instead of calling it directly from the UI button(can't call it directly from the button because of the enum parameter)
    public void PlaceBuilding(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Mine:
                buildingPrefab = minePrefab;
                break;
            case BuildingType.PowerPlant:
                buildingPrefab = powerPlantPrefab;
                break;
            case BuildingType.ResearchLab:
                buildingPrefab = researchLabPrefab;
                break;
            default:
                buildingPrefab = null;
                break;
        }
        Vector3 mousePos = Mouse.current.position.ReadValue();
        buildingGhost = Instantiate(buildingPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        //(buildingGhost.GetComponent<IProducer>() as MonoBehaviour).enabled = false;
        if (buildingGhost.GetComponent<IProducer>() is MonoBehaviour mb) mb.enabled = false;
        Color ghostColor = buildingGhost.GetComponent<Renderer>().material.color;
        ghostColor.a = 0.5f;
        buildingGhost.GetComponent<Renderer>().material.color = ghostColor;
    }

    void UpdateGhostPosition()
    {
        if (buildingGhost != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3Int gridPos = Vector3Int.RoundToInt(hit.point);
                buildingGhost.transform.position = gridPos;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Color ghostColor = buildingGhost.GetComponent<Renderer>().material.color;
                ghostColor.a = 1f;
                buildingGhost.GetComponent<Renderer>().material.color = ghostColor;
                if (buildingGhost.GetComponent<IProducer>() is MonoBehaviour mb) mb.enabled = true;
                //(buildingGhost.GetComponent<IProducer>() as MonoBehaviour).enabled = true;
                buildingGhost = null;
            }
        }
    }
}

public enum BuildingType
{
    Mine,
    PowerPlant,
    ResearchLab
}