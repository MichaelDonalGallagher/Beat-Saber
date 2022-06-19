using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberScript : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    private Vector3 swipeDirection;
    RaycastHit raycastHit;
    public Transform raycast;


    void Start()
    {
        previousPos = this.GetComponent<Transform>().position;
    }

    void Update()
    {
        Ray ray = new Ray(raycast.position, this.GetComponent<Transform>().forward * 1);

        swipeDirection = this.GetComponent<Transform>().position - previousPos;
        if (Physics.Raycast(ray, out raycastHit, 1, layer))
        {
            if(Vector3.Angle(raycastHit.transform.up, swipeDirection) > 140)
            {
                //print("HIT!");
                //print(raycastHit.transform);
                raycastHit.transform.GetComponent<CubeScript>().SplitCube(raycastHit);
            }
            else
            {
                print("Wrong Direction!");
            }
        }
        previousPos = this.GetComponent<Transform>().position;
    }
}
