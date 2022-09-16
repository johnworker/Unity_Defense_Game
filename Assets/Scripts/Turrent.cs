using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo
{
    public class Turrent : MonoBehaviour
    {
        /// <summary>
        /// �ض𱱨�}��
        /// </summary>
        [Header("�ض𰻴��ؼ�")]
        private Transform target;
        [Header("�ض𰻴��d��")]
        public float range = 15f;

        [Header("���ҼĤH")]
        public string enemyTag = "Enemy";

        [Header("�ض�������i")]
        public Transform partToRotate;

        public float turnSpeed = 10f;

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

            // ��w�ؼ�
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
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
