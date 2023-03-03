using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{   
    float timecount = 30;
    
    bool isEnd = false;

    [SerializeField] TextMeshProUGUI Timetext;
    [SerializeField] GameObject WIN;
    [SerializeField] GameObject LOSE;

    bool isFound = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd == false){
            timecount = timecount - Time.deltaTime; 
            Timetext.text = "TIME: " + Mathf.Round(timecount).ToString();
        }
         
        if(timecount<0){
            isEnd = true;
            if(isFound == true){
                WIN.SetActive(true);
            }else{
                LOSE.SetActive(true);
            }
        }

        
    }
    public void FoundAllitems(bool arg){
        isFound = arg;
    }
}
