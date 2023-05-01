using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject mainCube, playerModel;    
    public CubeManager cubeManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect" && other.gameObject.GetComponent<CollectableCube>().GetIsCollected() == false)
        {           
            Debug.Log("Collected");

            cubeManager.GetCube(other.gameObject);
        }    

        else if (other.gameObject.tag == "Finish")
        {
            Debug.Log(cubeManager.cubeList.Count);            

        }
    }

}
