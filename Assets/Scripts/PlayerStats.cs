using System.Collections;
using UnityEngine;

namespace Leo
{
    public class PlayerStats : MonoBehaviour
    {
        public static int Money;
        public int startMoney = 400;

        void Start()
        {
            Money = startMoney;
        }
    }

}

