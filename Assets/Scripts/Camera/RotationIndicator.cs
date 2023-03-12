using UnityEngine;

public class RotationIndicator : MonoBehaviour {
    public  Rigidbody2D     rgb;
    public  float           angleNeutralDrag;
    public  Transform       indicator;

    private void Start() {
        if ( angleNeutralDrag == -1 ) {
            TeflonPMove delta;
            if ( transform.parent.TryGetComponent( out delta ) ) {
                angleNeutralDrag = delta.angleNeutralDrag;
            }
        }
    }

    void LateUpdate() {
        Vector2 rhoIndicator = rgb.transform.up;
        float rhoSpeed = rgb.angularVelocity;
        int safety = 400;

        while ( Mathf.Abs( rhoSpeed ) > 0.05f && safety-- > 0 ) {
            rhoIndicator = Quaternion.Euler( 0, 0, rhoSpeed * Time.fixedTime ) * rhoIndicator;
            rhoSpeed -= rhoSpeed * angleNeutralDrag * Time.fixedTime;
        }

        indicator.rotation = Quaternion.FromToRotation( Vector2.up, rhoIndicator );
    }
}
