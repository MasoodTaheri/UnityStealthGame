using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.EnemyCode
{
    public class PatrolingOnNodes : MonoBehaviour, IPatrolOnNode
    {
        //[HideInInspector]
        public PathController pathController;
        //public List<Transform> nodes;
        [SerializeField] private GameObject Agent;

        public float DistanceToNode;
        public float minDistance;
        public float Speed;
        [HideInInspector] public NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        //void Start()
        //{
        //    //Initialize();
        //}

        // Update is called once per frame
        //void Update()
        //{
        //    //UpdatePatrol();

        //}
        //private Vector3 current_rot_target;
        //float rotate_val;
        //private Vector3 face_vect;
        //public float rotate_speed = 120f;
        //private float current_rot_mult = 1f;
        /*public void FaceToTarget()
        {

            //Vector3 dir = current_rot_target - Agent.transform.position;
            dir.y = 0f;
            if (dir.magnitude > 0.1f)
            {
                Quaternion target = Quaternion.LookRotation(dir.normalized, Vector3.up);
                Quaternion reachedRotation = Quaternion.RotateTowards(Agent.transform.rotation, target, rotate_speed * current_rot_mult * Time.deltaTime);
                //rotate_val = Quaternion.Angle(transform.rotation, target);
                //face_vect = dir.normalized;
                Agent.transform.rotation = reachedRotation;
            }
        }*/


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 direction = Agent.transform.TransformDirection(Vector3.forward) * 3;
            Gizmos.DrawRay(Agent.transform.position, direction);
        }

        public void Initialize()
        {
            //CurrentNodeId = 0;
            //        current_rot_target = nodes[CurrentNodeId].transform.position;
            //if (CurrentNodeId == -1)
            //    CurrentNodeId = 0;
            navMeshAgent.destination = pathController.GetCurrentNodePosition();//nodes[CurrentNodeId].position;
        }


        public void UpdatePatrol()
        {
            /*DistanceToNode = Vector3.Distance(Agent.transform.position, nodes[CurrentNodeId].transform.position);
            if (DistanceToNode < minDistance)
            {
                CurrentNodeId = (++CurrentNodeId) % nodes.Count;
                current_rot_target = nodes[CurrentNodeId].transform.position;
            }
            //Agent.transform.position = Vector3.Lerp(Agent.transform.position, nodes[CurrentNodeId].transform.position, Time.deltaTime * Speed);
            Agent.transform.position = Vector3.MoveTowards(Agent.transform.position, nodes[CurrentNodeId].transform.position, Time.deltaTime * Speed);

            FaceToTarget();*/
            //Debug.Log("patrol for navmesh");
            //DistanceToNode = Vector3.Distance(Agent.transform.position, nodes[CurrentNodeId].transform.position);
            DistanceToNode = Vector3.Distance(Agent.transform.position, pathController.GetCurrentNodePosition());
            if (DistanceToNode < minDistance)
            {
                pathController.NextNode();
                navMeshAgent.destination = pathController.GetCurrentNodePosition();// nodes[CurrentNodeId].position;


            }

        }
    }
}