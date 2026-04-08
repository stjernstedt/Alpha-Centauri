using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    UIDocument uiDocument;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiDocument = FindAnyObjectByType<UIDocument>();
        uiDocument.rootVisualElement.Q<VisualElement>("ResourcesPanel").dataSource = Managers.Instance.ResourceManager;
    }

}
