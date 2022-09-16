using System.Collections;
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

        [Header("�ݩ�")]

        [Header("�ض𰻴��d��")]
        public float range = 15f;
        public float fireRate = 1f;
        private float fireCountdown = 0f;

        [Header("Unity�]�m�r�q")]

        [Header("���ҼĤH")]
        public string enemyTag = "Enemy";

        [Header("�ض�������i")]
        public Transform partToRotate;
        [Header("�ض�������i�t��")]
        public float turnSpeed = 10f;

        [Header("�l�u")]
        public GameObject bulletPrefab;
        public Transform firePoint;

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

            if(fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        void Shoot()
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Seek(target);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
