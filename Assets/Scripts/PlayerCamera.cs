using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    // public Transform lookAt;
    // private bool smooth = true;
    // private float smoothSpeed = 0.125f;
    // private Vector3 offset = new Vector3(0,0,-6.5f);
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;


    void Start()
    {
    }

    void Update(){
        

        


    if (bounds){
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
        Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
        Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
    }
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);


        transform.position = new Vector3(posX, posY, transform.position.z);
    }
    // private void LateUpdate()
    // {
    //     Vector3 desiredPosition = lookAt.transform.position + offset;
    //     transform.position = desiredPosition;
    // }
}
