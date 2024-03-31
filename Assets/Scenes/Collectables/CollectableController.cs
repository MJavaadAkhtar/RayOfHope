using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image timerBar; // Assign this in the inspector
    private float maxDuration = 5f;
    private float timeLeft;

    public void ActivateTimer(float duration, Collectible.PowerUpType powerUpType)
    {
        timeLeft = duration;
        maxDuration = duration;
        timerBar.gameObject.SetActive(true);
        UpdateTimerBar();
        
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerBar();
        }
        else
        {
            timerBar.gameObject.SetActive(false);
        }
    }

    private void UpdateTimerBar()
    {
        if (timerBar != null)
        {
            timerBar.fillAmount = timeLeft / maxDuration;
        }
    }
}
