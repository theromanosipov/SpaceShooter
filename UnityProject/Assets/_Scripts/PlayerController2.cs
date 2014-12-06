using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float x, y;
}

public class PlayerController2 : GenericPlayerController {

    public float speed;
    public Boundary boundary;

    void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(player.GetAxisH() * speed, player.GetAxisV() * speed);
        rigidbody2D.position = new Vector2(
            Mathf.Clamp(rigidbody2D.position.x, -boundary.x, boundary.x),
            Mathf.Clamp(rigidbody2D.position.y, -boundary.y, boundary.y));
    }
}
