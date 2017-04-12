using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {
    public const int SMALL = 0,
                     MEDIUM = 1,
                     LARGE = 2,
                     MAX_MK = 6,
                     MIN_WEIGHT = 27;

    public static string name(int tier) {
        string value = "None";

        return value;
    }

    public static int size(int tier) {
        int value = -1;

        return value;
    }

    public static int weight(int tier) {
        int value = 0;

        return value;
    }

    public static int space(int tier) {
        int value = 0;

        return value;
    }

    public static float health(int tier) {
        float value = 0f;

        return value;
    }
}
