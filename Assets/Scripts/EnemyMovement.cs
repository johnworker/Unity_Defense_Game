using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMovement : MonoBehaviour
    {
        private Transform target;
        private int wavwpointIndex = 0;

        private Enemy enemy;

        void Start()
        {
            enemy = GetComponent<Enemy>();

            target = Waypoints.points[0];
        }
        void Update()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }

            enemy.speed = enemy.startSpeed;
        }

        void GetNextWaypoint()
        {
            if (wavwpointIndex >= Waypoints.points.Length - 1)
            {
                EndPath();
            }

            wavwpointIndex++;
            target = Waypoints.points[wavwpointIndex];
        }

        void EndPath()
        {
            PlayerStats.Lives--;
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
        }

    }
}
