using UnityEngine;
using UnityEngine.UI;

namespace Leo
{
    public class Enemy : MonoBehaviour
    {
        public float startSpeed = 10f;
        [HideInInspector]
        public float speed;

        public float startHealth = 100;
        private float health;

        public int worth = 50;

        public GameObject deathEffect;

        private Transform target;
        private int wavwpointIndex = 0;

        [Header("Unity Stuff")]
        public Image healthBar;

        void Start()
        {

            speed = startSpeed;

            health = startHealth;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;

            healthBar.fillAmount = health / startHealth;

            if(health <= 0)
            {
                Die();
            }
        }

        public void Slow(float pct)
        {
            speed = startSpeed * (1f - pct);
        }

        void Die()
        {
            PlayerStats.Money += worth;

            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);

            Destroy(gameObject);
        }
    }

}
