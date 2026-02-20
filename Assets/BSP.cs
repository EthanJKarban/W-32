using System.Threading;
using UnityEngine;

public class BSP : MonoBehaviour
{
    public BS bs;

    public void Start()
    {
        bs.timer = bs.cooldown;
    }
}
