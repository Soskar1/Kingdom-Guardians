using UnityEngine;

namespace KingdomGuardians.Core
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}