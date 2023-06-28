using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PathController : MonoBehaviour
    {
        [SerializeField] private List<Transform> _nodes;
        private int _currentNodeId = -1;

        public Vector3 GetCurrentNodePosition()
        {
            if (_currentNodeId == -1)
                _currentNodeId = 0;
            return _nodes[_currentNodeId].position;
        }

        public void NextNode()
        {
            _currentNodeId = ++_currentNodeId % _nodes.Count;
        }

        private void OnDrawGizmos()
        {
            foreach (Transform t in _nodes)
                Gizmos.DrawSphere(t.position, 1);

            for (int i = 1; i < _nodes.Count; i++)
            {
                Gizmos.DrawLine(_nodes[i - 1].position, _nodes[i].position);
            }
            Gizmos.DrawLine(_nodes[_nodes.Count - 1].position, _nodes[0].position);
        }
    }
}