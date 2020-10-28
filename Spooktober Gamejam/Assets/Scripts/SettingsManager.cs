using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class SettingsManager : ScriptableSingleton<SettingsManager>
{
    public static SettingsManager instance;
    public float volume = 0f;
    public float sensivity = 0.5f;
}
