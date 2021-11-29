using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gpscontrolador : MonoBehaviour
{
    //private string urlmap = "";

    public RawImage imageMap;
    public Text latitudeText;
    public Text longitudText;

    public int zoom = 22;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GetMap");

    }

    public void ZoombottonIn()
    {
        zoom++;
        StartCoroutine("GetMap");
    }


    public void ZoombottonOut()
    {
        zoom--;
        StartCoroutine("GetMap");
    }

    private IEnumerator GetMap()
    {
        float latitud = Input.location.lastData.latitude;
        yield return latitud;

        float longitud = Input.location.lastData.longitude;
        yield return longitud;

        //urlmap = "maps.googleapis.com/maps/api/staticmap?center=" + latitud+","+longitud+"&zoom="+zoom+"&size=600x300"+"&maptype=roadmap&markers=color:blue%7Clabel:S%7C"+latitud+","+longitud+ "&markers = color:red % 7Clabel: S % 7C-15.28209,-73.34621 & key=AIzaSyDKyEc1UikKFmDwgQaICKp-sdYmfYPREVk";
        string urlmap2 = "https://maps.googleapis.com/maps/api/staticmap?center="+latitud+","+longitud+"&zoom="+zoom+ "&size=400x400&maptype=hybrid&markers=color:red%7Clabel:A%7C" + latitud + "," + longitud + "&markers=color:blue%7Clabel:A%7C-15.279206,-73.344179&markers=color:blue%7Clabel:B%7C-15.278727,-73.344066&markers=color:blue%7Clabel:C%7C-15.278655,-73.344535&markers=color:green%7Clabel:I%7C-15.279123,-73.344599&markers=color:green%7Clabel:I%7C-15.282129,-73.346185&key=AIzaSyDKyEc1UikKFmDwgQaICKp-sdYmfYPREVk";
        WWW www = new WWW(urlmap2);
        yield return www;

        imageMap.texture = www.texture;
        latitudeText.text = "" + latitud;
        longitudText.text = "" + longitud;

    }


    // Update is called once per frame
    void Update()
    {
        Input.location.Start();
    }
}
