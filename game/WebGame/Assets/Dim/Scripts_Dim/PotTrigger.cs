using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotTrigger : MonoBehaviour
{
    public GameObject Flower;
    private float timer = 4;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DragDrop>().dragging == false)
        {
            Flower.SetActive(true);
            other.gameObject.GetComponent<DragDrop>().PotArrow.SetActive(false);
            other.gameObject.SetActive(false);

            StartCoroutine("Timer");
            //activate flower and deactivate egg
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SceneManager.LoadScene("EndMenu");
                yield break;   // stop coroutine
            }

            yield return null; // wait one frame
        }
    }

}
