using KingdomGuardians.Core.BuildSystem;
using KingdomGuardians.Core.UI;
using UnityEngine;

namespace KingdomGuardians.Core
{
    public class Bootstrap : MonoBehaviour
    {
        private Input _input;
        [SerializeField] private Player _player;
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private BuildingConstruction _buildingConstruction;
        [SerializeField] private Transform _spawnpoint;

        private void Awake()
        {
            _input = new Input();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Start()
        {
            Player playerInstance = Instantiate(_player, _spawnpoint.position, Quaternion.identity) as Player;
            playerInstance.Initialize(_input);
            _gameUI.Initialize(_input.Controls, playerInstance.GetComponent<PlayerRotation>());
            _buildingConstruction.Initialize(playerInstance, _input.Controls);
        }

        private void OnEnable() => _input.Enable();
        private void OnDisable() => _input.Disable();
    }
}