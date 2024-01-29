
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI txt_operacion, txt_resultado;
    [SerializeField]
    TMP_InputField txt_eleccion;
    float x, y;
    float z, v;
    float operacion;
    float aleatorio;
    float respuesta;
    Operacion nuevaOp;

    public enum Operacion
    {
        suma = 0,
        resta = 1,
        division = 2,
        multi = 3

    }

    private void Start()
    {
        txt_eleccion.ActivateInputField();
        Generador();
    }


    private void Update()
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
            if(respuesta == operacion)
            {
                txt_resultado.text = "Correcto";
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
}
