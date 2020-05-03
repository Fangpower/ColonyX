using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillPlacement : MonoBehaviour
{
    public GameObject drill;
    public Transform[] placementSpot;
    public Text price;
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
            price.text = "Max";
            done = true;
        }
    }
    public void OnClick()
    {
        if(!done)
        {
            for(int i = 0; i < placementSpot.Length; i++)
            {
                if(placementSpot[i].childCount == 0)
                {
                    var newDrill = Instantiate(drill, placementSpot[i].position, placementSpot[i].rotation);
                    newDrill.transform.parent = placementSpot[i].transform;
                    cash = int.Parse(price.text) * 2;
                    price.text = cash.ToString();
                    allPlaced = allPlaced + 1;
                    break;
                }
            }
        }
    }
}
