using System.Collections;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float _distancePosition = 5.0f;
    
    public Vector3 InteractPosition()
    {
        return (transform.position +  ( transform.forward * _distancePosition ));
    }

    public void Interact(Player player)
    {
        StartCoroutine(WaitForPlayerArriving(player));
    }

    IEnumerator WaitForPlayerArriving(Player player)
    {
        while (!player.CheckIfArrived())
        {
            yield return null;
        }
    }
}