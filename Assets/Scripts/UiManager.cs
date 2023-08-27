using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] internal GameObject failScreen;

    private void Start()
    {
        GameManager.instance.onLevelFailedEvent += EnableFailScreen;
    }

    private void OnDestroy()
    {
        GameManager.instance.onLevelFailedEvent -= EnableFailScreen;
    }

    void EnableFailScreen()
    {
        StartCoroutine(DelayFail());
    }

    IEnumerator DelayFail()
    {
        yield return new WaitForSeconds(1);
        failScreen.SetActive(true);
    }

}
