using UnityEngine;

namespace Leo
{
    public class Enemy : MonoBehaviour
    {
        public float speed = 10f;

        private Transform target;
        private int wavwpointIndex = 0;

        void Start()
        {
            target = Waypoints.points[0];
        }

        void Update()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if(Vector3.Distance(transform.position,target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }

        void GetNextWaypoint()
        {
            if(wavwpointIndex >= Waypoints.points.Length - 1)
            {
                Destroy(gameObject);
            }

            wavwpointIndex++;
            target = Waypoints.points[wavwpointIndex];
        }
    }

}
