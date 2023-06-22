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
        scroll = Input.GetAxis("Mouse ScrollWheel"); //���� �������� ��� ������ ����
        pos.y += scroll * scrollSpeed * 10f * Time.deltaTime; // �������� �����

        pos.y = Mathf.Clamp(pos.y, minY, maxY); //����������� ������� ������ 
        transform.position = pos; //������� �������� Unity
    }

}