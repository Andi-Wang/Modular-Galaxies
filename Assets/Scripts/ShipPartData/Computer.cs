using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {
    public static string name(int tier) {
        string value = "None";

        switch (tier) {
            case 1: { value = "Orion Mark I"; } break;
            case 2: { value = "Orion Mark II"; } break;
            case 3: { value = "Orion Mark III"; } break;
            case 4: { value = "Orion Mark IV"; } break;

            case 5: { value = "Crux Widget"; } break;
            case 6: { value = "Crux Gadget"; } break;
            case 7: { value = "Crux Machine"; } break;
            case 8: { value = "Crux Apparatus"; } break;

            case 9: { value = "Polaric Supercomputer"; } break;
            case 10: { value = "Polaric Neural Cluster"; } break;
            case 11: { value = "Polaric Knowledge Array"; } break;
            case 12: { value = "Polaric Thought Matrix"; } break;
        }

        return value;
    }


    public static float weight(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 6; } break;
            case 2: { value = 10; } break;
            case 3: { value = 11; } break;
            case 4: { value = 14; } break;

            case 5: { value = 14; } break;
            case 6: { value = 16; } break;
            case 7: { value = 17; } break;
            case 8: { value = 22; } break;

            case 9: { value = 22; } break;
            case 10: { value = 28; } break;
            case 11: { value = 26; } break;
            case 12: { value = 30; } break;
        }

        return value;
    }
    
    public static float complexity(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 17; } break;
            case 2: { value = 23; } break;
            case 3: { value = 33; } break;
            case 4: { value = 42; } break;

            case 5: { value = 27; } break;
            case 6: { value = 32; } break;
            case 7: { value = 40; } break;
            case 8: { value = 52; } break;

            case 9: { value = 38; } break;
            case 10: { value = 59; } break;
            case 11: { value = 65; } break;
            case 12: { value = 72; } break;
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
    */
}
