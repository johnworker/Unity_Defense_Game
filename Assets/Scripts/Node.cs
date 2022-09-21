using UnityEngine;
using UnityEngine.EventSystems;

namespace Leo
{
    public class Node : MonoBehaviour
    {

        public Color hoverColor;
        public Color notEnoughMoneyColor;
        public Vector3 positionOffset;

        [Header("¿ï³æ")]
        public GameObject turret;

        private Renderer rend;
        private Color startColor;

        BuildManager buildManager;

        void Start()
        {
            rend = GetComponent<Renderer>();
            startColor = rend.material.color;

            buildManager = BuildManager.instance;
        }

        public Vector3 GetBuildPosition()
        {
            return transform.position + positionOffset;
        }

        void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if(turret != null)
            {
                Debug.Log("Can't build there! - TODO: Display on screen");
                return;
            }

            if (!buildManager.CanBuild)
                return;

            buildManager.BuildTurretOn(this);
        }

        void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!buildManager.CanBuild)
                return;

            if (buildManager.HasMoney)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = notEnoughMoneyColor;
            }
        }

        void OnMouseExit()
        {
            rend.material.color = startColor;
        }
    }

}
