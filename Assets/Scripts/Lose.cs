using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    public Text text;
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Fail")
        {
            text.text = "You Lost";
            StartCoroutine(Restart());
        }

    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}

