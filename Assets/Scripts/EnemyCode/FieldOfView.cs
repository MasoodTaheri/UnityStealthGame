using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.EnemyCode
{
    public class FieldOfView : MonoBehaviour
    {
        public float Fov = 90f;
        public float ViewDistance = 250f;
        public int DeltaAngle = 15;


        [SerializeField] private LayerMask layerMask;
        [SerializeField] private MeshFilter _meshFilter;

        private Mesh _mesh;
        private List<Vector3> _circleVerteices = new List<Vector3>();
        private List<Vector2> _uvs = new List<Vector2>();
        private List<int> _triangles = new List<int>();

        private void Awake()
        {
            _mesh = new Mesh();
            _meshFilter.mesh = _mesh;
        }

        private void LateUpdate()
        {
            _circleVerteices.Clear();
            _uvs.Clear();
            _triangles.Clear();
            DrawConeView();
        }

        private void DrawConeView()
        {
            float val = 3.14285f / 180f;//one degree = val radians
            float radius = ViewDistance;


            Vector3 center = Vector3.zero;
            _circleVerteices.Add(center);
            _uvs.Add(new Vector2(0.5f, 0.5f));
            int triangleCount = 0;

            float x1 = radius * Mathf.Cos(0);
            float y1 = 0;
            float z1 = radius * Mathf.Sin(0);
            Vector3 point1 = new Vector3(x1, y1, z1);

            point1 = LocalLineCast(point1);
            _circleVerteices.Add(point1);

            _uvs.Add(new Vector2((x1 + radius) / 2 * radius, (y1 + radius) / 2 * radius));

            for (int i = 0; i < Fov; i = i + DeltaAngle)
            {
                float x2 = radius * Mathf.Cos((i + DeltaAngle) * val);
                float y2 = 0;//
                float z2 = radius * Mathf.Sin((i + DeltaAngle) * val); //0;


                Vector3 point2 = new Vector3(x2, y2, z2);

                point2 = LocalLineCast(point2);


                _circleVerteices.Add(point2);

                _uvs.Add(new Vector2((x2 + radius) / 2 * radius, (y2 + radius) / 2 * radius));

                _triangles.Add(0);
                _triangles.Add(triangleCount + 2);
                _triangles.Add(triangleCount + 1);

                triangleCount++;
                point1 = point2;
            }
            _mesh.vertices = _circleVerteices.ToArray();
            _mesh.triangles = _triangles.ToArray();
            _mesh.uv = _uvs.ToArray();

        }

        private Vector3 LocalLineCast(Vector3 point2)
        {
            if (Physics.Linecast(transform.position, transform.TransformPoint(point2), out RaycastHit hit))
            {
                point2 = transform.InverseTransformPoint(hit.point);
            }
            return point2;
        }
    }
}