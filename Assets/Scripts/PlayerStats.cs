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

        public static int Rounds = 0;

        void Start()
        {
            Money = startMoney;
            Lives = startLives;

            Rounds = 0;
        }
    }

}

