using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (TryGetComponent<Item>(out var item))
            {
                playerInventory.inventory.AddToInventory(item);
                Destroy(this.gameObject);
            }
        }
    }
}
