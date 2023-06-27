using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.EnemyCode
{
    public class FieldOfView : MonoBehaviour
    {

        [SerializeField] private LayerMask layerMask;
        private Mesh mesh;
        public float fov = 90f;
        public float viewDistance = 250f;
        private Vector3 origin;
        public float startingAngle;
        public GameObject raytargetPrefab;
        public List<GameObject> targets;

        private void Awake()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            //fov 
            //viewDistance
            origin = Vector3.zero; ;// transform.position;//Vector3.zero;
                                    //for (int i = 0; i <= 100; i++)
                                    //{
                                    //    var temp = Instantiate(raytargetPrefab);
                                    //    targets.Add(temp);
                                    //}
        }





        private void LateUpdate()
        {

            drawCircle();
        }

        List<Vector3> circleVerteices = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        List<int> triangles = new List<int>();
        public int deltaAngle = 15;

        private void drawCircle()
        {
            //foreach (var go in targets)
            //    go.transform.position = Vector3.zero;
            circleVerteices.Clear();
            uvs.Clear();
            triangles.Clear();


            float val = 3.14285f / 180f;//one degree = val radians
            float radius = viewDistance;


            Vector3 center = Vector3.zero;
            circleVerteices.Add(center);
            uvs.Add(new Vector2(0.5f, 0.5f));
            int triangleCount = 0;

            float x1 = radius * Mathf.Cos(0);
            float y1 = 0;
            float z1 = radius * Mathf.Sin(0);
            Vector3 point1 = new Vector3(x1, y1, z1);

            point1 = LocalLineCast(point1);
            circleVerteices.Add(point1);

            int k = 0;
            //targets[k++].transform.position = transform.TransformPoint(point1);


            uvs.Add(new Vector2((x1 + radius) / 2 * radius, (y1 + radius) / 2 * radius));

            for (int i = 0; i < fov; i = i + deltaAngle)
            {
                float x2 = radius * Mathf.Cos((i + deltaAngle) * val);
                float y2 = 0;//
                float z2 = radius * Mathf.Sin((i + deltaAngle) * val); //0;


                Vector3 point2 = new Vector3(x2, y2, z2);

                ////////
                //if (Input.GetKey(KeyCode.A))
                {
                    point2 = LocalLineCast(point2);

                }

                //targets[k].transform.position = transform.TransformPoint(point2);
                //transform.InverseTransformPoint(point2));

                k++;

                /////////
                circleVerteices.Add(point2);

                uvs.Add(new Vector2((x2 + radius) / 2 * radius, (y2 + radius) / 2 * radius));

                triangles.Add(0);
                triangles.Add(triangleCount + 2);
                triangles.Add(triangleCount + 1);

                triangleCount++;
                point1 = point2;
            }
            mesh.vertices = circleVerteices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.uv = uvs.ToArray();

        }

        private Vector3 LocalLineCast(Vector3 point2)
        {
            //Debug.DrawLine(transform.position, transform.TransformPoint(point2));
            if (Physics.Linecast(transform.position, transform.TransformPoint(point2), out RaycastHit hit))
            {
                point2 = transform.InverseTransformPoint(hit.point);
            }

            return point2;
        }
    }
}