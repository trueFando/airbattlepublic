using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _spawnCooldown;

    private void Start()
    {
        StartNewWave();
    }

    private void StartNewWave()
    {
        GameObject[] newPattern = ShuffleArray();
        StartCoroutine(SpawningRoutine(newPattern));
    }

    private IEnumerator SpawningRoutine(GameObject[] queue)
    {
        for (int i = 0; i < queue.Length; i++)
        {
            yield return new WaitForSeconds(_spawnCooldown / SpeedRate.Rate);
            Spawn(queue[i], _spawnPoints[GetRandomPoint()].position);
        }
        StartNewWave();
    }

    private void Spawn(GameObject obj, Vector3 position)
    {
        Instantiate(obj, position, Quaternion.identity);
    }

    private int GetRandomPoint()
    {
        while (true)
        {
            int point = Random.Range(0, _spawnPoints.Count);
            SpawnPoint sp = _spawnPoints[point].GetComponent<SpawnPoint>();
            if (!sp.HaveObstacle) return point;
        }
    }

    private GameObject[] ShuffleArray()
    {
        GameObject[] prefabsArray = new GameObject[_prefabs.Length];
        _prefabs.CopyTo(prefabsArray, 0);
        for (int i = prefabsArray.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);
            var temp = prefabsArray[j];
            prefabsArray[j] = prefabsArray[i];
            prefabsArray[i] = temp;
        }
        return prefabsArray;
    }
}
