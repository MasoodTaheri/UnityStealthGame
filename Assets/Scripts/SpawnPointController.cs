using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnPointController : MonoBehaviour
    {
        public List<Transform> SpawnPoints;
        private List<Transform> _unUsedSpawnPoints=new List<Transform>();

        public Transform GetSpawnPoint()// Ensure Unique find position
        {
            if (_unUsedSpawnPoints.Count == 0)
            {
                _unUsedSpawnPoints = new List<Transform>(SpawnPoints);
            }

            int RandomIndex = Random.Range(0, _unUsedSpawnPoints.Count);
            Transform spawnpoint = _unUsedSpawnPoints[RandomIndex];
            _unUsedSpawnPoints.RemoveAt(RandomIndex);
            return spawnpoint;
        }




    }
}