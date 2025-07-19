using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Texture2D map;
    [SerializeField] ColorToPrefab[] colorMappings;
    [SerializeField] Material material1;
    [SerializeField] Material material2;
    int offset = 5;


    private void Start()
    {
        GenerateLabirynth();
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color == pixelColor)
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);

                return;
            }
        }
    }

    public void GenerateLabirynth()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }

        ColorWalls();
    }

    private void ColorWalls()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Wall")
            {
                if (Random.Range(1,100) % 3 == 0)
                {
                    child.gameObject.GetComponent<Renderer>().material = material2;
                } 
                else
                {
                    child.gameObject.GetComponent<Renderer>().material = material1;
                }
            }
        }
    }

}
