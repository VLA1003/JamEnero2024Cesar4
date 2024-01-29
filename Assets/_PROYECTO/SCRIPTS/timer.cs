using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public static timer instance;
    public Slider timerSlider;
    public Text timerText;
    [SerializeField] private float gameTime;

    private float gameTime_;
    private float timeRemaining;
    private Coroutine timerCoroutine; // Agrega una referencia al Coroutine

    public bool stopTimer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        gameTime_ = gameTime;
        timeRemaining = gameTime;

        // Retraso de 2 segundos antes de comenzar a descontar
        Invoke("StartTimer", 1f);
    }

    // Método para comenzar el temporizador después del retraso
    private void StartTimer()
    {
        timerCoroutine = StartCoroutine(UpdateTimer());
    }

    // Update is called once per frame
    IEnumerator UpdateTimer()
    {
        while (!stopTimer)
        {
            if (timeRemaining <= 0)
            {
                stopTimer = true;
            }

            if (!stopTimer)
            {
                timeRemaining -= Time.deltaTime;
                timerSlider.value = timeRemaining;
                yield return null;
            }
        }
    }

    public void AumentarTiempo(float segundos)
    {
        timeRemaining += segundos;
        timerSlider.value = timeRemaining;
    }

    public void ReinicioTiempo()
    {
        StopCoroutine(timerCoroutine); // Detiene el Coroutine actual
        timerSlider.value = gameTime_;
        timeRemaining = gameTime_;
        stopTimer = false;
        timerCoroutine = StartCoroutine(UpdateTimer()); // Reinicia el temporizador
    }
}
