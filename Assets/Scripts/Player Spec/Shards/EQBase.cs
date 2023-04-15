using UnityEngine;

public class EQBase : PCFCM {
    [Header ( "EQ Base" )]
    protected   Rigidbody2D rgb;
    public enum InteractionSlot { MAIN, SEC };
    private string  axisString;

    public  InteractionSlot control;

    public void UpdateIS ( InteractionSlot a ) {
        if ( a == InteractionSlot.MAIN ) {
            axisString = "Fire2";
        }
        if ( a == InteractionSlot.SEC ) {
            axisString = "Fire3";
        }
    }   

    public override void Start () {
        if ( GetComponent <ItemHandle>() ) {
            GetComponent<ItemHandle> ().attachCallback = MainInit;
        }
        UpdateIS ( control );
        base.Start ();
    }

    public override void Update () {
        if ( Input.GetAxis ( axisString ) > 0 ) {
            TriggerHold ();
        } else {
            TriggerRelease ();
        }
        base.Update ();
    }

    public virtual void MainInit ( ItemPort port ) {
        if ( port == null ) return;
        enabled = port.bungholio;
        rgb = port.hullLink.GetComponent<Rigidbody2D> ();
    }
}