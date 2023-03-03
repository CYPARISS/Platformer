using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterScript2 : MonoBehaviour
{
    CharacterController char_contr;

    [SerializeField] TextMeshProUGUI score_number;

    public TimeController time_script;

    float vertical;

    bool isGround = false;

    int count = 0;

    float mousex;
    // Start is called before the first frame update
    void Start()
    {
        char_contr = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        char_contr.SimpleMove(transform.forward * vertical * 5f);

        if(Input.GetKeyDown("space") && isGround == true){
            char_contr.Move(transform.up * 1f);
        }

        isGround = false;

        mousex = Input.GetAxis("Mouse X");
        transform.Rotate(0,mousex,0);

        
    }
    void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.gameObject.tag == "item"){
            hit.gameObject.GetComponent<ParticleSystem>().Play();
            hit.gameObject.GetComponent<SphereCollider>().enabled = false;
            hit.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //Destroy(hit.gameObject, 1f/2);
            count++;
            score_number.text = count.ToString();
            if(count == 4){
                time_script.FoundAllitems(true);
            } 
        }

        if(hit.gameObject.tag == "ground"){
            isGround = true;
        }

        if(hit.gameObject.tag == "DIE"){
            gameObject.SetActive(false);
        }
    }

}
