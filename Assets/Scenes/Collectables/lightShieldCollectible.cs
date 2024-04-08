using UnityEngine;

public class LightShieldCollectible : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        audioManager.PlaySFX(audioManager.collectible);
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
