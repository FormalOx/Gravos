using UnityEngine;

public class Autodisabler : MonoBehaviour {
    public  float       lifespan;
    private  float      deltaT;

    public virtual void OnEnable () {
        deltaT = lifespan;
    }

    public virtual void Update () {
        if ( deltaT > 0 ) {
            deltaT -= Time.deltaTime;
            if ( deltaT < 0 ) {
                gameObject.SetActive( false );
            }
        }
    }
}
