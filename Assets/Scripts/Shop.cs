using UnityEngine;

namespace Leo
{
    public class Shop : MonoBehaviour
    {

        BuildManager buildManager;

        void Start()
        {
            buildManager = BuildManager.instance;
        }

        public void PurchaseStandardTurret()
        {
            Debug.Log("standard");
            buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
        }

        public void PurchaseAnotherTurret()
        {
            Debug.Log("standard Another");
            buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
        }

    }

}
