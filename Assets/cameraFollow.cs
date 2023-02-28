using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float speed;

    public Transform target;

   private void Update() {
    Vector3 newPos = new Vector3 (target.position.x, 0, -10f);
    //in 2D camera position Z stays at -10. If it was 0, you would not be able to see anything.
    transform.position = Vector3.Slerp(transform.position, newPos, speed*Time.deltaTime);

   }

}
