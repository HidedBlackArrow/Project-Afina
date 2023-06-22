using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUP : MonoBehaviour
{
    public float scrollSpeed = 20f;

    public float minY = 0;
    public float maxY = 5;

    float scroll;

    void Update()
    {
        Vector3 pos = transform.position;
        scroll = Input.GetAxis("Mouse ScrollWheel"); //Берём значение оси колеса мыши
        pos.y += scroll * scrollSpeed * 10f * Time.deltaTime; // движение лифта

        pos.y = Mathf.Clamp(pos.y, minY, maxY); //Определение предела работы 
        transform.position = pos; //Передаём значение Unity
    }

}