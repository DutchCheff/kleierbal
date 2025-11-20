using Unity.VisualScripting;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedOject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(selectedOject == null)
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)
                {
                    if(hit.collider.CompareTag("drag"))
                    {
                        selectedOject = hit.collider.gameObject;
                        Cursor.visible = false;
                        gameObject.GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }
            else
            {
                RaycastHit hit = CastRay();
                Vector3 posittion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedOject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(posittion);
                selectedOject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

                selectedOject = null;
                Cursor.visible = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;

                if (hit.collider.CompareTag("boom"))
                {
                    SetBoomLocation();
                }
            }
        }

        if (selectedOject != null)
        {
            Vector3 posittion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedOject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(posittion);
            selectedOject.transform.position = new Vector3(worldPosition.x, worldPosition.y , worldPosition.z);
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
            );
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

    public void SetBoomLocation()
    {
        transform.position = new Vector3(-1 , 2, -2);
    }
}
