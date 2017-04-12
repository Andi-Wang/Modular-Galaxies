using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {
    public const int WIND = 0, 
                     FIRE = 1;
    public const float SMALL_SPEED_MOD = 1.1f,
                       MEDIUM_SPEED_MOD = 0.575f,
                       LARGE_SPEED_MOD = 0.375f;

    public static string name(int tier) {
        string value = "None";

        switch (tier) {
            case 1: { value = "Spark Engine"; } break;
            case 2: { value = "Wind Core"; } break;
            case 3: { value = "Ignis Engine"; } break;
            case 4: { value = "Gale Core"; } break;
            case 5: { value = "Flame Engine"; } break;
            case 6: { value = "Mistral Core"; } break;
            case 7: { value = "Blaze Engine"; } break;
            case 8: { value = "Tempest Core"; } break;
            case 9: { value = "Wildfire Engine"; } break;
            case 10: { value = "Tornado Core"; } break;
            case 11: { value = "Inferno Engine"; } break;
            case 12: { value = "Hurricane Core"; } break;
        }

        return value;
    }


    public static int type(int tier) {
        int value = -1;

        switch (tier) {
            case 1: { value = FIRE; } break;
            case 2: { value = WIND; } break;
            case 3: { value = FIRE; } break;
            case 4: { value = WIND; } break;
            case 5: { value = FIRE; } break;
            case 6: { value = WIND; } break;
            case 7: { value = FIRE; } break;
            case 8: { value = WIND; } break;
            case 9: { value = FIRE; } break;
            case 10: { value = WIND; } break;
            case 11: { value = FIRE; } break;
            case 12: { value = WIND; } break;
        }

        return value;
    }

    public static string typeName(int type) {
        string value = "None";

        switch(type) {
            case WIND: { value = "Wind"; } break;
            case FIRE: { value = "Fire"; } break;
        }

        return value;
    }


    public static float space(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 2; } break;
            case 2: { value = 3; } break;
            case 3: { value = 4; } break;
            case 4: { value = 5; } break;
            case 5: { value = 6; } break;
            case 6: { value = 8; } break;
            case 7: { value = 10; } break;
            case 8: { value = 12; } break;
            case 9: { value = 14; } break;
            case 10: { value = 17; } break;
            case 11: { value = 20; } break;
            case 12: { value = 23; } break;
        }

        return value;
    }

    public static float weight(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 7; } break;
            case 2: { value = 8; } break;
            case 3: { value = 9; } break;
            case 4: { value = 10; } break;
            case 5: { value = 11; } break;
            case 6: { value = 12; } break;
            case 7: { value = 13; } break;
            case 8: { value = 14; } break;
            case 9: { value = 15; } break;
            case 10: { value = 16; } break;
            case 11: { value = 17; } break;
            case 12: { value = 18; } break;
        }

        return value;
    }

    public static float thrust(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 100; } break;
            case 2: { value = 130; } break;
            case 3: { value = 160; } break;
            case 4: { value = 190; } break;
            case 5: { value = 220; } break;
            case 6: { value = 250; } break;
            case 7: { value = 280; } break;
            case 8: { value = 310; } break;
            case 9: { value = 340; } break;
            case 10: { value = 370; } break;
            case 11: { value = 400; } break;
            case 12: { value = 430; } break;
        }

        return value;
    }

    public static float speed(int tier, int shipWeight, int shipSize) {
        float baseSpeed = thrust(1) / Mathf.Log(Frame.MIN_WEIGHT) * SMALL_SPEED_MOD;
        float value = thrust(tier) / Mathf.Log(shipWeight) / baseSpeed;

        if (shipSize == Frame.SMALL) {
            value *= SMALL_SPEED_MOD;
        }
        else if(shipSize == Frame.MEDIUM) {
            value *= MEDIUM_SPEED_MOD;
        }
        else if(shipSize == Frame.LARGE) {
            value *= MEDIUM_SPEED_MOD;
        }

        return value;
    }

    /*
    public static float drain(int tier) {
        float value = 0;

        switch (tier) {
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
        }

        return value;
    }

    public static float complexity(int tier) {
        float value = 0;

        switch (tier) {
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
        }

        return value;
    }
    */
}
