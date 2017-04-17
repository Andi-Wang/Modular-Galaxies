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

        switch (model(tier)) {
            case 1: { value = "Sparrow"; } break;
            case 2: { value = "Lark"; } break;
            case 3: { value = "Shrike"; } break;
            case 4: { value = "Pigeon"; } break;
            case 5: { value = "Astrapia"; } break;
            case 6: { value = "Magpie"; } break;

            case 7: { value = "Nightjar"; } break;
            case 8: { value = "Falcon"; } break;
            case 9: { value = "Kite"; } break;
            case 10: { value = "Gull"; } break;
            case 11: { value = "Osprey"; } break;
            case 12: { value = "Eagle"; } break;

            case 13: { value = "Peafowl"; } break;
            case 14: { value = "Crane"; } break;
            case 15: { value = "Pelican"; } break;
            case 16: { value = "Vulture"; } break;
            case 17: { value = "Albatross"; } break;
            case 18: { value = "Condor"; } break;
        }

        if(!value.Equals("None")) {
            value += " Mk" + mark(tier);
        }

        return value;
    }

    public static int size(int tier) {
        int value = -1;

        switch(model(tier)) {
            case 1: { value = SMALL; } break;
            case 2: { value = SMALL; } break;
            case 3: { value = SMALL; } break;
            case 4: { value = SMALL; } break;
            case 5: { value = SMALL; } break;
            case 6: { value = SMALL; } break;

            case 7: { value = MEDIUM; } break;
            case 8: { value = MEDIUM; } break;
            case 9: { value = MEDIUM; } break;
            case 10: { value = MEDIUM; } break;
            case 11: { value = MEDIUM; } break;
            case 12: { value = MEDIUM; } break;

            case 13: { value = LARGE; } break;
            case 14: { value = LARGE; } break;
            case 15: { value = LARGE; } break;
            case 16: { value = LARGE; } break;
            case 17: { value = LARGE; } break;
            case 18: { value = LARGE; } break;
        }

        return value;
    }

    public static string sizeName(int size) {
        string value = "None";

        switch(size) {
            case SMALL: { value = "Small"; } break;
            case MEDIUM: { value = "Medium"; } break;
            case LARGE: { value = "Large"; } break;
        }

        return value;
    }

    public static int weight(int tier) {
        int value = 0;

        switch (model(tier)) {
            case 1: { value = 0; } break;
            case 2: { value = 0; } break;
            case 3: { value = 0; } break;
            case 4: { value = 0; } break;
            case 5: { value = 0; } break;
            case 6: { value = 0; } break;

            case 7: { value = 0; } break;
            case 8: { value = 0; } break;
            case 9: { value = 0; } break;
            case 10: { value = 0; } break;
            case 11: { value = 0; } break;
            case 12: { value = 0; } break;

            case 13: { value = 0; } break;
            case 14: { value = 0; } break;
            case 15: { value = 0; } break;
            case 16: { value = 0; } break;
            case 17: { value = 0; } break;
            case 18: { value = 0; } break;
        }
        if(tier > 0) {
            value += baseWeight(size(tier), mark(tier));
        }

        return value;
    }
    private static int baseWeight(int size, int mark) {
        int value = 0;

        switch (size) {
            case SMALL: { value = 21 + mark * 6; } break;
            case MEDIUM: { value = 46 + mark * 6; } break;
            case LARGE: { value = 74 + mark * 6; } break;
        }

        return value;
    }

    public static int space(int tier) {
        int value = 0;

        switch ((tier + MAX_MK - 1) / MAX_MK) {
            case 1: { value = 0; } break;
            case 2: { value = 0; } break;
            case 3: { value = 0; } break;
            case 4: { value = 0; } break;
            case 5: { value = 0; } break;
            case 6: { value = 0; } break;

            case 7: { value = 0; } break;
            case 8: { value = 0; } break;
            case 9: { value = 0; } break;
            case 10: { value = 0; } break;
            case 11: { value = 0; } break;
            case 12: { value = 0; } break;

            case 13: { value = 0; } break;
            case 14: { value = 0; } break;
            case 15: { value = 0; } break;
            case 16: { value = 0; } break;
            case 17: { value = 0; } break;
            case 18: { value = 0; } break;
        }
        if (tier > 0) {
            value += spaceFunction(size(tier), mark(tier));
        }

        return value;
    }
    private static int spaceFunction(int size, int mark) {
        int value = 0;

        switch (size) {
            case SMALL: { value = 2 + mark; } break;
            case MEDIUM: { value = 6 + mark * 2; } break;
            case LARGE: { value = 14 + mark * 3; } break;
        }

        return value;
    }

    public static float health(int tier) {
        float value = 0f;

        switch ((tier + MAX_MK - 1) / MAX_MK) {
            case 1: { value = 0; } break;
            case 2: { value = 0; } break;
            case 3: { value = 0; } break;
            case 4: { value = 0; } break;
            case 5: { value = 0; } break;
            case 6: { value = 0; } break;

            case 7: { value = 0; } break;
            case 8: { value = 0; } break;
            case 9: { value = 0; } break;
            case 10: { value = 0; } break;
            case 11: { value = 0; } break;
            case 12: { value = 0; } break;

            case 13: { value = 0; } break;
            case 14: { value = 0; } break;
            case 15: { value = 0; } break;
            case 16: { value = 0; } break;
            case 17: { value = 0; } break;
            case 18: { value = 0; } break;
        }
        if (tier > 0) {
            value += healthFunction(size(tier), mark(tier));
        }

        return value;
    }
    private static int healthFunction(int size, int mark) {
        int value = 0;

        switch (size) {
            case SMALL: { value = 80 + mark * 20; } break;
            case MEDIUM: { value = 120 + mark * 30; } break;
            case LARGE: { value = 160 + mark * 40; } break;
        }

        return value;
    }
    
    public static int model(int tier) {
        return (tier + MAX_MK - 1) / MAX_MK;
    }
    private static int mark(int tier) {
        int value = 0;
        if (tier > 0) {
            if (tier % MAX_MK == 0) {
                value = MAX_MK;
            }
            else { value = tier % MAX_MK; }
        }

        return value;
    }
}
