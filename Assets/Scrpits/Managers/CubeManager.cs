using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeManager : MonoBehaviour
{
    private float stepLength = 1;
    //GameManager gameManager;
    //GameObject playerModel;
    //Transform playerTransform;
    public MovementController move;

    public List<GameObject> cubeList = new List<GameObject>();

    private void Awake()
    {
        //gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        //playerModel = GameObject.Find("PlayerModel");
        //playerTransform = GameObject.Find("Player").transform;
    }

    public void GetCube(GameObject _gameObject)
    {
        cubeList.Add(_gameObject);

        _gameObject.GetComponent<CollectableCube>().SetCollected();
        _gameObject.transform.parent = transform;

        ReorderCubes();

        RelocatePlayer();

    }

    public void RelocatePlayer()
    {
        Debug.Log($"Boyum {(cubeList.Count) * stepLength}");
        Vector3 playerTarget = new Vector3(0f, (cubeList.Count) * stepLength - 1f, 0f);
        //playerModel.transform.DOLocalMove(playerTarget, 0.2f);
    }

    public void DropCube(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        _gameObject.GetComponent<CollectableCube>().SetDropped();
        _gameObject.GetComponent<BoxCollider>().enabled = false;

        cubeList.Remove(_gameObject);

        if (cubeList.Count < 1)
        {

            Debug.Log("GameOver");

            move.verticalSpeed = 0;
            move.horizontalSpeed = 0;

            Vector3 groundTarget = new Vector3(0f, -0.1f, -1.5f);
            //playerModel.transform.DOLocalJump(groundTarget, 1f, 1, 0.5f);

            //gameManager.TriggerLevelFinish();

        }

        RelocatePlayer();

    }
    public void DropCubeWhenSucces(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        _gameObject.GetComponent<CollectableCube>().SetDropped();
        _gameObject.GetComponent<BoxCollider>().enabled = false;

        cubeList.Remove(_gameObject);
        //Vector3 playerTarget = new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y + 1, playerTransform.transform.position.z);
        //playerTransform.DOLocalMove(playerTarget, 0.05f);


        if (cubeList.Count < 1)
        {

            Debug.Log("GameOver");

            move.verticalSpeed = 0;
            move.horizontalSpeed = 0;

            Vector3 groundTarget = new Vector3(0f, -0.1f, -1.5f);
            //playerModel.transform.DOLocalJump(groundTarget, 1f, 1, 0.5f);

            //gameManager.TriggerLevelFinish();

        }

        RelocatePlayer();

    }

    public void ReorderCubes()
    {
        int index = cubeList.Count - 1;

        foreach (var cube in cubeList)
        {
            Vector3 target = new Vector3(0f, index * stepLength, 0f);
            cube.transform.DOLocalMove(target, 0.5f);
            index--;
        }
    }
}
