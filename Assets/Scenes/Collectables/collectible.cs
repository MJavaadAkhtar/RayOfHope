using System.Collections;
using RayOfHope;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum PowerUpType { Speed, Jump, LightPulse }
    public PowerUpType powerUpType;
    public float duration = 5f; // The duration for which the power-up is active

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        ScoreManager.instance.AddScore(10);

        playerMovement.jumpPower *= 1.5f; // Increase the jump force
        FindObjectOfType<UIController>().ActivateTimer(duration, PowerUpType.Jump);
        yield return new WaitForSeconds(duration);
        playerMovement.jumpPower /= 1.5f; // Revert to original jump force
    }

}
