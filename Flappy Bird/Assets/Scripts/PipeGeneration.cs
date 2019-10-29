using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneration : MonoBehaviour
{
    #region Getting The Pipes
    [SerializeField]
    GameObject pipe1;
    [SerializeField]
    GameObject pipe2;
    #endregion

    float timer;
    float timerMax = 2.5f;
    void Update()
    {
        //En timer som räknar uppåt med deltaTime
        timer += Time.deltaTime;
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
        randnum1 = Random.Range(-6, -14);
        print(randnum1);
        float offset;
        offset = Random.Range(10, 12);
        print(offset);
        #endregion

        //Gör två rör och placerar dem random
         Instantiate(pipe1, new Vector3(-22, randnum1, 0), Quaternion.identity);
         Instantiate(pipe2, new Vector3(-22, randnum1 + offset, 0), Quaternion.identity);

    }
}
