using System;
using UnityEngine;

public class Items : MonoBehaviour, IItem
{
    public static event Action<int> OnGemCollect;
    public int worth = 1;
    public void Collect()
    {
        OnGemCollect.Invoke(worth);
        SoundEffectManager.Play("item");
        Destroy(gameObject);
    }

}
