using Assets.Scripts.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.EnemyCode
{
    public abstract class Enemy : MonoBehaviour
    {
        [HideInInspector] public StateMachineController controller;
        public NavMeshAgent navMeshAgent;
        [HideInInspector] public Vector3 LastknownPlayerPosition;
        public Transform player;
        public string state;
        //public LayerMask DetectableMask;
        public Vector3 AlertPosition { get; private set; }
        public bool Def;
        public bool Blind;
        public bool PlayerDetected;
        

        public FieldOfView FieldOfView;
        public float MaxViewAngleWithPlayer;
        private float _currentViewAngleWithPlayer;

        public float ViewDistance;

        // Start is called before the first frame update
        private void Start()
        {
            FieldOfView.fov = MaxViewAngleWithPlayer * 2;
            FieldOfView.viewDistance = ViewDistance * 2;
        }

        // Update is called once per frame
        public void Update()
        {
            state = controller.CurrentState.Name;
        }

        public bool playerDetection()
        {
            if (player == null)
                return false;



            if (Blind)
                return false;
            FieldOfView.viewDistance = ViewDistance * 2;

            Quaternion rotationToB = Quaternion.LookRotation(player.position - transform.position);
            _currentViewAngleWithPlayer = Quaternion.Angle(transform.rotation, rotationToB);

            if (_currentViewAngleWithPlayer > MaxViewAngleWithPlayer)
            {
                PlayerDetected = false;
                return false;
            }


            Ray ray = new Ray(transform.position, player.transform.position - transform.position);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out RaycastHit hit, ViewDistance))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    LastknownPlayerPosition = hit.point;
                    //Debug.Log("player viewed");
                    PlayerDetected = true;
                    return true;
                }

            }
            LastknownPlayerPosition = Vector3.zero;
            PlayerDetected = false;
            return false;
        }

        public void SetAlertPosition(Vector3 position)
        {
            if (Def)
                return;
            AlertPosition = position;

        }
    }
}