
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float slowDownFactor = 0.3f;
    public float slowDownLength = 10f;

    public float currentSlowMo = 0f;
    public float slowTimeAllowed = 2f;
    public bool freeze;

    void Update()
    {
        
        print("update");
        if (Time.timeScale <1)
        {
            print("asdf");
            currentSlowMo += Time.deltaTime;
            print(currentSlowMo);
            
        }

        if(currentSlowMo > slowTimeAllowed)
        {
            currentSlowMo = 0;
            if(freeze == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

    }

    public void SlowMotion()
    {
        Time.timeScale = slowDownFactor;
        print("SLOWMO");
    }

}
