using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen; // сцена загруки прогресса
    public Slider slider; // слайдер прогресса
    public TMPro.TMP_Text progressText; // прогресс бар проценты
    public TMPro.TMP_Text TagPlayerBox; // “ег игрока с клавиатуры
    public static string tagName;

    public void LoadLevel(int sceneIndex)
    {
        tagName = TagPlayerBox.text.ToString();
        if (tagName != "") // проверка наличи€ тега
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

    IEnumerator LoadAsynchronously(int sceneIndex) // загрузка
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); //Clamp01 приеимает
            Debug.Log(progress);                                      //значение от 0 до 1      

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
