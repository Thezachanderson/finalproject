using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    private Rigidbody2D player;
    private Collider2D playerCollider;
    private List<Collider2D> walkableSquareColliders = new List<Collider2D>();

    void Start() {
        player = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        GameObject[] walkableSquareObjects = GameObject.FindGameObjectsWithTag("Walkable");

        for (int i=0; i<walkableSquareObjects.Length; ++i) {
            Collider2D collider = walkableSquareObjects[i].GetComponent<Collider2D>();
            if (collider != null) walkableSquareColliders.Add(collider);
        }
    }

    void FixedUpdate() {
        Vector2 newPosition = player.position+player.velocity *Time.fixedDeltaTime;
        bool isWalkable = false;

        foreach (Collider2D plot in walkableSquareColliders) {
            if (plot.bounds.Contains(newPosition)) {
                isWalkable = true;
                break;
            }
        }

        if (isWalkable) player.position = newPosition;
        else player.velocity = Vector2.zero;
    }
}
