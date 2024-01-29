using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_operacion, txt_resultado;
    [SerializeField] TMP_InputField txt_eleccion;

    float x, y;
    float z, v;
    float operacion;
    float respuesta;
    Operacion nuevaOp;
    bool gameOver; // Nueva variable para indicar si el juego ha terminado

    public enum Operacion
    {
        suma = 0,
        resta = 1,
        division = 2,
        multi = 3
    }

    private timer gameTimer;

    private void Start()
    {
        txt_eleccion.ActivateInputField();
        gameTimer = timer.instance;
        Generador();
    }

    private void Update()
    {
        if (!gameOver) // Verifica si el juego está activo
        {
            if (z < v && z % v != 0)
            {
                z = Random.Range(1, 10);
                v = Random.Range(1, 10);
            }

            switch (nuevaOp)
            {
                case Operacion.suma:
                    operacion = x + y;
                    txt_operacion.text = (x + "+" + y).ToString();
                    break;
                case Operacion.resta:
                    operacion = x - y;
                    txt_operacion.text = (x + "-" + y).ToString();
                    break;
                case Operacion.division:
                    operacion = z / v;
                    txt_operacion.text = (z + "/" + v).ToString();
                    break;
                case Operacion.multi:
                    operacion = z * v;
                    txt_operacion.text = (z + "*" + v).ToString();
                    break;
            }

            respuesta = float.Parse(txt_eleccion.text);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (respuesta == operacion)
                {
                    txt_resultado.text = "Correcto";
                    gameTimer.AumentarTiempo(2f); // Aumenta el tiempo en 2 segundos
                    Generador();
                    txt_eleccion.text = null;
                    txt_eleccion.ActivateInputField();
                }
                else
                {
                    txt_resultado.text = "Incorrecto";
                    Generador();
                    txt_eleccion.text = null;
                    txt_eleccion.ActivateInputField();
                }
            }

            // Verifica el tiempo restante y pausa el juego si es necesario
            if (gameTimer.timerSlider.value <= 0)
            {
                txt_resultado.text = "Tiempo Agotado";
                PausarJuego(); // Pausa el juego cuando se agota el tiempo
                // Puedes agregar más lógica aquí según tus necesidades
            }
        }
    }

    void Generador()
    {
        x = Random.Range(0, 100);
        y = Random.Range(0, 100);
        z = Random.Range(1, 20);
        v = Random.Range(1, 20);

        while (z % v != 0)
        {
            z++;
        }

        nuevaOp = (Operacion)Random.Range(0, 4);
        Debug.Log(x);
    }

    void PausarJuego()
    {
        gameOver = true;
        Time.timeScale = 0f; // Pausa el tiempo de juego
    }
}
