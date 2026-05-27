using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] GameObject minePrefab;
    [SerializeField] GameObject powerPlantPrefab;
    [SerializeField] GameObject researchLabPrefab;
    GameObject buildingPrefab;
    GameObject buildingGhost = null;

    Color originalColor;
    Material originalMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGhostPosition();
    }

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
        buildingGhost.GetComponent<Collider>().enabled = false;
        if (buildingGhost.GetComponent<IProducer>() is MonoBehaviour mb) mb.enabled = false;

        // possible remove these 2 lines
        originalMaterial = buildingGhost.GetComponent<Renderer>().material;
        Material ghostMaterial = buildingGhost.GetComponent<IPlacable>().ghostMaterial;

        buildingGhost.GetComponent<Renderer>().material = ghostMaterial;
        //originalColor = buildingGhost.GetComponent<Renderer>().material.color;
        //Color ghostColor = originalColor;
        //ghostColor.a = 0.5f;
        //buildingGhost.GetComponent<Renderer>().material.color = ghostColor;
    }

    void UpdateGhostPosition()
    {
        if (buildingGhost != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 gridPos = Vector3Int.RoundToInt(hit.point);
                gridPos.y += 0.5f;
                buildingGhost.transform.position = gridPos;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                //Color ghostColor = buildingGhost.GetComponent<Renderer>().material.color;
                //ghostColor.a = 1f;
                //buildingGhost.GetComponent<Renderer>().material.color = ghostColor;
                //buildingGhost.GetComponent<Renderer>().material.color = originalColor;
                buildingGhost.GetComponent<Renderer>().material = originalMaterial;
                if (buildingGhost.GetComponent<IProducer>() is MonoBehaviour mb) mb.enabled = true;
                buildingGhost.GetComponent<Collider>().enabled = true;
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