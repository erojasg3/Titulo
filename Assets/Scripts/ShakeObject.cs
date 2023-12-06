using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    private Vector3 originPos;
    private Quaternion originRot;
    public float shake_decay = 0.003f;
    public float shake_intensity = .2f;
    public bool isShaking = false;

    private float temp_shake_intensity = 0;

    // Update is called once per frame
    void Update()
    {
        if(temp_shake_intensity > 0 && isShaking == true)
        {
            transform.position = originPos + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRot.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRot.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRot.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRot.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
            temp_shake_intensity -= shake_decay;
        }
        else
        {
            isShaking = false;
        }
    }

    public void Start()
    {
        if (!isShaking)
        {
            isShaking = true;
            originPos = transform.position;
            originRot = transform.rotation;
            temp_shake_intensity = shake_intensity;
        }
    }
}
