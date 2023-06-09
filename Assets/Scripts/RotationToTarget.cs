using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToTarget : MonoBehaviour
{
    public float rotationSpeed;
    public float moveSpeed;
    private Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        //Getting the mouse position in the camera area
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Getting the vector of direction to go by
        //substracting the two vector2
        direction = cursorPos - transform.position;

        //Getting the angle out of the vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Transforming angle into a rotation
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
        //time.deltaTime smoosys the move overtime
        
    }
}
