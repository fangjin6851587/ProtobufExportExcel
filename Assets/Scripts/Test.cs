using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TntDeploy;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(LoadData());
	}

    IEnumerator LoadData()
    {
        float startLoadTime = Time.realtimeSinceStartup;
        ExcelDataManager.ReadOneDataConfig<GoodsInfoArray>("tnt_deploy_goods_info");
        Debug.Log("============load data time: " + (Time.realtimeSinceStartup - startLoadTime));
        yield break;
    }
}
