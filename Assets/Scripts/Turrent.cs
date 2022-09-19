using System.Collections;
using UnityEngine;

namespace Leo
{
    public class Turrent : MonoBehaviour
    {
        /// <summary>
        /// 建塔控制腳本
        /// </summary>
        [Header("建塔偵測目標")]
        private Transform target;

        [Header("一般")]

        [Header("建塔偵測範圍")]
        public float range = 15f;

        [Header("使用子彈(預設)")]
        public GameObject bulletPrefab;
        public float fireRate = 1f;
        private float fireCountdown = 0f;

        [Header("使用激光")]
        public bool useLaser = false;
        public LineRenderer lineRenderer;

        [Header("Unity設置字段")]

        [Header("標籤敵人")]
        public string enemyTag = "Enemy";

        [Header("建塔旋轉轉檯")]
        public Transform partToRotate;
        [Header("建塔旋轉轉檯速度")]
        public float turnSpeed = 10f;

        [Header("子彈")]
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

            // 鎖定目標
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
            if (target == null) {

                if (useLaser) {
                    if (lineRenderer.enabled)
                        lineRenderer.enabled = false;

                }

                return;
            }
                

            LockOnTarget();

            if (useLaser)
            {
                Laser();
            }
            else {

                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }

                fireCountdown -= Time.deltaTime;

            }

        }

        void LockOnTarget() {

            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }

        void Laser() {
            if (!lineRenderer.enabled)
                lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);
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
