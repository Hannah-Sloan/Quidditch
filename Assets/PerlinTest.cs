using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTest : Singleton<PerlinTest>
{
    public int texXWidth = 153;
    public int texYWidth = 55;

    [Range(0,1)]
    public float xScale = 1;
    [Range(0, 1)]
    public float yScale = 1;

    public float xOffsetRed = 0;
    public float yOffsetRed = 0;
    public float xOffsetGreen = 0;
    public float yOffsetGreen = 0;
    public float xOffsetBlue = 0;
    public float yOffsetBlue = 0;

    [Range(0,1)]
    public float scrollSpeed = 1;

    [ContextMenu("Test")]
    public void Update()
    {
        xOffsetRed += Time.deltaTime * Random.Range(0f,4) * scrollSpeed;
        yOffsetRed += Time.deltaTime * Random.Range(0f, 4) * scrollSpeed;
        xOffsetGreen += Time.deltaTime * Random.Range(0f, 4) * scrollSpeed;
        yOffsetGreen += Time.deltaTime * Random.Range(0f, 4) * scrollSpeed;
        xOffsetBlue += Time.deltaTime * Random.Range(0f, 4) * scrollSpeed;
        yOffsetBlue += Time.deltaTime * Random.Range(0f, 4) * scrollSpeed;

        //UpdateTexture();
    }

    public Vector3 GetValue(float i, float j)
    {
        var red = Mathf.PerlinNoise((i * xScale) + xOffsetRed, (j * yScale) + yOffsetRed);
        var green = Mathf.PerlinNoise((i * xScale) + xOffsetGreen, (j * yScale) + yOffsetGreen);
        var blue = Mathf.PerlinNoise((i * xScale) + xOffsetBlue, (j * yScale) + yOffsetBlue);
        return new Vector3(red, green, blue);
    }

    public void UpdateTexture() 
    {
        Texture2D noiseTex = new Texture2D(texXWidth, texYWidth);
        noiseTex.filterMode = FilterMode.Point;
        noiseTex.wrapMode = TextureWrapMode.Clamp;
        for (int i = 0; i < texXWidth; i++)
        {
            for (int j = 0; j < texYWidth; j++)
            {
                Vector3 color = GetValue(i, j);
                noiseTex.SetPixel(i, j, new Color(color.x, color.y, color.z));
            }
        }
        noiseTex.Apply();

        GetComponent<Renderer>().material.mainTexture = noiseTex;
    }
}
