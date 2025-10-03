using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGrid : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject rockPrefab;
    public GameObject bushPrefab;

    public int objectAmount = 30;
    public int areaSizeX = 10;
    public int areaSizeZ = 10;
    public float spacing = 2f;

    [Range(0f, 1f)] public float treeWeight = 0.7f;
    [Range(0f, 1f)] public float rockWeight = 0.15f;
    [Range(0f, 1f)] public float bushWeight = 0.15f;

    void Start()
    {
        CreateForest();   
    }
    void CreateForest()
    {
        for (int i = 0; i < objectAmount; i++) 
        {
            Vector3 randomPos = new Vector3(Random.Range(-areaSizeX, areaSizeX),0f, Random.Range(-areaSizeZ, areaSizeZ));
            GameObject prefab = ChosePrefab();
            Instantiate(prefab, randomPos, Quaternion.identity, transform);
        }

    }
    GameObject ChosePrefab()
    {
        float rand = Random.value;
        if (rand < treeWeight)
            return treePrefab;
        else if (rand < treeWeight + rockWeight)
            return rockPrefab;
        else
            return bushPrefab;

    }
}
