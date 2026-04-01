using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private List<GameObject> prefabList;
    
    [Space]
    [SerializeField] private List<GameObject> spawnedPrefabList;
    
    [Space]
    [SerializeField] private Transform spawnedPoint;

    [SerializeField] private Transform prefabParent;
    
    
    public void SpawnPrefab(int index)
    {
        var go = Instantiate(prefabList[index], spawnedPoint.position, Quaternion.identity, prefabParent);
        spawnedPrefabList.Add(go);
    }

    public void ClearSpawnedPrefabs()
    {
        foreach (var go in spawnedPrefabList)
        {
            Destroy(go);
        }
    }
}
