using UnityEngine;

public class TextureGen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int width = 10;
        int height = 10;

        Texture2D texture = new Texture2D(width, height);
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                Color color = new Color(0, Random.Range(0f, 1f), 0);
                texture.SetPixel(x, z, color);
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.Apply();

        GetComponent<MeshRenderer>().material.mainTexture = texture;

    }

    // Update is called once per frame
}
