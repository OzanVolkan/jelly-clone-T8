using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JellyCollision : MonoBehaviour
{
    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;

    public GameObject pathDisable;
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            GhostJelly.instance.GhostPosition();

        }
        if (other.CompareTag("Finish"))
        {
            winScreen.SetActive(true);
            cam1.SetActive(false);
            cam2.SetActive(true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            failScreen.SetActive(true);
            Invoke("Stop", .75f);
        }
    }
    public void Stop()
    {
        Time.timeScale = 0;
    }
}
