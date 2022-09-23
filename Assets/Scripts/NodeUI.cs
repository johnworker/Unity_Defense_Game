using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Leo
{
    public class NodeUI : MonoBehaviour
    {
        public GameObject ui;

        public TextMeshProUGUI upgradeCost;
        public Button upgradeButton;

        private Node target;

        public void SetTarget(Node _target)
        {
            target = _target;

            transform.position = target.GetBuildPosition();

            if (!target.isUpgraded)
            {
                upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
                upgradeButton.interactable = true;
            }
            else
            {
                upgradeCost.text = "DONE";
                upgradeButton.interactable = false;
            }

            ui.SetActive(true);
        }

        public void Hide()
        {
            ui.SetActive(false);
        }

        public void Upgrade()
        {
            target.UpgradeTurret();

            BuildManager.instance.DeselectNode();
        }
    }

}
