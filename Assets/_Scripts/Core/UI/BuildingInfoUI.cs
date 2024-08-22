using KingdomGuardians.Core.BuildSystem;
using TMPro;
using UnityEngine;

namespace KingdomGuardians.Core.UI
{
    public class BuildingInfoUI : MonoBehaviour
    {
        [SerializeField] private BuildingInfo _buildingInfo;
        [SerializeField] private BuildingConstruction _buildingConstruction;
        private BuildingUI _buildingUI;

        [SerializeField] private TextMeshProUGUI _buildingName;
        [SerializeField] private TextMeshProUGUI _cost;

        private void Awake() => _buildingUI = GetComponentInParent<BuildingUI>();

        private void Start()
        {
            _buildingName.text = _buildingInfo.name;
            _cost.text = _buildingInfo.cost.ToString();
        }

        public void Project()
        {
            _buildingUI.Close();
            _buildingConstruction.StartBuilding(_buildingInfo);
        }
    }
}