using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnPointController : MonoBehaviour
    {
        public List<Transform> SpawnPoints;
        public List<Transform> unUsedSpawnPoints;

        public Transform GetSpawnPoint()
        {
            if (unUsedSpawnPoints.Count == 0)
            {
                unUsedSpawnPoints = new List<Transform>(SpawnPoints);
            }

            int RandomIndex = Random.Range(0, unUsedSpawnPoints.Count);
            Transform spawnpoint = unUsedSpawnPoints[RandomIndex];
            unUsedSpawnPoints.RemoveAt(RandomIndex);
            return spawnpoint;
        }




    }
}