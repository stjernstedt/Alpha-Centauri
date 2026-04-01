using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    public ResourceManager ResourceManager;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
