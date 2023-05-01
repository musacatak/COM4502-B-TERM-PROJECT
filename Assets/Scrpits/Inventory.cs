using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int NumberOfGems { get; private set; }
    public UnityEvent<Inventory> OnGemCollected;

    public void GemCollected()
    {
        NumberOfGems++;
        OnGemCollected.Invoke(this);
    }
}
