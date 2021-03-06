using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour
{
    bool p1Won = false;
    public Text result;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            GetComponent<SpriteRenderer>().color = Color.red;

            Physics2D.IgnoreCollision(GameObject.Find("Player1").GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(GameObject.Find("Player2").GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), false);
            p1Won = true;
        }
        if (other.gameObject.name == "Player2")
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;

            Physics2D.IgnoreCollision(GameObject.Find("Player2").GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(GameObject.Find("Player1").GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), false);
            p1Won = false;

        }

        if (other.gameObject.name == "LeftWall")
        {
            this.transform.position += new Vector3(0.4f, 0.2f, 0);


        }
        if (other.gameObject.name == "RightWall")
        {
            this.transform.position += new Vector3(-0.4f, 0.2f, 0);
        }

        if (other.gameObject.tag == "Ground")
        {
            this.transform.position += new Vector3(0.05f, 0.1f, 0);


        }
        if (other.gameObject.name == "Floor")
        {
            if (p1Won)
            {
                result.text = "Player 1 is the Winner!";
                StartCoroutine(Restart());

            }
            else
            {
                result.text = "Player 2 is the Winner!";
            }
            StartCoroutine(Restart());

        }
        IEnumerator Restart()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Menu");
        }

    }
}



