using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneration : MonoBehaviour
{
    #region Getting prefabs, Pipes and Point Area
    [SerializeField]
    GameObject pipe1;
    [SerializeField]
    GameObject pipe2;
    [SerializeField]
    GameObject pointArea;
    #endregion

    float timer;
    float timerMax = 1.5f;
    void Update()
    {
        //En timer som räknar uppåt med deltaTime
        timer += Time.deltaTime;

        //Placerar Rören med en timer som blir kortare för varje gång
        if (timer >= timerMax)
        {
            MakePipe();
            timer = 0;
            if (timerMax > 1)
            {
                timerMax -= 0.03f;
            }
        }
    }

    void MakePipe()
    {

        #region RNG
        float randnum1;
        randnum1 = Random.Range(-5.5f, -14.5f);
        
        float offset;
        offset = Random.Range(10, 12);
        
        #endregion 

        //Gör två rör och placerar dem ungefär random 
        Instantiate(pipe1, new Vector3(-22, randnum1, 0), Quaternion.identity);
        Instantiate(pipe2, new Vector3(-22, randnum1 + offset, 0), Quaternion.identity);
        Instantiate(pointArea, new Vector3(-22, randnum1, 0), Quaternion.identity); // Makes an invisible trigger cube that spawns along with the pipes

    }
}
