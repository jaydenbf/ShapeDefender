using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraSupport : MonoBehaviour
{
    private Camera mTheCamera;   // Will find this on the gameObject
    private Bounds mWorldBound;  // Computed bound from the camera

    // Lerp support
    private TimedLerp mPositionLerp = new TimedLerp(2f, 4f);  // 2 second duration, rate of 4 per second
    private TimedLerp mSizeLerp = new TimedLerp(2f, 4f);      // Similar values

    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    // Start is called before the first frame update
    void Awake()  // camera may be disabled by some in Start(), so init in Awake.
    {
        mTheCamera = gameObject.GetComponent<Camera>();
        Debug.Assert(mTheCamera != null); // if this is null, then, the script is not on a Camera and nothing works

    }

    void Update()
    {

    }

    #region Viewport support
    public void SetViewportMinPos(float x, float y)
    {
        Rect r = mTheCamera.rect;
        mTheCamera.rect = new Rect(x, y, r.width, r.height);
    }

    public void SetViewprotSize(float w, float h)
    {
        Rect r = mTheCamera.rect;
        mTheCamera.rect = new Rect(r.x, r.y, w, h);
    }

    #endregion

    #region Camera Manipulation
    public void MoveTo(Vector3 pos)
    {
        transform.position = pos;
    }

    public Vector3 getPos()
    {
        return this.transform.position;
    }

    // Activate or Deactivate Camera
    public void SetActive(bool activity)
    {
        gameObject.SetActive(activity);
    }

    // zoom > 1: zoom out, see more of the world
    // zoom < 1: zoom in, see less of the world
    // zoom == 0: ignored.
    public void Zoom(float zoom)
    {
        if (zoom > 0f)
        {
            Vector2 b, e;
            b.x = mTheCamera.orthographicSize;
            b.y = 0f;
            e.x = mTheCamera.orthographicSize * zoom;
            e.y = 0f;
            mSizeLerp.BeginLerp(b, e);
        }
    }

    // zoom > 1: zoom out, see more of the world
    // zoom < 1: zoom in, see less of the world
    // zoom == 0: ignored.
    public void ZoomTowards(Vector3 aPos, float zoom)
    {
        Vector3 delta = aPos - transform.position;
        delta *= (zoom - 1f);
        delta.z = 0f;
        Vector3 p = transform.position - delta;
        mPositionLerp.BeginLerp(transform.position, p);
        Zoom(zoom);
    }
    #endregion
}
