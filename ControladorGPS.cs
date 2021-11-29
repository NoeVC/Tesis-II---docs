using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGPS : MonoBehaviour
{
    public float puntoLat;
    public float puntoLong;

    public float Lat_armonia;
    public float Long_armonia;

    public float Lat_ninios;
    public float Long_ninios;

    public float Lat_deseos;
    public float Long_deseos;

    float actualLat;
    float actualLong;

      public static float distancia1;
      public static float distancia2;
      public static float distancia3;
      public static float distancia4;
    public float radioDeAccion1;

    public static float[] distancias;

    // formula para calcular la distancia entre la ubicación actual y un objeto
    float FormulaHaversine(float lat1, float long1, float lat2, float long2)
    {
        float earthRad = 6371000;
        float lRad1 = lat1 * Mathf.Deg2Rad;
        float lRad2 = lat2 * Mathf.Deg2Rad;
        float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
        float dLong = (long2 - long1) * Mathf.Deg2Rad;
        float a = Mathf.Sin(dLat / 2.0f) * Mathf.Sin(dLat / 2.0f) +
                  Mathf.Cos(lRad1) * Mathf.Cos(lRad2) *
                  Mathf.Sin(dLong / 2.0f) * Mathf.Sin(dLong / 2.0f);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return earthRad*c; //en metros
    }

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        actualLat = Input.location.lastData.latitude;
        actualLong = Input.location.lastData.longitude;

        distancia1 = FormulaHaversine(puntoLat, puntoLong, actualLat, actualLong);
        distancia2 = FormulaHaversine(Lat_armonia, Long_armonia, actualLat, actualLong);
        distancia3 = FormulaHaversine(Lat_ninios, Long_ninios, actualLat, actualLong);
        distancia4 = FormulaHaversine(Lat_deseos, Long_deseos, actualLat, actualLong);
    }

    private void OnGUI()
    {
        radioDeAccion1 = 8;

        string [] fuentes = { "Entrada al Circuito Mágico de las Aguas", "Fuente de la armonía", "Fuente de los niños", "Fuente de los deseos"};

        // string mensaje = "Latitud : " + actualLat +
        //    "\nLongitud : " + actualLong +
        //    "\nDistancia 1 :" + distancias[0] +
        //     "\nDistancia 2 :" + distancias[1] +
        //    "\nDistancia 3 :" + distancias[2] +
        //   "\nDistancia 4 :" + distancias[3];

        if (distancia1 < distancia2)
        {
            GUI.contentColor = Color.blue;
            GUI.skin.label.fontSize = 25;
            GUI.Label(new Rect(10, 40, 1000, 1000), "La " +fuentes[0]+ "\nse encuentra a " + distancia1+ " metros.");
        }
        else if (distancia2 < distancia3)
        {
            GUI.contentColor = Color.blue;
            GUI.skin.label.fontSize = 25;
            GUI.Label(new Rect(10, 40, 1000, 1000), "La " + fuentes[1] + "\nse encuentra a " + distancia2 + " metros.");

        }
        else if (distancia3 < distancia4)
        {
            GUI.contentColor = Color.blue;
            GUI.skin.label.fontSize = 25;
            GUI.Label(new Rect(10, 40, 1000, 1000), "La " + fuentes[2] + "\nse encuentra a " + distancia3 + " metros.");

        }
        else if (distancia4 < distancia1)
        {
            GUI.contentColor = Color.blue;
            GUI.skin.label.fontSize = 25;
            GUI.Label(new Rect(10, 40, 1000, 1000), "La " + fuentes[3] + "\nse encuentra a " + distancia4 + " metros.");

        }



    }
}
