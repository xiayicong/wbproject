using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : ModelManage
{
    private Dictionary<string, PlayerData> mAllPlayerData = new Dictionary<string, PlayerData>();

    protected override void OnInit()
    {
        mAllPlayerData.Add("self", new PlayerData());
    }

    public PlayerData GetSelfData()
    {
        return mAllPlayerData["self"];
    }
}
