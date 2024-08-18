using UnityEngine;

namespace KingdomGuardians.Core.UI
{
    public class BuildingUI : MonoBehaviour
    {
        private PlayerRotation _playerRotation;

        public void Initialize(PlayerRotation playerRotation) => _playerRotation = playerRotation;

        public void Open()
        {
            gameObject.SetActive(true);
            _playerRotation.CanRotate = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _playerRotation.CanRotate = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}