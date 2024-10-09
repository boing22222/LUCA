using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfroMenu :UIBase
{
    public static InfroMenu GetInstance;
    private void Awake()
    {
        GetInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        OnExit();
    }
    public override void OnEnter()
    {
        state = UIState.Enter;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        state = UIState.Exit;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
