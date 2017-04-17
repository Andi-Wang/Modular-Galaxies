using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public const int NUM_PER_FRAME = 5;

    private static string[] names = new string[] {
        "", "", "", "", "", //Frame 1: Sparrow
        "", "", "", "", "", //Frame 2: Lark
        "", "", "", "", "", //Frame 3: Shrike
        "", "", "", "", "", //Frame 4: Pigeon
        "", "", "", "", "", //Frame 5: Astrapia
        "", "", "", "", "", //Frame 6: Magpie

        "", "", "", "", "", //Frame 7: Nightjar
        "", "", "", "", "", //Frame 8: Falcon
        "", "", "", "", "", //Frame 9: Kite
        "", "", "", "", "", //Frame 10: Gull
        "", "", "", "", "", //Frame 11: Osprey
        "", "", "", "", "", //Frame 12: Eagle

        "", "", "", "", "", //Frame 13: Peafowl
        "", "", "", "", "", //Frame 14: Crane
        "", "", "", "", "", //Frame 15: Pelican
        "", "", "", "", "", //Frame 16: Vulture
        "", "", "", "", "", //Frame 17: Albatross
        "", "", "", "", ""  //Frame 18: Condor
    };

    private static int[] complexities = new int[] {
        0, 0, 0, 0, 0, //Frame 1: Sparrow
        0, 0, 0, 0, 0, //Frame 2: Lark
        0, 0, 0, 0, 0, //Frame 3: Shrike
        0, 0, 0, 0, 0, //Frame 4: Pigeon
        0, 0, 0, 0, 0, //Frame 5: Astrapia
        0, 0, 0, 0, 0, //Frame 6: Magpie

        0, 0, 0, 0, 0, //Frame 7: Nightjar
        0, 0, 0, 0, 0, //Frame 8: Falcon
        0, 0, 0, 0, 0, //Frame 9: Kite
        0, 0, 0, 0, 0, //Frame 10: Gull
        0, 0, 0, 0, 0, //Frame 11: Osprey
        0, 0, 0, 0, 0, //Frame 12: Eagle

        0, 0, 0, 0, 0, //Frame 13: Peafowl
        0, 0, 0, 0, 0, //Frame 14: Crane
        0, 0, 0, 0, 0, //Frame 15: Pelican
        0, 0, 0, 0, 0, //Frame 16: Vulture
        0, 0, 0, 0, 0, //Frame 17: Albatross
        0, 0, 0, 0, 0  //Frame 18: Condor
    };

    private static int[] weights = new int[] {
        0, 0, 0, 0, 0, //Frame 1: Sparrow
        0, 0, 0, 0, 0, //Frame 2: Lark
        0, 0, 0, 0, 0, //Frame 3: Shrike
        0, 0, 0, 0, 0, //Frame 4: Pigeon
        0, 0, 0, 0, 0, //Frame 5: Astrapia
        0, 0, 0, 0, 0, //Frame 6: Magpie

        0, 0, 0, 0, 0, //Frame 7: Nightjar
        0, 0, 0, 0, 0, //Frame 8: Falcon
        0, 0, 0, 0, 0, //Frame 9: Kite
        0, 0, 0, 0, 0, //Frame 10: Gull
        0, 0, 0, 0, 0, //Frame 11: Osprey
        0, 0, 0, 0, 0, //Frame 12: Eagle

        0, 0, 0, 0, 0, //Frame 13: Peafowl
        0, 0, 0, 0, 0, //Frame 14: Crane
        0, 0, 0, 0, 0, //Frame 15: Pelican
        0, 0, 0, 0, 0, //Frame 16: Vulture
        0, 0, 0, 0, 0, //Frame 17: Albatross
        0, 0, 0, 0, 0  //Frame 18: Condor
    };

    private static float[] drains = new float[] {
        14.5f, 13.5f, 13.0f, 12.5f, 12.5f, //Frame 1: Sparrow
        0, 0, 0, 0, 0, //Frame 2: Lark
        0, 0, 0, 0, 0, //Frame 3: Shrike
        0, 0, 0, 0, 0, //Frame 4: Pigeon
        0, 0, 0, 0, 0, //Frame 5: Astrapia
        0, 0, 0, 0, 0, //Frame 6: Magpie

        0, 0, 0, 0, 0, //Frame 7: Nightjar
        0, 0, 0, 0, 0, //Frame 8: Falcon
        0, 0, 0, 0, 0, //Frame 9: Kite
        0, 0, 0, 0, 0, //Frame 10: Gull
        0, 0, 0, 0, 0, //Frame 11: Osprey
        0, 0, 0, 0, 0, //Frame 12: Eagle

        0, 0, 0, 0, 0, //Frame 13: Peafowl
        0, 0, 0, 0, 0, //Frame 14: Crane
        0, 0, 0, 0, 0, //Frame 15: Pelican
        0, 0, 0, 0, 0, //Frame 16: Vulture
        0, 0, 0, 0, 0, //Frame 17: Albatross
        0, 0, 0, 0, 0  //Frame 18: Condor
    };

    private static float[] cooldowns = new float[] {
        0.350f, 0.325f, 0.300f, 0.275f, 0.250f, //Frame 1: Sparrow
        0, 0, 0, 0, 0, //Frame 2: Lark
        0, 0, 0, 0, 0, //Frame 3: Shrike
        0, 0, 0, 0, 0, //Frame 4: Pigeon
        0, 0, 0, 0, 0, //Frame 5: Astrapia
        0, 0, 0, 0, 0, //Frame 6: Magpie

        0, 0, 0, 0, 0, //Frame 7: Nightjar
        0, 0, 0, 0, 0, //Frame 8: Falcon
        0, 0, 0, 0, 0, //Frame 9: Kite
        0, 0, 0, 0, 0, //Frame 10: Gull
        0, 0, 0, 0, 0, //Frame 11: Osprey
        0, 0, 0, 0, 0, //Frame 12: Eagle

        0, 0, 0, 0, 0, //Frame 13: Peafowl
        0, 0, 0, 0, 0, //Frame 14: Crane
        0, 0, 0, 0, 0, //Frame 15: Pelican
        0, 0, 0, 0, 0, //Frame 16: Vulture
        0, 0, 0, 0, 0, //Frame 17: Albatross
        0, 0, 0, 0, 0  //Frame 18: Condor
    };

    private static float[] damages = new float[] {
        20.0f, 20.0f, 20.0f, 20.0f, 20.0f, //Frame 1: Sparrow
        0, 0, 0, 0, 0, //Frame 2: Lark
        0, 0, 0, 0, 0, //Frame 3: Shrike
        0, 0, 0, 0, 0, //Frame 4: Pigeon
        0, 0, 0, 0, 0, //Frame 5: Astrapia
        0, 0, 0, 0, 0, //Frame 6: Magpie

        0, 0, 0, 0, 0, //Frame 7: Nightjar
        0, 0, 0, 0, 0, //Frame 8: Falcon
        0, 0, 0, 0, 0, //Frame 9: Kite
        0, 0, 0, 0, 0, //Frame 10: Gull
        0, 0, 0, 0, 0, //Frame 11: Osprey
        0, 0, 0, 0, 0, //Frame 12: Eagle

        0, 0, 0, 0, 0, //Frame 13: Peafowl
        0, 0, 0, 0, 0, //Frame 14: Crane
        0, 0, 0, 0, 0, //Frame 15: Pelican
        0, 0, 0, 0, 0, //Frame 16: Vulture
        0, 0, 0, 0, 0, //Frame 17: Albatross
        0, 0, 0, 0, 0  //Frame 18: Condor
    };


    public static string name(int tier) {
        if (tier > 0 && tier <= names.Length) {
            return names[tier - 1];
        }
        else return "None";
    }
    public static int complexity(int tier) {
        if (tier > 0 && tier <= complexities.Length) {
            return complexities[tier - 1];
        }
        else return 0;
    }
    public static int weight(int tier) {
        if (tier > 0 && tier <= weights.Length) {
            return weights[tier - 1];
        }
        else return 0;
    }
    public static float drain(int tier) {
        if (tier > 0 && tier <= drains.Length) {
            return drains[tier - 1];
        }
        else return 0;
    }
    public static float cooldown(int tier) {
        if (tier > 0 && tier <= cooldowns.Length) {
            return cooldowns[tier - 1];
        }
        else return 0;
    }
    public static float damage(int tier) {
        if (tier > 0 && tier <= damages.Length) {
            return damages[tier - 1];
        }
        else return 0;
    }
}
