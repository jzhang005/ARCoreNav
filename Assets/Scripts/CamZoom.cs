using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    Vector3 touchStart;
    public GameObject player;
    public float perspectiveZoomSpeed = .5f;
    public float orthoZoomSpeed = .5f;

    Vector3 pos;
    Vector3 cameraPos;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            this.transform.position = new Vector3(touchZero.position.x / 51.8f, 20f, touchZero.position.y / 49.33f);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

            Camera.main.fieldOfView += deltaMagnitudediff * perspectiveZoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 50f, 115f);
        }
        else
        {
            pos = player.transform.position;
            cameraPos.x = pos.x;
            cameraPos.y = 20f;
            cameraPos.z = pos.z;
            this.transform.position = cameraPos;
        }

    }
}
