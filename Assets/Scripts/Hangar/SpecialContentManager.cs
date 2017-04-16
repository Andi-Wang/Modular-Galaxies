using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialContentManager : ContentManager {
    private void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(1).GetComponentInChildren<Text>().text = Special.name(i);

            float power = Special.power(i), cooldown = Special.cooldown(i), drain = Special.drain(i);
            string powerString, cooldownString, drainString;
            
            if(power <= 1f) { powerString = Mathf.Round(power * 100) + "%"; } else { powerString = power.ToString(); }
            if(cooldown <= 1f) { cooldownString = Mathf.Round(cooldown * 100) + "%"; } else { cooldownString = cooldown.ToString(); }
            if(drain <= 1f) { drainString = Mathf.Round(drain * 100) + "%"; } else { drainString = drain.ToString(); }

            transform.GetChild(i).GetChild(2).GetComponentInChildren<Text>().text = powerString + " / " + cooldownString;
            transform.GetChild(i).GetChild(3).GetComponentInChildren<Text>().text = drainString;
            transform.GetChild(i).GetChild(4).GetComponentInChildren<Text>().text = Special.complexity(i).ToString();
            transform.GetChild(i).GetChild(5).GetComponentInChildren<Text>().text = Special.weight(i).ToString();
        }
    }

    protected override bool ownedCheck(int index) {
        return hangarScript.specialOwned[index];
    }

    protected override bool hideCondition(int index) {
        return (!ownedCheck(index) || (hangarScript.selectedFrame - 1) / Frame.MAX_MK + 1 != (index + Special.NUM_PER_FRAME - 1) / Special.NUM_PER_FRAME) && index > 0;
    }
}
