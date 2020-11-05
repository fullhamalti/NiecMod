using Sims3.Gameplay.Abstracts;
using Sims3.SimIFace;
using Sims3.UI;
using System;

namespace NiecMod.Nra
{
    public static class NMoveThings // fast code ;)
    {
        public const float ANGLE_45 = (float)Math.PI / 4f;

        public const float ANGLE_90 = (float)Math.PI / 2f;

        public const float ANGLE_315 = -(float)Math.PI / 4f;

        public static string[] GetMenuPath()
        {
            return new string[] { "Move..." };
        }

        public static string[] GetTiltMenuPath()
        {
            return new string[] { "Tilt And Turn..." };
        }

        public static float AskUserInput(string title, string labelText)
        {
            Simulator.Sleep(0); // check yield
            var textNumber = StringInputDialog.Show(title, labelText, "", 256, StringInputDialog.Validation.Number);
            if (textNumber == null || textNumber.length == 0)
                return 0f;

            float result = 0f;
            float.TryParse(textNumber, out result);
            return result;
        }

        public static double AskUserInputD(string title, string labelText)
        {
            Simulator.Sleep(0); // check yield
            var textNumber = StringInputDialog.Show(title, labelText, "", 256, StringInputDialog.Validation.Number);
            if (textNumber == null || textNumber.length == 0)
                return 0.0;

            double result = 0.0;
            double.TryParse(textNumber, out result);
            return result;
        }

        public static void MoveUp(GameObject gameObject, float meters)
        {
            var p = gameObject.Position;
            gameObject.SetPosition(new Vector3(p.x, p.y + meters, p.z));
        }

        public static void MoveDown(GameObject gameObject, float meters)
        {
            var p = gameObject.Position;
            gameObject.SetPosition(new Vector3(p.x, p.y - meters, p.z));
        }

        public static void MoveForward(GameObject gameObject, float meters)
        {
            var p = gameObject.Position;
            var f = gameObject.ForwardVector;
            gameObject.SetPosition(new Vector3(p.x - f.x * meters, p.y, p.z - f.z * meters));
        }

        public static void MoveBackward(GameObject gameObject, float meters)
        {
            var p = gameObject.Position;
            var f = gameObject.ForwardVector;
            gameObject.SetPosition(new Vector3(p.x + f.x * meters, p.y, p.z + f.z * meters));
        }

        public static void TurnLeft(GameObject gameObject)
        {
            Vector3 forward = Quaternion.MakeFromEulerAngles(0f, ANGLE_315, 0f).ToMatrix().TransformVector(gameObject.ForwardVector);
            if (forward == Vector3.Empty)
                return;
            gameObject.SetForward(forward);
        }

        public static void TurnRight(GameObject gameObject)
        {
            Vector3 forward = Quaternion.MakeFromEulerAngles(0f, ANGLE_90, 0f).ToMatrix().TransformVector(gameObject.ForwardVector);
            if (forward == Vector3.Empty)
                return;
            gameObject.SetForward(forward);
        }

        public static void TurnAround(GameObject gameObject)
        {
            var f = gameObject.ForwardVector;
            Vector3 forward = new Vector3(0f - f.x, f.y, 0f - f.z);
            if (forward == Vector3.Empty)
                return;
            gameObject.SetForward(forward);
        }

        public static void Turn(GameObject gameObject, float angle)
        {
            gameObject.SetRotation(angle * (float)(Math.PI / 180.0));
        }

        public static void Tilt(GameObject gameObject, float x, float y, float z)
        {
            Vector3 forward = new Vector3(x, y, z).Normalize();
            if (forward == Vector3.Empty) 
                return;
            gameObject.SetForward(forward);
        }
    }
}
