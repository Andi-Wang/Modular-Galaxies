using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {
    public const int BATTERY = 0, 
                     NUCLEAR = 1, 
                     SOLAR = 2;


    public static string name (int tier) {
        string value = "";

        switch (tier) {
            case 1: { value = "Lithium-Ion Cell"; } break;
            case 2: { value = "Sodium-Sulfur Cell"; } break;
            case 3: { value = "Lithium-Sulfur Cell"; } break;
            case 4: { value = "Silver-Zinc Cell"; } break;
            case 5: { value = "Quantum Cell"; } break;
            case 6: { value = "Uranium Reactor"; } break;
            case 7: { value = "Plutonium Reactor"; } break;
            case 8: { value = "Deuterium Reactor"; } break;
            case 9: { value = "Tritium Reactor"; } break;
            case 10: { value = "Photovoltaic Array"; } break;
            case 11: { value = "Solar-Thermal Array"; } break;
            case 12: { value = "Gamma Array"; } break;
        }

        return value;
    }

    public static int type(int tier) {
        int value = 0;

        switch (tier) {
            case 1: { value = BATTERY; } break;
            case 2: { value = BATTERY; } break;
            case 3: { value = BATTERY; } break;
            case 4: { value = BATTERY; } break;
            case 5: { value = BATTERY; } break;
            case 6: { value = NUCLEAR; } break;
            case 7: { value = NUCLEAR; } break;
            case 8: { value = NUCLEAR; } break;
            case 9: { value = NUCLEAR; } break;
            case 10: { value = SOLAR; } break;
            case 11: { value = SOLAR; } break;
            case 12: { value = SOLAR; } break;
        }

        return value;
    }

    public static float weight(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 6; } break;
            case 2: { value = 10; } break;
            case 3: { value = 14; } break;
            case 4: { value = 18; } break;
            case 5: { value = 14; } break;
            case 6: { value = 6; } break;
            case 7: { value = 10; } break;
            case 8: { value = 14; } break;
            case 9: { value = 18; } break;
            case 10: { value = 10; } break;
            case 11: { value = 14; } break;
            case 12: { value = 18; } break;
        }

        return value;
    }

    public static float capacity(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 6000; } break;
            case 2: { value = 8000; } break;
            case 3: { value = 10000; } break;
            case 4: { value = 12000; } break;
            case 5: { value = 8000; } break;
            case 6: { value = 15000; } break;
            case 7: { value = 20000; } break;
            case 8: { value = 25000; } break;
            case 9: { value = 30000; } break;
            case 10: { value = 450; } break;
            case 11: { value = 435; } break;
            case 12: { value = 380; } break;
        }

        return value;
    }
    public static float regen(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 600; } break;
            case 2: { value = 800; } break;
            case 3: { value = 1000; } break;
            case 4: { value = 1200; } break;
            case 5: { value = 3000; } break;
            case 6: { value = 0; } break;
            case 7: { value = 0; } break;
            case 8: { value = 0; } break;
            case 9: { value = 0; } break;
            case 10: { value = 30; } break;
            case 11: { value = 45; } break;
            case 12: { value = 70; } break;
        }

        return value;
    }


    /*
    public static float space(int tier) {
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
    }*/
}
