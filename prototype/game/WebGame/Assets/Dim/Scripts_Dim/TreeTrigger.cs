using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrigger : MonoBehaviour
{
    public GameObject Pot;
    public GameObject Tree;
    private float timer = 100;
    private GameObject potArrow;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DragDrop>().dragging == false)
        {
            Debug.Log("Kerst");
            other.GetComponent<DragDrop>().TreeArrow.SetActive(false);
            potArrow = other.GetComponent<DragDrop>().PotArrow;

            StartCoroutine("Timer");
            //activate pot trigger
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                this.gameObject.SetActive(false);
                Tree.SetActive(false);
                Pot.SetActive(true);
                potArrow.SetActive(true);
                yield break;   // stop coroutine
            }

            yield return null; // wait one frame
        }
    }
}
