using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        // Handle player inputs
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithTile();
        }
    }

    void MovePlayer()
    {
        // Player movement logic
    }

    void InteractWithTile()
    {
        // Interaction logic with word tiles
    }

    void OpenInventory()
    {
        // Open player inventory
    }
}