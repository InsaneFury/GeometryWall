using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* public Transform to;
     //public Transform player;
     public float rotationSpeed = 20f;
     float rotateGrades = 90f;

     private void Start()
     {
        to = this.transform;
     }

     void Update()
     {

         transform.rotation = Quaternion.RotateTowards(
             transform.rotation,
             to.rotation,
             rotationSpeed * Time.deltaTime);

         if (Input.GetKeyDown(KeyCode.A))
         {
             to.rotation = Quaternion.Euler(to.rotation.x, to.rotation.y + rotateGrades, to.rotation.z);
             Debug.Log("Rotate Left");
         }
         if (Input.GetKeyDown(KeyCode.D))
         {
             Debug.Log("Rotate Right");
         }

     }*/

    private Quaternion startingRotation;
    public float speed = 10;
    public float leftDegrees = -90f;
    public float rightDegrees = 90f;

    void Start()
    {
        //save the starting rotation
        startingRotation = this.transform.rotation;
    }

    void Update()
    {
        //return back to the starting rotation
        /*if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(0));
        }*/

        //go to 90 degrees with right arrow
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(rightDegrees));
        }

        //go to -90 degrees with left arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StopAllCoroutines();
            StartCoroutine(Rotate(leftDegrees));
        }

    }

    IEnumerator Rotate(float rotationAmount)
    {
        Quaternion finalRotation = Quaternion.Euler(0, this.transform.rotation.y + rotationAmount, 0) * startingRotation;

        while (this.transform.rotation != finalRotation)
        {
            startingRotation = Quaternion.Euler(0, startingRotation.y + rotationAmount, 0);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime * speed);
            yield return 0;
        }
    }
}
