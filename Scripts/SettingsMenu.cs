using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    //public TMPro.TMP_Dropdown FpsDropdown;

    public Toggle boxFps;
    public Toggle vsyncToggle;

    Resolution[] resolutions;

    int maxFPS = 60;
    

    // Start is called before the first frame update
    void Start()
    {
        //resolution
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
        //FPS
        if (PlayerPrefs.GetInt("ShowFPS") == 1)
        {
            boxFps.isOn = true;
        }
        else 
        {
            boxFps.isOn = false;
        }
        Application.targetFrameRate = maxFPS;

        /*//VSync (не надо)
        if (vsyncToggle.isOn == true)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }*/

        /*//resolutions = Screen.resolutions;
        
        FpsDropdown.ClearOptions();
        List<string> optionsfps = new List<string>();
        
        int FPSIndex = 0;
        //optionsfps.Add("30");
        //optionsfps.Add("60");
        //optionsfps.Add("90");
        for (int i = 30; i <= 90; i+=15)
        {
            string optionfps = i;
            optionsfps.Add(option);
            FPSIndex = i;

        }
        FpsDropdown.AddOptions(optionsfps);
        FpsDropdown.value = FPSIndex;
        FpsDropdown.RefreshShownValue();
        //Fps = optionfps[FPSIndex];*/
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ShowFps()
    {
        if (boxFps.isOn)
        {
            PlayerPrefs.SetInt("ShowFPS", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ShowFPS", 0);
        }
    }

    public void SetVSync()
    {
        if (QualitySettings.vSyncCount == 1)
        {
            vsyncToggle.isOn = true;
        }
        else
        {
            vsyncToggle.isOn = false;
        }
    }

    public void SetFPS(int Fps)
    {
        /*
        Optionsfps optionsfp = optionsfps[FPSIndex];
        Application.targetFrameRate = (int)optionsfp[FPSIndex];//Fps;*/

        maxFPS = Fps;
        Application.targetFrameRate = maxFPS;

            //Application.targetFrameRate = (int)optionsfps;
        /*Optionsfps[] optionsfs = resolutions[resolutionIndex];
        Application.targetFrameRate(resolutions.resolutionIndex);*/

    }

    private bool active = false;
    public void ChangeLocale(int localeId)
    {
        if (active == true)
            return;
        StartCoroutine(SetLocale(localeId));
    }

    IEnumerator SetLocale(int _localeId)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeId];
        active = false;
    }

    
}
