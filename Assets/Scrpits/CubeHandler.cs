using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeHandler : MonoBehaviour
{
    public List<GameObject> blockList = new List<GameObject>();

    public GameObject player;

    public Transform cameraTransform;

    private float lastZPos;
    private bool isBlockRemoved;

    public ParticleSystem cubeParticle;

    public GameObject trailEffect;

    float groundLevel = -0.5f;
    float camZPos = -12f;

    public void AddBlock(GameObject _gameObject)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.5f, player.transform.position.z);
        float yVal = blockList.Count + groundLevel;
        _gameObject.transform.SetParent(this.transform);
        _gameObject.transform.position = new Vector3(player.transform.position.x, yVal + 1.5f, player.transform.position.z);

        _gameObject.GetComponent<CubeBehaviour>().setLastCube(true);
        Instantiate(cubeParticle, _gameObject.transform.position, Quaternion.identity);
        blockList[blockList.Count - 1].GetComponent<CubeBehaviour>().setLastCube(false);
        blockList.Add(_gameObject);

        camZPos -= 0.5f;
        Mathf.Clamp(camZPos, -20, -12);
        cameraTransform.DOLocalMoveZ(camZPos, 0.3f);
    }


    public void RemoveBlock(GameObject _gameObject)
    {
        blockList.Remove(_gameObject);
        if (!isBlockRemoved)
            lastZPos = transform.position.z;

        camZPos += 0.5f;
        Mathf.Clamp(camZPos, -20, -12);
        cameraTransform.DOLocalMoveZ(camZPos, 0.3f);
    }

    public void UpdateBlockHeight()
    {
        for (int i = 0; i < blockList.Count; i++)
        {
            blockList[i].GetComponent<CubeBehaviour>().updateHeight(i + groundLevel, i * 0.05f);

            //in their new height methods I can use dotween or some other things to make them animated ...
        }
        isBlockRemoved = false;
    }

    public void UpdateGroundLevel(float y)
    {
        if (blockList.Count >= 1)
        {
            groundLevel += y;
            Debug.Log("New Ground Level " + groundLevel);
            trailEffect.transform.Translate(0f, groundLevel + 0.51f, 0f, Space.World);
        }
    }

}
