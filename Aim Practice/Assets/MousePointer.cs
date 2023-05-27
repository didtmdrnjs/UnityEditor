using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    private Vector3 point;
    private Vector2 point2D;
    private Ray ray;
    private RaycastHit2D hitData;
    private TargetDelete target;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9.5f));
        transform.position = point;
        point2D = new Vector2(point.x, point.y);

        if (Input.GetMouseButtonDown(0)) {  
            hitData = Physics2D.Raycast(point2D, transform.forward, 20);
            if (hitData.transform.CompareTag("target")) {
                target = hitData.transform.GetComponent<TargetDelete>();
                target.Hit();
                result.hit++;
            }
            else {
                result.miss++;
            }
        }
    }
}
