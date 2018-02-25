﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class PlayerConstants
    {
        public static readonly string TagPlayerHead = "PlayerHead";
        public static readonly string TagPlayerBody = "PlayerBody";
        public static readonly string TagPlayerLeftArm = "PlayerLeftArm";
        public static readonly string TagPlayerRightArm = "PlayerRightArm";

        public static readonly string EventTouchHead = "TouchHead";
        public static readonly string EventTouchBody = "TouchBody";
        public static readonly string EventTouchLeftArm = "TouchLeftArm";
        public static readonly string EventTouchRightArm = "TouchRightArm";
        public static readonly string EventWalk = "Walk";
        public static readonly string EventRun = "Run";
        public static readonly string EventStop = "Stop";

        public static readonly string StateWalking = "Walking";
        public static readonly string StateRunning = "Running";
    }
}

