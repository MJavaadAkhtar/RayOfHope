using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    // Gradient colors for different levels of progress
    public Gradient gradient;

    // Reference to the Fill Image component of the Slider
    private Image fillImage;

    void Start()
    {
        // Get the Fill Image component of the Slider
        fillImage = slider.fillRect.GetComponent<Image>();
        
        // Initialize the progress bar
        UpdateProgressBar();
    }

    void UpdateProgressBar()
    {
        // Get the current scene name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Calculate the progress percentage based on the current level
        float progressPercentage = 0f;

        if (currentSceneName == "RayOfHope")
        {
            progressPercentage = 0.33f; // Example: 33% progress for RayOfHope
        }
        else if (currentSceneName == "Level 2")
        {
            progressPercentage = 0.66f; // Example: 66% progress for Level 2
        }
        else if (currentSceneName == "Level 3")
        {
            progressPercentage = 1f; // Example: 100% progress for Level 3
        }

        // Set the value of the Slider based on the progress percentage
        slider.value = progressPercentage;

        // Calculate the color based on the progress percentage
        Color progressColor = gradient.Evaluate(progressPercentage);

        // Apply the calculated color to the fill image
        fillImage.color = progressColor;
    }
}
