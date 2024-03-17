using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thend : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GoodEnd();
    }
    public void GoodEnd()
    {
        SceneManager.LoadScene("GoodEnd");
    }
}