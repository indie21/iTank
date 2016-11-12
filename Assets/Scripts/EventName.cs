using System.IO;
using System;
using System.Collections.Generic;


public static class EventName
{
    static private Dictionary<int, string> map1 =
        new Dictionary<int, string> ();


    static private Dictionary<string, int> map2 =
        new Dictionary<string, int> ();


    public static void Install() {

        map1 [1] = "SyncTank";
        map2 ["SyncTank"] = 1;

        map1 [2] = "SyncShot";
        map2 ["SyncShot"] = 2;

        map1 [3] = "SyncDamage";
        map2 ["SyncDamage"] = 3;

        map1 [4] = "SyncDie";
        map2 ["SyncDie"] = 4;


    }

    public static string GetEventName(int cmd) {
        return map1 [cmd];
    }

    public static int GetEventCmd(string name) {
        return map2 [name];
    }
};
