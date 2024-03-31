using UnityEngine;

public class LightShieldCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(10);

            ShieldMode shieldMode = other.GetComponent<ShieldMode>();
            if (shieldMode != null)
            {
                shieldMode.ActivateShield();
                gameObject.SetActive(false); // Make the collectible disappear.
            }
        }
    }
}
