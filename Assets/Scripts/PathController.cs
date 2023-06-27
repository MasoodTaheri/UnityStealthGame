using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PathController : MonoBehaviour
    {
        public List<Transform> nodes;
        public int CurrentNodeId = -1;
        // Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}

        public Vector3 GetCurrentNodePosition()
        {
            if (CurrentNodeId == -1)
                CurrentNodeId = 0;
            return nodes[CurrentNodeId].position;
        }

        public void NextNode()
        {
            CurrentNodeId = ++CurrentNodeId % nodes.Count;
        }

        private void OnDrawGizmos()
        {
            foreach (Transform t in nodes)
            {
                Gizmos.DrawSphere(t.position, 1);
            }

            for (int i = 1; i < nodes.Count; i++)
            {
                Gizmos.DrawLine(nodes[i - 1].position, nodes[i].position);
            }
            Gizmos.DrawLine(nodes[nodes.Count - 1].position, nodes[0].position);
        }
    }
}