using System.Collections;
using UnityEngine;

namespace Leo
{
    public class PlayerStats : MonoBehaviour
    {
        public static int Money;
        public int startMoney = 400;

        public static int Lives;
        public int startLives = 20;

        void Start()
        {
            Money = startMoney;
            Lives = startLives;
        }
    }

}
