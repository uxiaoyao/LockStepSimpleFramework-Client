//
// @brief: 战斗对象挂载脚本
// @version: 1.0.0
// @author helin
// @date: 03/7/2018
// 
// 
//

using UnityEngine;
using System.Collections;
using Lean.Touch;

public class BattleLogicMonoBehaviour : MonoBehaviour {

    BattleLogic battleLogic = new BattleLogic();

    // Use this for initialization
    void Start () {
#if _CLIENTLOGIC_
        battleLogic.init();
#else
        GameData.g_uGameLogicFrame = 0;
        GameData.g_bRplayMode = true;
        battleLogic.init();
        battleLogic.updateLogic();
#endif
    }
	
	// Update is called once per frame
	void Update () {
#if _CLIENTLOGIC_
        battleLogic.updateLogic();

#endif
    }

    public LeanScreenDepth ScreenDepth;

    public void ClickOnGround(LeanFinger finger)
    {
        var worldPoint = ScreenDepth.Convert(finger.ScreenPosition, gameObject);
        battleLogic.clickOnGround((Fix64)worldPoint.x, (Fix64)worldPoint.z);
        Debug.Log(string.Format("Cick On Ground {0}, {1}", worldPoint.x, worldPoint.z));

    }

    public BattleLogic getBattleLogic()
    {
        return battleLogic;
    }

}
