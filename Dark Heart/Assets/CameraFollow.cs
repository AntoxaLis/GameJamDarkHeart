using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; //The target with is followed by camera
    [SerializeField] private float smoothSpeed = 5f; //Speed of camera
    [SerializeField] private Vector2 offset = new Vector2(0, 0); //disposition of camera
    [SerializeField]  private Vector2 deadZone = new Vector2(2f, 2f); //Zone of the cube were camera doesn't move

    private void LateUpdate()
    {
        //Verify the position of camera
        Vector3 desiredPosition = target.position + new Vector3(offset.x, offset.y, transform.position.z);

        //Verify, if target is in "deadZone"
        if (Mathf.Abs(transform.position.x - target.position.x) > deadZone.x / 2f)
        {
            desiredPosition.x = Mathf.Lerp(transform.position.x, target.position.x + offset.x, smoothSpeed * Time.deltaTime);
        }

        if (Mathf.Abs(transform.position.y - target.position.y) > deadZone.y / 2f)
        {
            desiredPosition.y = Mathf.Lerp(transform.position.y, target.position.y + offset.y, smoothSpeed * Time.deltaTime);
        }

        //Changing position of camera if needed
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
