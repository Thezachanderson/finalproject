using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour {
    public Transform player;

    void FixedUpdate() {
        if (player != null) transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}
