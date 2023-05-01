using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject mainCube, playerModel;
    //GameManager gameManager;
    public CubeManager cubeManager;


    private void Awake()
    {
        //gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect" && other.gameObject.GetComponent<CollectableCube>().GetIsCollected() == false)
        {
            //SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.CollectCube);
            Debug.Log("Collected");

            cubeManager.GetCube(other.gameObject);
        }

        else if (other.gameObject.tag == "Gem")
        {
            //SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.GemCollect);
        }

        else if (other.gameObject.tag == "Finish")
        {
            Debug.Log(cubeManager.cubeList.Count);
            //gameManager.TriggerLevelSuccessed(cubeManager.cubeList.Count);

        }
    }

}
