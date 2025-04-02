using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    private static PlayerCam self;

    public float sensitivityX = 1;
    public float sensitivityY = 1;

    public Transform camPos;

    public float yaw = 0;
    private float pitch = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // destroys if game is beaten. This allows for reset for play again
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Destroy(self);
            Destroy(gameObject);
        }

        // camera moves with mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        yaw += mouseX;
        pitch -= mouseY;

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        camPos.rotation = Quaternion.Euler(0, yaw, 0);


        // camera's position sticks to player
        transform.position = camPos.position;
    }
}
