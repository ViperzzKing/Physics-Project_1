using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    [Header("Amount To Spawn")]
    [SerializeField] private int rocksToSpawn;
    
    [Header("Range")]
    [SerializeField] private float xPos;
    [SerializeField] private float xPosEnd;
    [SerializeField] private float zPos;
    [SerializeField] private float zPosEnd;
    
    
    private float spawnPositionX;
    private float spawnPositionZ;
    
    [Header("References")]
    [SerializeField] Transform rockParant;
    [SerializeField] private GameObject rockObject;
    [SerializeField] private GameObject rockSlide;
    
    
    void Start()
    {
        for (int i = 0; i < rocksToSpawn; i++)
        {
            Instantiate(rockObject, RockSpawnPosition(), Quaternion.identity, rockParant);
        }
        
        rockSlide.transform.Rotate(35, 0, 0);
    }

    private Vector3 RockSpawnPosition()
    {
        spawnPositionX = Random.Range(xPos, xPosEnd);
        spawnPositionZ = Random.Range(zPos, zPosEnd);

        return new Vector3(spawnPositionX, 68, spawnPositionZ);
    }
}
