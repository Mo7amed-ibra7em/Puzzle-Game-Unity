using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameControl.Win)
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
