using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorModelos : MonoBehaviour
{
    public GameObject modelo1;
    public GameObject modelo2;
    public GameObject modelo3;
    public GameObject modelo4;
    //public GameObject modelo5;
    //public GameObject modelo6;


    public float radioDeAccion;
    //public float radioDeAccion5;


    // Start is called before the first frame update
    void Start()
    {
        //modelo1.SetActive(false);
        //modelo2.SetActive(false);
        //modelo3.SetActive(false);
        //modelo4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControladorGPS.distancia1 < radioDeAccion)
        {
            modelo1.SetActive(true);
            modelo2.SetActive(false);
            modelo3.SetActive(false);
            modelo4.SetActive(false);
        }
        else if (ControladorGPS.distancia2 < radioDeAccion)
        {
            modelo1.SetActive(false);
            modelo2.SetActive(true);
            modelo3.SetActive(false);
            modelo4.SetActive(false);
        }
        else if (ControladorGPS.distancia3 < radioDeAccion)
        {
            modelo1.SetActive(false);
            modelo2.SetActive(false);
            modelo3.SetActive(true);
            modelo4.SetActive(false);
        }
        else if (ControladorGPS.distancia4 < radioDeAccion)
        {
            modelo1.SetActive(false);
            modelo2.SetActive(false);
            modelo3.SetActive(false);
            modelo4.SetActive(true);
        }
        else
        {
            modelo1.SetActive(false);
            modelo2.SetActive(false);
            modelo3.SetActive(false);
            modelo4.SetActive(false);
        }
    }
}
