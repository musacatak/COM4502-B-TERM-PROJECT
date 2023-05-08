using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private CubeHandler cubeHandler;

    [SerializeField] private GameManager gameManager;

    public ParticleSystem gemParticle;

    private void Start()
    {
        cubeHandler = GameObject.FindObjectOfType<CubeHandler>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect")
        {
            other.tag = "Cube";
            cubeHandler.AddBlock(other.gameObject);
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.cubeClip);
        }

        else if (other.tag == "Gem")
        {
            Destroy(other.gameObject);
            Instantiate(gemParticle, other.gameObject.transform.position, Quaternion.identity);
            gameManager.TakeGem();
            SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.gemClip);
        }

        else if (other.tag == "Finish")
        {
            Debug.Log("Finish Reached");
            gameManager.LevelFinished();
            cubeHandler.SetMultiplier();
        }

        //else if (other.tag == "X1")
        //{
        //    Debug.Log("LAST PLATFORM UPDATE");
        //    cubeHandler.UpdateGroundLevel(0.5f);
        //}
    }
}
