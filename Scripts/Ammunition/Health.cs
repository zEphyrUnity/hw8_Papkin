using UnityEngine;


public class Health : MonoBehaviour
{
    public static float health = 50f;

    public void Medication(int healthPoints)
    {
        health += healthPoints;
    }
}