using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CollectPrize : MonoBehaviour
{
    public Text prizes;
    public Text result;
    int prizeCounter = 0;
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Meat")
        {
            Destroy(other.gameObject);
            prizeCounter++;
            prizes.text = prizeCounter.ToString();
        }
        if (prizeCounter == 3)
        {
            result.text = "You Won";
            StartCoroutine(Restart());

        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}
