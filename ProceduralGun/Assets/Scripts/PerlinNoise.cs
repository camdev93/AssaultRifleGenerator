using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [HideInInspector]
    public int width=0;
    [HideInInspector]
    public int height=0;
    [HideInInspector]
    public float scale;
    
    public void MainBody()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sharedMaterial.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / scale;
        float yCoord = (float)y / scale;
        float sampleX = Mathf.PerlinNoise(xCoord, yCoord);
        float sampleY = Mathf.PerlinNoise(xCoord, yCoord);
        float sampleZ = Mathf.PerlinNoise(xCoord, yCoord);

        return new Color(sampleX, sampleY, sampleZ);
    }
}
