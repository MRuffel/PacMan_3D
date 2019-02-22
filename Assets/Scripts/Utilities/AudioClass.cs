using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioClass 
{
    #region Variable
    public string m_audioName;

    public AudioClip m_audioClip;

   

    [Range(0f, 1f)]
    public float m_volume;

    [SerializeField]
    public AudioSource m_audioSource;
    #endregion

    
}
