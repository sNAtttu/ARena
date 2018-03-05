using System.Collections;
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
        public static readonly string EventJumpUp = "JumpUp";
        public static readonly string EventJumpDown = "JumpDown";
        public static readonly string EventLand = "Land";

        public static readonly string StateWalking = "Walking";
        public static readonly string StateRunning = "Running";
        public static readonly string StateJumpingUp = "JumpingUp";
        public static readonly string StateJumpingDown = "JumpingDown"; 
    }

    public static class EnemyConstants
    {
        public static readonly string TagEnemyHead = "EnemyHead";
        public static readonly string TagEnemyBody = "EnemyBody";
        public static readonly string TagEnemyLeftArm = "EnemyLeftArm";
        public static readonly string TagEnemyRightArm = "EnemyRightArm";

        public static readonly string EventSelectHead = "SelectHead";
        public static readonly string EventSelectBody = "SelectBody";
        public static readonly string EventSelectLeftArm = "SelectLeftArm";
        public static readonly string EventSelectRightArm = "SelectRightArm";

        public static readonly string StateIdle = "Idle";
        public static readonly string StateHeadSelected = "HeadSelected";
        public static readonly string StateBodySelected = "BodySelected";
        public static readonly string StateRightArmSelected = "RightArmSelected";
        public static readonly string StateLeftArmSelected = "LeftArmSelected";
    }

}

