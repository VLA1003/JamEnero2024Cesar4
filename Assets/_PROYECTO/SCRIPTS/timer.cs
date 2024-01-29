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
        if(instance != null && instance != this) 
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

    }

    // Update is called once per frame
    void Update()
    {
        /*float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time -minutes* 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes,seconds);*/

        gameTime -= Time.deltaTime;

        if( gameTime <= 0)
        {

            stopTimer = true;

        }
        if(stopTimer == false)
        {
            //timerText.text = textTime;
            timerSlider.value = gameTime;
        }
    }

    public void ReinicioTiempo()
    {
        timerSlider.value = gameTime_;
        gameTime = gameTime_;
    }
}
