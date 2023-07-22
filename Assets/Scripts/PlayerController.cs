using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveInput;

    public void OnMove()
    {
        moveInput = UserInput.instance.moveInput.x;

        print(moveInput);
    }
}
