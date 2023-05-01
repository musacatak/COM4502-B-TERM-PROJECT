using UnityEngine;
using DG.Tweening;
public class CollectableCube : MonoBehaviour
{
    bool isCollected = false;
    int index;
    public Collector collector;
    public CubeManager cubeManager;
    public Transform ptransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            //SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.DropCube);
            cubeManager.DropCube(this.gameObject);
            Invoke("RRorder", 0.2f);

            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.gameObject.tag == "X1")
        {
            //SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.DropCube);
            cubeManager.DropCubeWhenSucces(this.gameObject);
            Invoke("RRorder", 0.05f);

            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public bool GetIsCollected()
    {
        return isCollected;
    }

    public void SetCollected()
    {
        isCollected = true;
    }

    public void SetDropped()
    {
        isCollected = false;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void RRorder()
    {
        cubeManager.ReorderCubes();
    }

}