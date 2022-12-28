using System;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour 
{
    [SerializeField] Chunk _chunkPrefab, _firstChunk;
    [SerializeField] int _maxDistanceForExist, _maxChunks;

    [SerializeField] Transform _player;

    List<Chunk> chunks = new List<Chunk>();

    event Action OnChunkDestroyed;


    void Start()
    {
        OnChunkDestroyed += SpawnChunks;

        chunks.Add(_firstChunk);
        SpawnChunks();
    }

    void Update()
    {
        ClearOldChunks();
    }


    void SpawnChunks()
    {
        if(chunks.Count < _maxChunks)
        {
            for (int i = 0; i < _maxChunks; i++)
            {
                Chunk lastChunk = chunks[chunks.Count - 1];

                Vector3 spawnPoint = new Vector3(
                lastChunk.transform.position.x,
                lastChunk.transform.position.y,
                lastChunk.transform.position.z + lastChunk.ChunkLength());

                Chunk newChunk = Instantiate(_chunkPrefab, spawnPoint, _chunkPrefab.transform.rotation, transform);

                chunks.Add(newChunk);
            }
        }

    }

    void ClearOldChunks()
    {
        float distance = Vector3.Distance(chunks[0].transform.position, _player.position);

        if (distance > _maxDistanceForExist)
        {
            chunks.RemoveAt(0);
            OnChunkDestroyed.Invoke();
        }

    }

}

