using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //[SerializeField] private GameObject efecto;
    [SerializeField] private float cantPuntos;
    [SerializeField] private PUNTAJEE puntaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
       //puntaje.SumarPuntos(cantPuntos);
        //Instantiate(efecto, transform.position, Quaternion.identity);*/
        Destroy(gameObject);

    }

    public void SMRPNTS()
    {
        puntaje = FindAnyObjectByType<PUNTAJEE>();
        puntaje.SumarPuntos(cantPuntos);
    }

}
