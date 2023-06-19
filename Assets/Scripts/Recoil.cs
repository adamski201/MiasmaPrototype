using UnityEngine;

public class Recoil : MonoBehaviour
{
    private bool recoil = false;
    public bool InRecoil
    {
        get
        {
            if (!recoil || (recoil && Time.time >= recoilTimer))
            {
                recoil = false;
                return false;
            }
            else
            {
                return true;
            }
        }
        set
        {
            recoilTimer = Time.time + recoilTime;
            recoil = value;
        }
    }

    private float recoilTimer;
    [SerializeField] private float recoilTime = 0.3f;
}
