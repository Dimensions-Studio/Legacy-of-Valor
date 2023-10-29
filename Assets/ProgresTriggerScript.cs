using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgresTriggerScript : MonoBehaviour
{
    [SerializeField]
    Material greenMaterial;
    [SerializeField]
    Material redMaterial;
    
    [SerializeField]
    List<Animator> wheelsAnimator;
    



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManagerScript.Instance.playing = true;
            wheelsAnimator[0].enabled = true;
            wheelsAnimator[1].enabled = true;
            wheelsAnimator[2].enabled = true;
            wheelsAnimator[3].enabled = true;
            wheelsAnimator[4].enabled = true;
            gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")   
        {
            GameManagerScript.Instance.playing = false;
            wheelsAnimator[0].enabled = false;
            wheelsAnimator[1].enabled = false;
            wheelsAnimator[2].enabled = false;
            wheelsAnimator[3].enabled = false;
            wheelsAnimator[4].enabled = false;
            gameObject.GetComponent<MeshRenderer>().material = redMaterial;
        }
    }

}
