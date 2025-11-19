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
                    if(!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }

                    selectedOject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                Vector3 posittion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedOject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(posittion);
                selectedOject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

                selectedOject = null;
                Cursor.visible = true;s
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
}
