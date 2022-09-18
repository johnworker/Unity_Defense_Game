using UnityEngine;

namespace Leo
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager instance;

        void Awake()
        {
            if(instance != null)
            {
                Debug.LogError("More than one BuildManager in scene");
                return;
            }
            instance = this;
        }

        public GameObject standardTurretPrefab;

        public GameObject missileLauncherPrefab;

        private TurretBlueprint turretToBuild;

        public bool CanBuild { get { return turretToBuild != null; } }

        // «Ø¥ß¨¾¿m¶ð
        public void BuildTurretOn(Node node)
        {
            if(PlayerStats.Money < turretToBuild.cost)
            {
                Debug.Log("Not enough money to build that!");
                return;
            }

            PlayerStats.Money -= turretToBuild.cost;

            GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;

            Debug.Log("turret build! Money lfet:" + PlayerStats.Money);
        }

        public void SelectTurretToBuild(TurretBlueprint turret)
        {
            turretToBuild = turret;
        }
    }

}
