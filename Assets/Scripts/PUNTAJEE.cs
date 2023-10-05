using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PUNTAJEE : MonoBehaviour
{
    private float puntos;
    private float mejorRecord;

    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI recordTextMesh;

    private void Start()
    {
        // Carga el r�cord almacenado 
        mejorRecord = PlayerPrefs.GetFloat("MejorRecord", 0f);
        ActualizarRecordText();

        textMesh.text = puntos.ToString("0");
    }

    private void Update()
    {
        puntos += Time.deltaTime;
        textMesh.text = puntos.ToString("0");

        // Comprueba si se ha superado el r�cord actual.
        if (puntos > mejorRecord)
        {
            mejorRecord = puntos;
            ActualizarRecordText();

            // Guardar uevo r�cord en PlayerPrefs.
            PlayerPrefs.SetFloat("MejorRecord", mejorRecord);
            PlayerPrefs.Save();  
        }
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }

    private void ActualizarRecordText()
    {
        recordTextMesh.text = "Mejor Record: " + mejorRecord.ToString("0");
    }
}
