//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Action_Single p_default_TriggerValue;
        
        private static SteamVR_Action_Boolean p_default_TriggerTouch;
        
        private static SteamVR_Action_Boolean p_default_PrimaryButton;
        
        private static SteamVR_Action_Boolean p_default_PrimaryTouch;
        
        private static SteamVR_Action_Boolean p_default_SecondaryButton;
        
        private static SteamVR_Action_Boolean p_default_SecondaryTouch;
        
        private static SteamVR_Action_Single p_default_GripValue;
        
        private static SteamVR_Action_Vector2 p_default_JoystickValue;
        
        private static SteamVR_Action_Boolean p_default_JoystickClick;
        
        private static SteamVR_Action_Boolean p_default_JoystickTouch;
        
        private static SteamVR_Action_Boolean p_default_GripTouch;
        
        private static SteamVR_Action_Boolean p_default_TriggerClick;
        
        private static SteamVR_Action_Boolean p_default_GripClick;
        
        private static SteamVR_Action_Pose p_default_Pose;
        
        private static SteamVR_Action_Vibration p_default_Haptic;
        
        public static SteamVR_Action_Single default_TriggerValue
        {
            get
            {
                return SteamVR_Actions.p_default_TriggerValue.GetCopy<SteamVR_Action_Single>();
            }
        }
        
        public static SteamVR_Action_Boolean default_TriggerTouch
        {
            get
            {
                return SteamVR_Actions.p_default_TriggerTouch.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_PrimaryButton
        {
            get
            {
                return SteamVR_Actions.p_default_PrimaryButton.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_PrimaryTouch
        {
            get
            {
                return SteamVR_Actions.p_default_PrimaryTouch.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_SecondaryButton
        {
            get
            {
                return SteamVR_Actions.p_default_SecondaryButton.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_SecondaryTouch
        {
            get
            {
                return SteamVR_Actions.p_default_SecondaryTouch.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Single default_GripValue
        {
            get
            {
                return SteamVR_Actions.p_default_GripValue.GetCopy<SteamVR_Action_Single>();
            }
        }
        
        public static SteamVR_Action_Vector2 default_JoystickValue
        {
            get
            {
                return SteamVR_Actions.p_default_JoystickValue.GetCopy<SteamVR_Action_Vector2>();
            }
        }
        
        public static SteamVR_Action_Boolean default_JoystickClick
        {
            get
            {
                return SteamVR_Actions.p_default_JoystickClick.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_JoystickTouch
        {
            get
            {
                return SteamVR_Actions.p_default_JoystickTouch.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_GripTouch
        {
            get
            {
                return SteamVR_Actions.p_default_GripTouch.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_TriggerClick
        {
            get
            {
                return SteamVR_Actions.p_default_TriggerClick.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_GripClick
        {
            get
            {
                return SteamVR_Actions.p_default_GripClick.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Pose default_Pose
        {
            get
            {
                return SteamVR_Actions.p_default_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }
        
        public static SteamVR_Action_Vibration default_Haptic
        {
            get
            {
                return SteamVR_Actions.p_default_Haptic.GetCopy<SteamVR_Action_Vibration>();
            }
        }
        
        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    SteamVR_Actions.default_TriggerValue,
                    SteamVR_Actions.default_TriggerTouch,
                    SteamVR_Actions.default_PrimaryButton,
                    SteamVR_Actions.default_PrimaryTouch,
                    SteamVR_Actions.default_SecondaryButton,
                    SteamVR_Actions.default_SecondaryTouch,
                    SteamVR_Actions.default_GripValue,
                    SteamVR_Actions.default_JoystickValue,
                    SteamVR_Actions.default_JoystickClick,
                    SteamVR_Actions.default_JoystickTouch,
                    SteamVR_Actions.default_GripTouch,
                    SteamVR_Actions.default_TriggerClick,
                    SteamVR_Actions.default_GripClick,
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_TriggerValue,
                    SteamVR_Actions.default_TriggerTouch,
                    SteamVR_Actions.default_PrimaryButton,
                    SteamVR_Actions.default_PrimaryTouch,
                    SteamVR_Actions.default_SecondaryButton,
                    SteamVR_Actions.default_SecondaryTouch,
                    SteamVR_Actions.default_GripValue,
                    SteamVR_Actions.default_JoystickValue,
                    SteamVR_Actions.default_JoystickClick,
                    SteamVR_Actions.default_JoystickTouch,
                    SteamVR_Actions.default_GripTouch,
                    SteamVR_Actions.default_TriggerClick,
                    SteamVR_Actions.default_GripClick,
                    SteamVR_Actions.default_Pose};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[] {
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[] {
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    SteamVR_Actions.default_Pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    SteamVR_Actions.default_TriggerTouch,
                    SteamVR_Actions.default_PrimaryButton,
                    SteamVR_Actions.default_PrimaryTouch,
                    SteamVR_Actions.default_SecondaryButton,
                    SteamVR_Actions.default_SecondaryTouch,
                    SteamVR_Actions.default_JoystickClick,
                    SteamVR_Actions.default_JoystickTouch,
                    SteamVR_Actions.default_GripTouch,
                    SteamVR_Actions.default_TriggerClick,
                    SteamVR_Actions.default_GripClick};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[] {
                    SteamVR_Actions.default_TriggerValue,
                    SteamVR_Actions.default_GripValue};
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[] {
                    SteamVR_Actions.default_JoystickValue};
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[0];
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_TriggerValue,
                    SteamVR_Actions.default_TriggerTouch,
                    SteamVR_Actions.default_PrimaryButton,
                    SteamVR_Actions.default_PrimaryTouch,
                    SteamVR_Actions.default_SecondaryButton,
                    SteamVR_Actions.default_SecondaryTouch,
                    SteamVR_Actions.default_GripValue,
                    SteamVR_Actions.default_JoystickValue,
                    SteamVR_Actions.default_JoystickClick,
                    SteamVR_Actions.default_JoystickTouch,
                    SteamVR_Actions.default_GripTouch,
                    SteamVR_Actions.default_TriggerClick,
                    SteamVR_Actions.default_GripClick};
        }
        
        private static void PreInitActions()
        {
            SteamVR_Actions.p_default_TriggerValue = ((SteamVR_Action_Single)(SteamVR_Action.Create<SteamVR_Action_Single>("/actions/default/in/TriggerValue")));
            SteamVR_Actions.p_default_TriggerTouch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/TriggerTouch")));
            SteamVR_Actions.p_default_PrimaryButton = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/PrimaryButton")));
            SteamVR_Actions.p_default_PrimaryTouch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/PrimaryTouch")));
            SteamVR_Actions.p_default_SecondaryButton = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/SecondaryButton")));
            SteamVR_Actions.p_default_SecondaryTouch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/SecondaryTouch")));
            SteamVR_Actions.p_default_GripValue = ((SteamVR_Action_Single)(SteamVR_Action.Create<SteamVR_Action_Single>("/actions/default/in/GripValue")));
            SteamVR_Actions.p_default_JoystickValue = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/default/in/JoystickValue")));
            SteamVR_Actions.p_default_JoystickClick = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/JoystickClick")));
            SteamVR_Actions.p_default_JoystickTouch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/JoystickTouch")));
            SteamVR_Actions.p_default_GripTouch = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/GripTouch")));
            SteamVR_Actions.p_default_TriggerClick = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/TriggerClick")));
            SteamVR_Actions.p_default_GripClick = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/GripClick")));
            SteamVR_Actions.p_default_Pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/default/in/Pose")));
            SteamVR_Actions.p_default_Haptic = ((SteamVR_Action_Vibration)(SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/default/out/Haptic")));
        }
    }
}
