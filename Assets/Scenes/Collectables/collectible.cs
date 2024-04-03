using System.Collections;
using RayOfHope;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    AudioManager audioManager;
    public enum PowerUpType { Speed, Jump, LightPulse }
    public PowerUpType powerUpType;
    public float duration = 5f; // The duration for which the power-up is active
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        audioManager.PlaySFX(audioManager.collectible);
        if (other.gameObject.CompareTag("Player"))
        {
            switch (powerUpType)
            {
                case PowerUpType.Speed:
                    StartCoroutine(ApplySpeedBoost(other));
                    break;
                case PowerUpType.Jump:
                    StartCoroutine(ApplyJumpBoost(other));
                    break;
            }

            // Make the collectible disappear 
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ApplySpeedBoost(Collider2D player)
    {
        PlayerController playerMovement = player.GetComponent<PlayerController>();
        ScoreManager.instance.AddScore(10);
        Debug.Log("Speed boost started");

        playerMovement.movePower *= 2; // Double the speed
        FindObjectOfType<UIController>().ActivateTimer(duration, PowerUpType.Speed);
        yield return new WaitForSeconds(duration);
        Debug.Log("Speed boost started");
        playerMovement.movePower /= 2; // Revert to original speed
    }

    private IEnumerator ApplyJumpBoost(Collider2D player)
    {
        PlayerController playerMovement = player.GetComponent<PlayerController>();
        playerMovement.Jump();
        ScoreManager.instance.AddScore(10);
        Debug.Log("Jump boost started");

        playerMovement.jumpPower *= 1.5f; // Increase the jump force
        FindObjectOfType<UIController>().ActivateTimer(duration, PowerUpType.Jump);
        yield return new WaitForSeconds(duration);
        Debug.Log("Jump boost started");
        playerMovement.jumpPower /= 1.5f; // Revert to original jump force
    }

}
