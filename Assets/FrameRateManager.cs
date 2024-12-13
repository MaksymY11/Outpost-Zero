using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrameRateManager : MonoBehaviour
{
    public TMP_Dropdown frameRateDropdown; // Reference to the Dropdown
    private const string FrameRateKey = "FrameRateSetting";

    private void Start()
    {
        // Load saved frame rate setting
        int savedFrameRate = PlayerPrefs.GetInt(FrameRateKey, 60);
        SetFrameRate(savedFrameRate);

        // Update dropdown to match the saved setting
        int dropdownIndex = GetDropdownIndex(savedFrameRate);
        frameRateDropdown.value = dropdownIndex;

        // Add listener for dropdown value change
        frameRateDropdown.onValueChanged.AddListener(OnFrameRateChanged);
    }

    private void OnFrameRateChanged(int index)
    {
        int selectedFrameRate = GetFrameRateFromIndex(index);
        SetFrameRate(selectedFrameRate);

        // Save the selected frame rate
        PlayerPrefs.SetInt(FrameRateKey, selectedFrameRate);
        PlayerPrefs.Save();
    }

    private void SetFrameRate(int frameRate)
    {
        // Apply frame rate setting
        Application.targetFrameRate = frameRate == 0 ? -1 : frameRate; // -1 means unlimited
    }

    private int GetFrameRateFromIndex(int index)
    {
        switch (index)
        {
            case 0: return 30;
            case 1: return 60;
            case 2: return 0; // Unlimited
            default: return 60;
        }
    }

    private int GetDropdownIndex(int frameRate)
    {
        switch (frameRate)
        {
            case 30: return 0;
            case 60: return 1;
            case 0: return 2; // Unlimited
            default: return 1;
        }
    }
}

