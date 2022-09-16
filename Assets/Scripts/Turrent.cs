using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo
{
    public class Turrent : MonoBehaviour
    {
        [Header("建塔偵測目標")]
        private Transform target;
        [Header("建塔偵測範圍")]
        public float range = 15f;

        [Header("標籤敵人")]
        public string enemyTag = "Enemy";

        [Header("建塔旋轉轉檯")]
        public Transform partToRotate;

        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shootestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if(distanceToEnemy < shootestDistance)
                {
                    shootestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if(nearestEnemy != null && shootestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

        void Update()
        {
            if (target == null)
                return;

            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
