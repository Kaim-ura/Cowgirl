using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingHero : MonoBehaviour
{
    public GameObject Hero;
    public float smooth;

    private Vector3 currVelocity;
    
    private void Update()
    {
        Vector3 newCameraPosition = new Vector3(Hero.transform.position.x, Hero.transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currVelocity, smooth);

        // In this way camera follow directly player previous way create delay.
        //transform.position = newCameraPosition;
    }
}
