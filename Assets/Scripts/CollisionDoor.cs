using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDoor : MonoBehaviour
{

    public float speed = 10;

    private void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(moveHorizontal,0,moveVertical);
        transform.position+=movimiento * speed * Time.deltaTime;
    }
}
