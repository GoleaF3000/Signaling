using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaTrigger : MonoBehaviour
{
    [SerializeField] private Ninja _ninja;
    public bool IsEntered { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlaceNinja>())
        {
            Debug.Log("Ninja entered in PlaceNinja");
            _ninja.SetTargetChest();
        }
        else if (collision.GetComponent<Knight>())
        {
            Debug.Log("Ninja faced Knight");
            _ninja.SetTargetHome();
        }
        else if (collision.GetComponent<Signaling>())
        {
            if (IsEntered == false)
            {
                IsEntered = true;
            }
            else
            {
                IsEntered = false;
            }
        }
    }
}