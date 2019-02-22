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

        foreach (AudioClass m_sound in m_sounds) {

            m_sound.m_audioSource = gameObject.AddComponent<AudioSource>();
            m_sound.m_audioSource.clip = m_sound.m_audioClip;

            m_sound.m_audioSource.volume = m_sound.m_volume;

            Play("Siren");
        }
    }

    public void Play(string m_name)
        {
            AudioClass m_newSound = Array.Find(m_sounds, m_sound => m_sound.m_audioName == m_name);
            m_newSound.m_audioSource.Play();
        }

}
