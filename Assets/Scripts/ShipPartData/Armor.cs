using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
    public const int MODULES_PER_SIZE = 11;

    public static string name(int tier) {
        string value = "None";

        switch(tier) {
            case 1: { value = "Steel Sheath"; } break;
            case 2: { value = "Titanium Sheath"; } break;
            case 3: { value = "H-Titanium Sheath"; } break;
            case 4: { value = "Composite Sheath"; } break;
            case 5: { value = "H-Composite Sheath"; } break;
            case 6: { value = "Ablative Sheath"; } break;
            case 7: { value = "H-Ablative Sheath"; } break;
            case 8: { value = "Reactive Sheath"; } break;
            case 9: { value = "H-Reactive Sheath"; } break;
            case 10: { value = "Enigma Sheath Mk1"; } break;
            case 11: { value = "Enigma Sheath Mk2"; } break;

            case 12: { value = "Steel Shell"; } break;
            case 13: { value = "Titanium Shell"; } break;
            case 14: { value = "H-Titanium Shell"; } break;
            case 15: { value = "Composite Shell"; } break;
            case 16: { value = "H-Composite Shell"; } break;
            case 17: { value = "Ablative Shell"; } break;
            case 18: { value = "H-Ablative Shell"; } break;
            case 19: { value = "Reactive Shell"; } break;
            case 20: { value = "H-Reactive Shell"; } break;
            case 21: { value = "Enigma Shell Mk1"; } break;
            case 22: { value = "Enigma Shell Mk2"; } break;

            case 23: { value = "Steel Plating"; } break;
            case 24: { value = "Titanium Plating"; } break;
            case 25: { value = "H-Titanium Plating"; } break;
            case 26: { value = "Composite Plating"; } break;
            case 27: { value = "H-Composite Plating"; } break;
            case 28: { value = "Ablative Plating"; } break;
            case 29: { value = "H-Ablative Plating"; } break;
            case 30: { value = "Reactive Plating"; } break;
            case 31: { value = "H-Reactive Plating"; } break;
            case 32: { value = "Enigma Plating Mk1"; } break;
            case 33: { value = "Enigma Plating Mk2"; } break;
        }
        
        return value;
    }


    public static float space(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 1; } break;
            case 2: { value = 2; } break;
            case 3: { value = 2; } break;
            case 4: { value = 3; } break;
            case 5: { value = 3; } break;
            case 6: { value = 4; } break;
            case 7: { value = 4; } break;
            case 8: { value = 5; } break;
            case 9: { value = 5; } break;
            case 10: { value = 2; } break;
            case 11: { value = 3; } break;

            case 12: { value = 2; } break;
            case 13: { value = 4; } break;
            case 14: { value = 4; } break;
            case 15: { value = 6; } break;
            case 16: { value = 6; } break;
            case 17: { value = 8; } break;
            case 18: { value = 8; } break;
            case 19: { value = 10; } break;
            case 20: { value = 10; } break;
            case 21: { value = 6; } break;
            case 22: { value = 12; } break;

            case 23: { value = 3; } break;
            case 24: { value = 6; } break;
            case 25: { value = 6; } break;
            case 26: { value = 9; } break;
            case 27: { value = 9; } break;
            case 28: { value = 12; } break;
            case 29: { value = 12; } break;
            case 30: { value = 15; } break;
            case 31: { value = 15; } break;
            case 32: { value = 15; } break;
            case 33: { value = 21; } break;
        }

        return value;
    }

    public static float weight(int tier) {
        float value = 0;
        
        switch (tier) {
            case 1: { value = 1; } break;
            case 2: { value = 2; } break;
            case 3: { value = 3; } break;
            case 4: { value = 4; } break;
            case 5: { value = 5; } break;
            case 6: { value = 6; } break;
            case 7: { value = 7; } break;
            case 8: { value = 8; } break;
            case 9: { value = 9; } break;
            case 10: { value = 4; } break;
            case 11: { value = 7; } break;

            case 12: { value = 5; } break;
            case 13: { value = 6; } break;
            case 14: { value = 7; } break;
            case 15: { value = 8; } break;
            case 16: { value = 9; } break;
            case 17: { value = 10; } break;
            case 18: { value = 11; } break;
            case 19: { value = 12; } break;
            case 20: { value = 13; } break;
            case 21: { value = 10; } break;
            case 22: { value = 17; } break;

            case 23: { value = 9; } break;
            case 24: { value = 10; } break;
            case 25: { value = 11; } break;
            case 26: { value = 12; } break;
            case 27: { value = 13; } break;
            case 28: { value = 14; } break;
            case 29: { value = 15; } break;
            case 30: { value = 16; } break;
            case 31: { value = 17; } break;
            case 32: { value = 14; } break;
            case 33: { value = 21; } break;
        }

        return value;
    }

    public static float health(int tier) {
        float value = 0;

        switch (tier) {
            case 1: { value = 20; } break;
            case 2: { value = 36; } break;
            case 3: { value = 48; } break;
            case 4: { value = 70; } break;
            case 5: { value = 84; } break;
            case 6: { value = 112; } break;
            case 7: { value = 128; } break;
            case 8: { value = 162; } break;
            case 9: { value = 180; } break;
            case 10: { value = 80; } break;
            case 11: { value = 130; } break;

            case 12: { value = 60; } break;
            case 13: { value = 86; } break;
            case 14: { value = 99; } break;
            case 15: { value = 131; } break;
            case 16: { value = 147; } break;
            case 17: { value = 186; } break;
            case 18: { value = 204; } break;
            case 19: { value = 250; } break;
            case 20: { value = 270; } break;
            case 21: { value = 188; } break;
            case 22: { value = 375; } break;

            case 23: { value = 120; } break;
            case 24: { value = 156; } break;
            case 25: { value = 168; } break;
            case 26: { value = 210; } break;
            case 27: { value = 224; } break;
            case 28: { value = 272; } break;
            case 29: { value = 288; } break;
            case 30: { value = 342; } break;
            case 31: { value = 360; } break;
            case 32: { value = 320; } break;
            case 33: { value = 480; } break;
        }

        return value;
    }
}
