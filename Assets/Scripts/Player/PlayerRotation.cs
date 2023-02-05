using UnityEngine;

/// <summary>
/// Use this scripts on player camera.
/// </summary>


public class PlayerRotation : MonoBehaviour
{

    [SerializeField] Transform cameraLookout = null;
    [SerializeField] float distanceX = 10;
    [SerializeField] float distanceY = 1;

    private float currentAngle = 0;
    private float lastAngle = 0;
    private float destinationAngle = 0;
    private float progressLerp = 0;
    private bool onMove = false;

    private void Update()
    {
        if (PauseMenu.isPause)
            return;
        if (cameraLookout == null)
            return;
        updateControl();
        updateMove();
        
    }

    public void updateMove()
    {
        if (!onMove)
            return;

        Vector3 v3 = Vector3.zero;

        if (GetDistance(currentAngle, destinationAngle)>0.01f) //going
        {
            progressLerp += Time.deltaTime;
            currentAngle = Mathf.Lerp(lastAngle, destinationAngle, progressLerp);
        }
        else //arrive
        {
            if (destinationAngle > Mathf.PI * 2)
                destinationAngle = Mathf.PI / 2;
            else if (destinationAngle < -0.5)
                destinationAngle = Mathf.PI*2 - Mathf.PI/2;

            currentAngle = destinationAngle;

            onMove = false;
        }

        v3.x = distanceX * Mathf.Cos(currentAngle);
        v3.z = distanceX * Mathf.Sin(currentAngle);
        v3.y = distanceY;
        transform.position = v3 + cameraLookout.transform.position;

        transform.LookAt(cameraLookout.transform.position);


    }
    public void updateControl()
    {
        if (onMove)
            return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            progressLerp = 0;
            lastAngle = currentAngle;
            destinationAngle += Mathf.PI/4;
            onMove = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            progressLerp = 0;
            lastAngle = currentAngle;
            destinationAngle -= Mathf.PI / 4;
            onMove = true;
        }
    }

    private float GetDistance(float a, float b)
    {
        if (a < b)
            return Mathf.Abs (b - a);
        else if (a > b)
            return Mathf.Abs (a - b);
        else
            return 0;
    }
}
