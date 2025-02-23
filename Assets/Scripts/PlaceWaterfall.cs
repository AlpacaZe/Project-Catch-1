using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlaceWaterfall : MonoBehaviour
{
    public AudioSource projectSound;
    public GameObject watfallSound2;
    public GameObject mainCam;
    RaycastHit hit;
    [SerializeField] GameObject cliffwf1;
    [SerializeField] GameObject cliffwf2;
    [SerializeField] GameObject cliffwf3;
    [SerializeField] GameObject cliffwf4;
    [SerializeField] GameObject cliffwf5;
    [SerializeField] GameObject cliffwf6;

    int layerMask = 1 << 6;

    public GameObject waterfallReady;
    public GameObject waterfallOK;
    public GameObject waterfallOK_s;
    public GameObject waterfallCheck;
    public GameObject waterfallPic;
    public GameObject waterfallPicPro;
    public GameObject wf_sPic;
    public GameObject wf_sPicPro;

    // Update is called once per frame
    void Update()
    {
        if (waterfallPic.activeSelf == true || wf_sPic.activeSelf == true)
        {
            cliffwf1.GetComponent<MeshRenderer>().enabled = true;
            cliffwf2.GetComponent<MeshRenderer>().enabled = true;
            cliffwf3.GetComponent<MeshRenderer>().enabled = true;
            cliffwf4.GetComponent<MeshRenderer>().enabled = true;
            cliffwf5.GetComponent<MeshRenderer>().enabled = true;
            cliffwf6.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            cliffwf1.GetComponent<MeshRenderer>().enabled = false;
            cliffwf2.GetComponent<MeshRenderer>().enabled = false;
            cliffwf3.GetComponent<MeshRenderer>().enabled = false;
            cliffwf4.GetComponent<MeshRenderer>().enabled = false;
            cliffwf5.GetComponent<MeshRenderer>().enabled = false;
            cliffwf6.GetComponent<MeshRenderer>().enabled = false;
        }

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 50,layerMask) && waterfallPic.activeSelf == true)
        {
            //Debug.Log(hit.collider.name);
            if (hit.collider.gameObject == waterfallCheck)
            {
                waterfallReady.GetComponent<MeshRenderer>().enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    projectSound.Play();
                    waterfallOK.GetComponent<DOTweenAnimation>().DOPlay();
                    waterfallReady.GetComponent<MeshRenderer>().enabled = false;
                    waterfallPic.gameObject.SetActive(false);
                    waterfallPicPro.SetActive(false);
                    watfallSound2.SetActive(true);
                }
            }
            else
            {
                waterfallReady.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 50, layerMask) && wf_sPic.activeSelf == true)
        {
            //Debug.Log(hit.collider.name);
            if (hit.collider.gameObject == waterfallCheck)
            {
                waterfallReady.GetComponent<MeshRenderer>().enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    projectSound.Play();
                    waterfallOK_s.GetComponent<MeshRenderer>().enabled = true;
                    waterfallReady.GetComponent<MeshRenderer>().enabled = false;
                    wf_sPic.gameObject.SetActive(false);
                    wf_sPicPro.SetActive(false);
                }
            }
            else
            {
                waterfallReady.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnDisable()
    {
        cliffwf1.GetComponent<MeshRenderer>().enabled = false;
        cliffwf2.GetComponent<MeshRenderer>().enabled = false;
        cliffwf3.GetComponent<MeshRenderer>().enabled = false;
        cliffwf4.GetComponent<MeshRenderer>().enabled = false;
        cliffwf5.GetComponent<MeshRenderer>().enabled = false;
        cliffwf6.GetComponent<MeshRenderer>().enabled = false;
    }
}
