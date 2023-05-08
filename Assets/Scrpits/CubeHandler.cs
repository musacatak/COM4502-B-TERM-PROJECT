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
    public GameObject collector;

    float camZPos = -12f;

    int currentLevelMultiplier = 1;

    public void AddBlock(GameObject _gameObject)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.5f, player.transform.position.z);
        float yVal = blockList.Count;
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

    public void UpdateGroundLevel(float y)
    {
        if (blockList.Count >= 1)
        {
            trailEffect.transform.position += new Vector3(0, 1f, 0);
            collector.transform.position += new Vector3(0, 1f, 0);
            float yPos = cameraTransform.position.y + 1;
            cameraTransform.DOLocalMoveY(yPos, 0.3f);
        }
    }

    public void SetMultiplier()
    {
        currentLevelMultiplier = blockList.Count - 1;
        if (currentLevelMultiplier > 10)
            currentLevelMultiplier = 10;
        else if (currentLevelMultiplier < 1)
            currentLevelMultiplier = 1;
    }

    public int GetMultiplier()
    {
        return currentLevelMultiplier;
    }

}
