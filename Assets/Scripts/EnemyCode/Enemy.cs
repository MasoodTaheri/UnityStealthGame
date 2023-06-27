using Assets.Scripts.FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.EnemyCode
{
    public abstract class Enemy : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent;
        public Transform PlayerTransform;
        public Vector3 AlertPosition { get; private set; }
        [HideInInspector] public StateMachineController StateController;
        [HideInInspector] public Vector3 LastknownPlayerPosition;


        private float _currentViewAngleWithPlayer;

        [SerializeField] private string _state;
        [SerializeField] private bool _def;
        [SerializeField] private bool _blind;
        [SerializeField] private bool _playerDetected;
        [SerializeField] private FieldOfView _fieldOfView;
        [SerializeField] private float _maxViewAngleWithPlayer;
        [SerializeField] private float _viewDistance;


        private void Start()
        {
            _fieldOfView.Fov = _maxViewAngleWithPlayer * 2;
            _fieldOfView.ViewDistance = _viewDistance * 2;
        }


        public void Update()
        {
            _state = StateController.CurrentState.Name;
        }

        public bool playerDetection()// eye of enemy
        {
            _fieldOfView.ViewDistance = _viewDistance * 2;

            if (PlayerTransform == null)
                return false;

            if (_blind)
                return false;            

            if (!IsInConeAngle())
                return false;       

            if (IsInDirectSight())            
                return true;
            

            LastknownPlayerPosition = Vector3.zero;
            _playerDetected = false;
            return false;
        }

        public void SetAlertPosition(Vector3 position)
        {
            if (_def)
                return;
            AlertPosition = position;

        }

        public bool IsInConeAngle()
        {
            Quaternion rotationToB = Quaternion.LookRotation(PlayerTransform.position - transform.position);
            _currentViewAngleWithPlayer = Quaternion.Angle(transform.rotation, rotationToB);

            if (_currentViewAngleWithPlayer > _maxViewAngleWithPlayer)
            {
                _playerDetected = false;
                return false;
            }
            else return true;
        }

        public bool IsInDirectSight()
        {
            Ray ray = new Ray(transform.position, PlayerTransform.transform.position - transform.position);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out RaycastHit hit, _viewDistance))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    LastknownPlayerPosition = hit.point;
                    _playerDetected = true;
                    return true;
                }
            }
            return false;   


        }
    }
}