using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager timemanager;
    public float tiempoEditable = 10f;
    public float tiempoReducible;
    public Slider timerSlider;
    [SerializeField]
    GameObject gameOver, musicManager;
    [SerializeField]
    AudioSource explosionEndSound;
    [SerializeField]
    AudioClip explosionClip;

    public GameObject gameOverScreen;

    private void Awake()
    {
        timemanager = this;
    }
    private void Start()
    {
        musicManager.SetActive(true);
        gameOver.SetActive(false);
        timerSlider.maxValue = tiempoEditable;
        tiempoReducible = tiempoEditable;
    }
    private void Update()
    {
        timerSlider.value = tiempoReducible;
        if (tiempoReducible > 0)
        {
            tiempoReducible -= Time.deltaTime;
        }
        else if (tiempoReducible <= 0)
        {
            Debug.Log("CoroutineStarted");
            StartCoroutine("EndGameDelay");
        }
    }
    IEnumerator EndGameDelay()
    {
        musicManager.SetActive(false);
        gameOver.SetActive (true);
        explosionEndSound.PlayOneShot(explosionClip);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MainmenuScene");
    }
}
