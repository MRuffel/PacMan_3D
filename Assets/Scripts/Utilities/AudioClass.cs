using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioClass 
{
    #region Variable
    string m_audioName;

    AudioClip m_audioClip;

    [Range(0f, 1f)]
    float m_volume;

    [HideInInspector]
    AudioSource m_audioSource;
    #endregion
}
