using GameOverlay.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCheat_Window.Utils.Maths
{
    public static class MathUtils
    {
        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            float x = x2 - x1;
            float y = y2 - y1;
            return (float) Math.Sqrt(x * x + y * y);
        }
        public static Rectangle EnterRecXYWH(float x, float y, float width, float height)
        {
            return new Rectangle(x, y, x + width, y + height);
        }

        public static Rectangle EnterRecXY(float x1, float y1, float x2, float y2)
        {
            return EnterRecXYWH(x1, y1, x2 - x1, y2 - y1);
        }

        public static bool WorldToScreen(Matrix viewMatrix, int screenW, int screenH, Vector3 point3D, Vector2 returnVector)
        {
            float w = viewMatrix[3, 0] * point3D.X + viewMatrix[3, 1] * point3D.Y + viewMatrix[3, 2] * point3D.Z + viewMatrix[3, 3];
            if (w >= 0.01f)
            {
                float inverseX = 1f / w;
                returnVector.X =
                    (screenW / 2f) +
                    (0.5f * (
                    (viewMatrix[0, 0] * point3D.X + viewMatrix[0, 1] * point3D.Y + viewMatrix[0, 2] * point3D.Z + viewMatrix[0, 3])
                    * inverseX)
                    * screenW + 0.5f);
                returnVector.Y =
                    (screenH / 2f) -
                    (0.5f * (
                    (viewMatrix[1, 0] * point3D.X + viewMatrix[1, 1] * point3D.Y + viewMatrix[1, 2] * point3D.Z + viewMatrix[1, 3])
                    * inverseX)
                    * screenH + 0.5f);
            }
            return !(returnVector.X > screenW || returnVector.X <= 0 || returnVector.Y > screenH || returnVector.Y <= 0);
        }

        public static double DegreeToRadian(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }
        public static double RadianToDegree(double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        public static double Tan(double degrees)
        {
            return RadianToDegree(Math.Tan(DegreeToRadian(degrees)));
        }

        public static void AnglesToScreen(Vector3 angles, float h, ref Vector3 screen)
        {
            screen.X = (float)Tan(angles.X) * h;
            screen.Y = (float)Tan(angles.Y) * h;
        }

        public static float AngletoScreenX(int width, int height, double angle, double previous)
        {
            double theta = (angle - previous) * (Math.PI / 180);
            double X = (height * Math.Tan(theta)) / (2 * Math.Tan(37 * (Math.PI / 180)));//a
            return (float)X;
        }
        public static float AngletoScreenY(int width, int height, double angle, double previous)
        {
            int B = 100;
            if (width / height == 4 / 3)
            {
                B = 90;
            }
            else if (width / height == 16 / 9)
            {
                B = 106;
            }
            else
            {
                B = 100;
            }
            double A = (B / 2) * (Math.PI / 180);
            double theta = (angle - previous) * (Math.PI / 180);
            double Y = (height * Math.Tan(theta)) / (2 * Math.Tan(A));
            return (float)Y;
        }
    }
}
