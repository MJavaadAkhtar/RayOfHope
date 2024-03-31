using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShieldMode : MonoBehaviour
{
    private bool isShieldActive = false;
    public Light2D lightObject;

    public void ActivateShield()
    {
        isShieldActive = true;
        lightObject.falloffIntensity = 0.1f;
        lightObject.intensity = 1f;

    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        lightObject.falloffIntensity = 0.95f;
    }

    // Call this method whenever the player takes damage.
    public void TakeDamage()
    {
        if (isShieldActive)
        {
            DeactivateShield(); // Negate the damage and deactivate the shield.
        }
        else
        {
            // Apply damage to the player as you normally would.
        }
    }
}
