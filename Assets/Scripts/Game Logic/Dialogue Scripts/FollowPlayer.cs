using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform playerTransform; // Reference to the player's Transform
    public float verticalOffset = 3.5f; // Vertical offset to maintain distance between player and text
    public int playerNumToFollow = 0;

    void Start()
    {
        Player[] players = FindObjectsOfType<Player>();
        Debug.Log(players.Length);
        Transform transform = players[playerNumToFollow].GetComponent<Transform>();
        playerTransform = transform;
    }
    void Update()
    {
        if (playerTransform != null)
        {
            // Set the position of the empty GameObject to the player's position with a vertical offset
            Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + verticalOffset, playerTransform.position.z);

            transform.position = newPosition;
        }
    }
}