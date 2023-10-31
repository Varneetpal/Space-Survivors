
using UnityEngine;

public class FirepointFollowPlayer : MonoBehaviour
{
    public Transform player; // Assign the player GameObject in the Unity Inspector
    public float followSpeed = 5.0f; // Adjust the speed at which the firepoint follows the player

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the firepoint to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Normalize the direction vector to get a consistent speed
            directionToPlayer.Normalize();

            // Calculate the new position for the firepoint
            Vector3 newPosition = transform.position + directionToPlayer * followSpeed * Time.deltaTime;

            // Set the firepoint's position to the new position
            transform.position = newPosition;
        }
    }
}