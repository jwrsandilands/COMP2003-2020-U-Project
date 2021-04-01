using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMiniGame : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform fishMarker;

    float fishPosition;
    float fishDestination;

    float fishTimer;

    [SerializeField] float timerMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize;
    [SerializeField] float hookPower = 5f;
    float hookProgress = 1f;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookDegredationPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform lifeBarContainer;

    bool pause = false;


    private void Start()
    {
        Resize();
    }

    
    private void Update()
    {
        if (pause) { return; }
        Fish();
        Hook();
        LifeCheck();
        Debug.Log(hookPosition);
    }

    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;

        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);

        ls.y = (distance / ySize * hookSize) / 4;
        hook.localScale = ls;
    }

    void Hook()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;
        

        hookPosition += hookPullVelocity;
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
        
        if(hookPosition <= hookSize / 2 || hookPosition >= 1 - hookSize / 2)
        {
            hookPullVelocity = 0;
        }

    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fishMarker.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);

    }

    void LifeCheck()
    {
        Vector3 ls = lifeBarContainer.localScale;

        ls.y = hookProgress;
        lifeBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if(min < fishPosition && max > fishPosition)
        {
            //code to reel the fish in
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {

            hookProgress -= hookDegredationPower * Time.deltaTime;
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);

        if(hookProgress <= 0f)
        {
            // code for losing and fish escapes
        }

        
    }

}
