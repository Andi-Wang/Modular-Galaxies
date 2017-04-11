using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
    public const int SMALL = 0, 
                     MEDIUM = 1, 
                     LARGE = 2;

    public static string name(int size, int tier) {
        string value = "";

        if(size == SMALL) {
            switch(tier) {
                case 0: { value = "None";  } break;
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
            }
        }
        else if(size == MEDIUM) {
            switch (tier) {
                case 0: { value = "None"; } break;
                case 1: { value = "Steel Shell"; } break;
                case 2: { value = "Titanium Shell"; } break;
                case 3: { value = "H-Titanium Shell"; } break;
                case 4: { value = "Composite Shell"; } break;
                case 5: { value = "H-Composite Shell"; } break;
                case 6: { value = "Ablative Shell"; } break;
                case 7: { value = "H-Ablative Shell"; } break;
                case 8: { value = "Reactive Shell"; } break;
                case 9: { value = "H-Reactive Shell"; } break;
                case 10: { value = "Enigma Shell Mk1"; } break;
                case 11: { value = "Enigma Shell Mk2"; } break;
            }
        }
        else if (size == LARGE) {
            switch (tier) {
                case 0: { value = "None"; } break;
                case 1: { value = "Steel Plating"; } break;
                case 2: { value = "Titanium Plating"; } break;
                case 3: { value = "H-Titanium Plating"; } break;
                case 4: { value = "Composite Plating"; } break;
                case 5: { value = "H-Composite Plating"; } break;
                case 6: { value = "Ablative Plating"; } break;
                case 7: { value = "H-Ablative Plating"; } break;
                case 8: { value = "Reactive Plating"; } break;
                case 9: { value = "H-Reactive Plating"; } break;
                case 10: { value = "Enigma Plating Mk1"; } break;
                case 11: { value = "Enigma Plating Mk2"; } break;
            }
        }
        
        return value;
    }


    public static float space(int size, int tier) {
        float value = 0;

        if (size == SMALL) {
            switch (tier) {
                case 0: { value = 0; } break;
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
            }
        }
        else if (size == MEDIUM) {
            switch (tier) {
                case 0: { value = 0; } break;
                case 1: { value = 2; } break;
                case 2: { value = 4; } break;
                case 3: { value = 4; } break;
                case 4: { value = 6; } break;
                case 5: { value = 6; } break;
                case 6: { value = 8; } break;
                case 7: { value = 8; } break;
                case 8: { value = 10; } break;
                case 9: { value = 10; } break;
                case 10: { value = 6; } break;
                case 11: { value = 12; } break;
            }
        }
        else if (size == LARGE) {
            switch (tier) {
                case 0: { value = 0; } break;
                case 1: { value = 3; } break;
                case 2: { value = 6; } break;
                case 3: { value = 6; } break;
                case 4: { value = 9; } break;
                case 5: { value = 9; } break;
                case 6: { value = 12; } break;
                case 7: { value = 12; } break;
                case 8: { value = 15; } break;
                case 9: { value = 15; } break;
                case 10: { value = 15; } break;
                case 11: { value = 21; } break;
            }
        }

        return value;
    }

    public static float weight(int size, int tier) {
        float value = 0;

        if (size == SMALL) {
            switch (tier) {
                case 0: { value = 0; } break;
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
            }
        }
        else if (size == MEDIUM) {
            switch (tier) {
                case 0: { value = 0; } break;
                case 1: { value = 5; } break;
                case 2: { value = 6; } break;
                case 3: { value = 7; } break;
                case 4: { value = 8; } break;
                case 5: { value = 9; } break;
                case 6: { value = 10; } break;
                case 7: { value = 11; } break;
                case 8: { value = 12; } break;
                case 9: { value = 13; } break;
                case 10: { value = 10; } break;
                case 11: { value = 17; } break;
            }
        }
        else if (size == LARGE) {
            switch (tier) {
                case 0: { value = 0; } break;
                case 1: { value = 9; } break;
                case 2: { value = 10; } break;
                case 3: { value = 11; } break;
                case 4: { value = 12; } break;
                case 5: { value = 13; } break;
                case 6: { value = 14; } break;
                case 7: { value = 15; } break;
                case 8: { value = 16; } break;
                case 9: { value = 17; } break;
                case 10: { value = 14; } break;
                case 11: { value = 21; } break;
            }
        }
        return value;
    }

    public static float health(int size, int tier) {
        float value = 0;

        if (size == SMALL) {
            switch (tier) {
                case 0: { value = 0; } break;
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
            }
        }
        else if (size == MEDIUM) {
            switch (tier) {
                case 0: { value = 0; } break;
                case 1: { value = 60; } break;
                case 2: { value = 86; } break;
                case 3: { value = 99; } break;
                case 4: { value = 131; } break;
                case 5: { value = 147; } break;
                case 6: { value = 186; } break;
                case 7: { value = 204; } break;
                case 8: { value = 250; } break;
                case 9: { value = 270; } break;
                case 10: { value = 188; } break;
                case 11: { value = 375; } break;
            }
        }
        else if (size == LARGE) {
            switch (tier) {
                case 0: { value = 0; } break;
                case 1: { value = 120; } break;
                case 2: { value = 156; } break;
                case 3: { value = 168; } break;
                case 4: { value = 210; } break;
                case 5: { value = 224; } break;
                case 6: { value = 272; } break;
                case 7: { value = 288; } break;
                case 8: { value = 342; } break;
                case 9: { value = 360; } break;
                case 10: { value = 320; } break;
                case 11: { value = 480; } break;
            }
        }

        return value;
    }
}
