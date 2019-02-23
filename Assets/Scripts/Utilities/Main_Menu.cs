using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Play(int m_sceneNumber) {

        SceneManager.LoadScene(m_sceneNumber);

    }
}
