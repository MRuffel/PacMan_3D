using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
     AudioClass[] m_sounds;

    //Instance
    public static AudioManager m_instance = null;

    void Awake() {

        #region Singleton
        //Manage the singleton lifecycle

        if (m_instance == null)
                m_instance = this;
            else if (m_instance != this)
                Destroy(this);
        #endregion

        foreach (Sound m_sound in m_sounds) {

            m_sounds.m_audioSource = gameObject.AddComponent<AudioSource>();
            m_sounds.m_audioSource.m_audioClip = m_sounds.m_audioClip;

            m_sounds.m_audioSource.volume = m_sounds.m_volume;        
        }
    }
    public void Play(string m_name)
        {
            Sound m_newSound = Array.Find(m_sounds, m_sound => m_sound.name == m_name);
            m_newSound.m_audioSource.Play();
        }

}
