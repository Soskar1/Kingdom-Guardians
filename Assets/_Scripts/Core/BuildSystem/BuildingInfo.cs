using UnityEngine;

namespace KingdomGuardians.Core.BuildSystem
{
    [CreateAssetMenu(fileName = "BuildingInfo", menuName = "BuildSystem/BuildingInfo")]
    public class BuildingInfo : ScriptableObject
    {
        public int cost;
        public GameObject prefab;
    }
}