using UnityEngine;
using Runner;

public class Chunk : MonoBehaviour
{
    [SerializeField] Transform _beginChunk, _endChunk;
    [SerializeField] Transform _startSpawnArea, _endSpawnArea;

    [SerializeField] GameObject[] _specialBorderPrefabs, _healPrefabs;
    [SerializeField] int _minBorders, _maxBorders;
    [SerializeField] int _minHeals, _maxHeals;
    

    void Start()
    {
        SpawnEntity(_specialBorderPrefabs, _minBorders, _maxBorders);

        if(Random.Range(0, 10) == 1)
            SpawnEntity(_healPrefabs, _minHeals, _maxHeals);
    }

    void SpawnEntity(GameObject[] array, int min, int max)
    {
        GameObject[] objs = new GameObject[Random.Range(min, max)];

        for(int i=0; i < objs.Length; i++)
        {
            Vector3 spawnPoint = new Vector3(
            Random.Range(_startSpawnArea.position.x, _endSpawnArea.position.x), 
            0f,
            Random.Range(_startSpawnArea.position.z, _endSpawnArea.position.z));

            GameObject prefab = array[Random.Range(0, array.Length)];

            spawnPoint.y = prefab.transform.position.y;

            GameObject obj = Instantiate(prefab, spawnPoint, prefab.transform.rotation, transform);

            objs[i] = obj;
        }
    }

    public float ChunkLength()
    {
        float length = Vector3.Distance(_beginChunk.position, _endChunk.position);

        return length;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Score.instance.AddScore();
    }
}
