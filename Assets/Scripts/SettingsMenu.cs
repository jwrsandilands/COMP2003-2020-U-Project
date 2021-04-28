﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class SavedSettings
{
    public float Volume;
    public bool fullScreen;
    public int resolutionIndex;
}

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public Dropdown buttonPaddingDropdown;

    float currentVolume;
    private int currentResolutionIndex;
    Resolution[] resolutions;
    bool FullScreen = false;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width
                    && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        Debug.Log(currentResolutionIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MusicVol", volume);
        currentVolume = volume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        FullScreen = isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log(resolutionIndex);
        currentResolutionIndex = resolutionIndex;
    }

    public void SaveSettings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SavedSettings.dat");
        SavedSettings data = new SavedSettings();
        data.Volume = currentVolume;
        data.fullScreen = FullScreen;
        data.resolutionIndex = currentResolutionIndex;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Settings has saved in " + file.Name);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (File.Exists(Application.persistentDataPath + "/SavedSettings.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedSettings.dat", FileMode.Open);
            SavedSettings data = (SavedSettings)bf.Deserialize(file);
            file.Close();
            SetVolume(data.Volume);
            SetResolution(currentResolutionIndex);
            SetFullScreen(data.fullScreen);
            Debug.Log("Game data is loaded!");
        }
        else
            Debug.Log("There is no saved data!");
    }
}
