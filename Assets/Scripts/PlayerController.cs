using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float spe = 5f;
    private Rigidbody rb;
    public Transform cameraTransform;
    public AudioClip slimeKill;
    private AudioSource audioSource;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = (camForward * v + camRight * h) * spe;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash(moveDir));
        }


        rb.AddForce(moveDir);

    }
    private IEnumerator Dash(Vector3 direction)
    {
        float dashSpeed = spe * 1.2f;
        float dashDuration = 0.2f;

        rb.AddForce(direction * dashSpeed, ForceMode.Impulse);

        yield return new WaitForSeconds(dashDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            RandomMove rm = other.GetComponent<RandomMove>();
            rm.Kill();
            audioSource.PlayOneShot(slimeKill);
        }
    }
}
