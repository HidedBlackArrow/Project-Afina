using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowLevel : MonoBehaviour
{
    public TMPro.TMP_Text curentlevel;

    public void Resume()
    {
        Time.timeScale = 1f;    //������� �����
    }

    void Start() // ���������� ����� ������
    {
        Resume();
        curentlevel.text = "LVL" + SceneManager.GetActiveScene().buildIndex;
    }

}
