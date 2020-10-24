using UnityEngine;

public class Reinforcement : MonoBehaviour
{
    public static int ammunition = 0;

    public void TakeAmmo(int ammo)
    {
        ammunition += ammo;
    }
}

