using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(LogAndDelete("Ray hit object: " + hit.collider.gameObject.name));
                
                if (!IsPointerOverUIObject())
                {
                    StartCoroutine(LogAndDelete("Clicked on non-UI object"));
                }
            }
            else
            {
                StartCoroutine(LogAndDelete("Ray did not hit any object"));
            }
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private IEnumerator LogAndDelete(string message)
    {
        Debug.Log(message);
        yield return new WaitForSeconds(2f);
        Debug.ClearDeveloperConsole();
    }
}
