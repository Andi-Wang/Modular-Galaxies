using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPattern : MonoBehaviour {
    protected float timeElapsed = 0;
    protected float totalDuration;
    protected Vector3 startPosition;
    protected float verticalStretch;
    protected Vector3 displacement;
    protected int type;
    protected float cycles;


    protected float screenWidth;
    protected float screenHeight;

    public const int LINEAR = 0,
                     SINE = 1,
                     COSINE = 2,
                     CUBIC = 3,
                     ROOT = 4;


    public MovementPattern(int functionType, Vector3 startPosition, float verticalStretch, Vector3 displacement, float duration, float cycles = 1) {
        type = functionType;
        totalDuration = duration;
        this.startPosition = startPosition;
        this.verticalStretch = verticalStretch;
        this.displacement = displacement;
    }

    public Vector3 pathFunction() {
        Vector3 nextPos = new Vector3();

        switch(type) {
            case LINEAR: { nextPos = linearPath(); } break;
            case SINE: { nextPos = sinePath(); } break;
            case COSINE: { } break;
            case CUBIC: { } break;
            case ROOT: { } break;
        }

        return nextPos;
    }

                     
    //Straight horizontal path from left to right
    public Vector3 linearPath() {
        return new Vector3(startPosition.x + screenWidth * timeElapsed / totalDuration, startPosition.y + screenHeight * timeElapsed / totalDuration * verticalStretch + displacement.y);
    }

    //Sine wave path from left to right
    public Vector3 sinePath() {
        return new Vector3(startPosition.x + screenWidth * timeElapsed / totalDuration, startPosition.y + Mathf.Sin(Mathf.PI * cycles * timeElapsed / totalDuration));
    }

    //Cosine wave path from left to right
    public Vector3 cosinePath(Vector3 startPos, float time, float duration, float cycles = 1) {
        return new Vector3(startPos.x + screenWidth * time / duration, startPos.y + Mathf.Cos(Mathf.PI * cycles * time / duration));
    }

    //Cubic path from left to right
    public Vector3 cubicPath(Vector3 startPos, float time, float duration) {
        return new Vector3(startPos.x + screenWidth * time / duration, startPos.y + Mathf.Pow(time / duration, 3));
    }
}
