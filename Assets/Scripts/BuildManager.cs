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


        public GameObject buildEffect;

        private TurretBlueprint turretToBuild;
        private Node selectedNode;

        public bool CanBuild { get { return turretToBuild != null; } }
        public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

        // �إߨ��m��
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

            GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);

            Debug.Log("turret build! Money lfet:" + PlayerStats.Money);
        }

        public void SelectNode(Node node)
        {
            selectedNode = node;
            turretToBuild = null;
        }

        public void SelectTurretToBuild(TurretBlueprint turret)
        {
            turretToBuild = turret;
            selectedNode = null;
        }
    }

}