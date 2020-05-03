using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarPlacement : MonoBehaviour
{
    public GameObject solar;
    public GameObject wind;
    public Transform[] placementSpot;
    public Text solarPrice;
    public Text windPrice;
    bool placed, done;
    int cash, allPlaced = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(allPlaced >= 8)
        {
            solarPrice.text = "Max";
            windPrice.text = "Max";
            done = true;
        }
    }
    public void OnClickSolar()
    {
        if(!done)
        {
            for(int i = 0; i < placementSpot.Length; i++)
            {
                if(placementSpot[i].childCount == 0)
                {
                    var newSolar = Instantiate(solar, placementSpot[i].position, placementSpot[i].rotation);
                    newSolar.transform.parent = placementSpot[i].transform;
                    cash = int.Parse(solarPrice.text) * 2;
                    solarPrice.text = cash.ToString();
                    allPlaced = allPlaced + 1;
                    break;
                }
            }
        }
    }

    public void OnClickWind()
    {
        if(!done)
        {
            for(int i = 0; i < placementSpot.Length; i++)
            {
                if(placementSpot[i].childCount == 0)
                {
                    var newWind = Instantiate(wind, placementSpot[i].position, placementSpot[i].rotation);
                    newWind.transform.parent = placementSpot[i].transform;
                    cash = int.Parse(windPrice.text) * 2;
                    windPrice.text = cash.ToString();
                    allPlaced = allPlaced + 1;
                    break;
                }
            }
        }
    }
}
