using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseDirection : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 directionToMouse = mouseWorldPosition -transform.position;
        transform.up = directionToMouse.normalized;
    }
}
