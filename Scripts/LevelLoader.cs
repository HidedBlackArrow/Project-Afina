using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen; // ����� ������� ���������
    public Slider slider; // ������� ���������
    public TMPro.TMP_Text progressText; // �������� ��� ��������
    public TMPro.TMP_Text TagPlayerBox; // ��� ������ � ����������
    public static string tagName;

    public void LoadLevel(int sceneIndex)
    {
        tagName = TagPlayerBox.text.ToString();
        if (tagName != "") // �������� ������� ����
        {
            PlayerPrefs.SetString("PlayerTagTMP", tagName);
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
        else
        {
            PlayerPrefs.SetString("PlayerTagTMP", "Unknown");
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
        //StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex) // ��������
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //Clamp01 ���������
            Debug.Log(progress);                                      //�������� �� 0 �� 1      

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
