using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Restart()//�������볡��
    {
        SceneManager.LoadScene(0);//filr->build setting
    }
}
