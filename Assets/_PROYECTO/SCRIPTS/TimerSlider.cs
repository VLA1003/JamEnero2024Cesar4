using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    public Slider timerSlider;
    public float maxTime = 60f;
    private float currentTime;
    private bool isTimerRunning = false;

    void Start()
    {
        currentTime = maxTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                // Aquí puedes poner cualquier acción cuando el tiempo se agote
                isTimerRunning = false;
                Debug.Log("¡Tiempo completado!");
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void UpdateTimerDisplay()
    {
        if (timerSlider != null)
        {
            // Asegúrate de que el valor del slider esté en el rango [0, 1]
            timerSlider.value = Mathf.Clamp01(currentTime / maxTime);
        }
    }
}
