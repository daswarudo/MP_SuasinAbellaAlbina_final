using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.Windows;
using Unity.VisualScripting;

public class Gun : MonoBehaviour
{
    public float impactForce = 10;
    public AudioSource sound;
    private StarterAssetsInputs _input;
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public LineRenderer lineRenderer;
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();    
    }
    void Update()
    {
        if (_input.shoot)
        {
            Shoot();
            //break;
            _input.shoot = false;
            sound.Play();
        }
    }
    void Shoot()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
        lineRenderer.enabled = true;
        StartCoroutine(DisableLineRendererAfterDelay(0.25f));
    }

    IEnumerator DisableLineRendererAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Disable the Line Renderer after the specified delay
        lineRenderer.enabled = false;
    }
}
