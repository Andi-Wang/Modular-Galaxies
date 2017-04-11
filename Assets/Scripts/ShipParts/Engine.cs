using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public static string name(int tier) {
        string value = "";

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
