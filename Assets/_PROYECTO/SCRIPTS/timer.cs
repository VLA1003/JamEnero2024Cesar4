using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public static timer instance;
    public Slider timerSlider;
    public Text timerText;
    [SerializeField] private float gameTime;

    private float gameTime_;

    public bool stopTimer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
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

        // Retraso de 2 segundos antes de comenzar a descontar
        Invoke("StartTimer", 1f);
    }

    // Método para comenzar el temporizador después del retraso
    private void StartTimer()
    {
        StartCoroutine(UpdateTimer());
    }

    // Update is called once per frame
    IEnumerator UpdateTimer()
    {
        while (!stopTimer)
        {
            gameTime -= Time.deltaTime;

            if (gameTime <= 0)
            {
                stopTimer = true;
            }

            if (!stopTimer)
            {
                timerSlider.value = gameTime;
                yield return null;
            }
        }
    }

    public void ReinicioTiempo()
    {
        timerSlider.value = gameTime_;
        gameTime = gameTime_;
        stopTimer = false;
        StartCoroutine(UpdateTimer());
    }
}
