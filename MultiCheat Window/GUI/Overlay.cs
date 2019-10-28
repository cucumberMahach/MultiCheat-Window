using GameOverlay;
using GameOverlay.Graphics;
using GameOverlay.Graphics.Primitives;
using GameOverlay.Utilities;
using GameOverlay.Windows;
using MultiCheat_Window.Cheats;
using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils.Maths;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiCheat_Window.GUI
{
    public class Overlay
    {
        private OverlayWindow _window;
        private D2DDevice _device;
        private FrameTimer _frameTimer;
        private bool _initializeGraphicObjects;
        private D2DColor _backgroundColor;
        private D2DFont _font;
        private D2DSolidColorBrush _blackBrush;
        private D2DSolidColorBrush _redBrush;
        private D2DSolidColorBrush _greenBrush;
        private D2DSolidColorBrush _blueBrush;

        private OtherCheatsRealisation OtherCheatsRealisation;
        private AimCheats aimCheats;

        private Vector2 pos = new Vector2();
        private string text = "";


        public Overlay(OtherCheatsRealisation OtherCheatsRealisation, AimCheats aimCheats)
        {
            this.OtherCheatsRealisation = OtherCheatsRealisation;
            this.aimCheats = aimCheats;
            SetupInstance();
        }

        ~Overlay()
        {
            DestroyInstance();
        }

        public void setText(string value)
        {
            text = value;
        }

        public void setPos(float x, float y)
        {
            pos.X = x;
            pos.Y = y;
        }


        private void SetupInstance()
        {
            _window = new OverlayWindow(new OverlayOptions()
            {
                BypassTopmost = false,
                Height = Constants.screenHeight,
                Width = Constants.screenWidth,
                WindowTitle = "Overlay",
                X = 0,
                Y = 0
            });

            _device = new D2DDevice(new DeviceOptions()
            {
                AntiAliasing = true,
                Hwnd = _window.WindowHandle,
                MeasureFps = true,
                MultiThreaded = false,
                VSync = true
            });

            /*for (int i = 0; i < pointsT.Length; i++)
            {
                pointsT[i] = new Vector2();
            }*/
            for (int i = 0; i < pointsCT.Length; i++)
            {
                pointsCT[i] = new Vector2();
            }
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Vector2();
            }
            for (int i = 0; i < bones_points.Length; i++)
            {
                bones_points[i] = new Vector2();
            }

            _frameTimer = new FrameTimer(_device, 0);

            _window.OnWindowBoundsChanged += _window_OnWindowBoundsChanged;

            _initializeGraphicObjects = true;

            _frameTimer.OnFrameStarting += _frameTimer_OnFrameStarting;
            _frameTimer.OnFrame += _frameTimer_OnFrame;

            _frameTimer.Start();
        }

        public void DestroyInstance()
        {
            _frameTimer.Stop();

            _frameTimer.Dispose();
            _device.Dispose();
            _window.Dispose();

            _window = null;
            _device = null;
            _frameTimer = null;
        }

        private void _window_OnWindowBoundsChanged(int x, int y, int width, int height)
        {
            if (_device == null) return;
            if (!_device.IsInitialized) return;

            _device.Resize(width, height);
        }

        private void _frameTimer_OnFrameStarting(FrameTimer timer, D2DDevice device)
        {
            if (!_initializeGraphicObjects) return;

            if (!device.IsInitialized) return;
            if (device.IsDrawing) return;

            _backgroundColor = new D2DColor(0, 0, 0, 0);

            _font = _device.CreateFont(new FontOptions()
            {
                Bold = false,
                FontFamilyName = "Times New Roman",
                FontSize = 10,
                Italic = false,
                WordWrapping = true
            });

            // colors automatically normalize values to fit. you can use 1.0f but also 255.0f.
            _blackBrush = device.CreateSolidColorBrush(0x0, 0x0, 0x0, 0xFF);

            _redBrush = device.CreateSolidColorBrush(0xFF, 0x0, 0x0, 0xFF);
            _greenBrush = device.CreateSolidColorBrush(0x0, 0xFF, 0x0, 0xFF);
            _blueBrush = device.CreateSolidColorBrush(0x0, 0x0, 0xFF, 0xFF);

            _initializeGraphicObjects = false;
        }

        // public Vector2[] points = new Vector2[Constants.Llegbones.Length + Constants.Rlegbones.Length + Constants.Spinebones.Length + Constants.Larmbones.Length + Constants.Rarmbones.Length];
        

        private void _frameTimer_OnFrame(FrameTimer timer, D2DDevice device)
        {
            if (!device.IsDrawing)
            {
                _initializeGraphicObjects = true;
                return;
            }

            device.ClearScene(_backgroundColor);
            //device.DrawTextWithBackground("FPS: " + device.FramesPerSecond, 0, 0, _font, _redBrush, _blackBrush);
            //device.DrawTextWithBackground(text, 0, 20, _font, _redBrush, _blackBrush);
            if (OtherCheatsRealisation.IsWallHackEspEnabled())
            {
                ESPRectangle[] Rects = OtherCheatsRealisation.Rects;

                Vector3 tempVector3 = new Vector3(), tempVector3_2 = new Vector3();

                for (int i = 0; i < Rects.Length; i++)
                {

                    if (Rects[i].topPosX != 0 && Rects[i].topPosY != 0)
                        device.DrawCircle(Rects[i].topPosX, Rects[i].topPosY, 5 * (1000 / Rects[i].lenToPlayer), 3, Rects[i].IsEnemy ? _redBrush : _greenBrush);

                    if (Rects[i].downPosX != 0 && Rects[i].downPosY != 0)
                    {
                        float cof = (200 / Rects[i].lenToPlayer);
                        float[] newPos;
                        newPos = Сentering(Rects[i].downPosX, Rects[i].downPosY, 100 * cof, 20 * cof, device, _blackBrush);
                        device.FillRectangle(newPos[0] + 1, newPos[1] + 1, newPos[0] + (Rects[i].hp * 100 - 1) * cof, newPos[1] + (20 - 1) * cof, device.CreateSolidColorBrush(1-Rects[i].hp, Rects[i].hp, 0));
                    }
                        //device.DrawTextWithBackground(q, Rects[i].downPosX, Rects[i].downPosY, _font, 14, _blueBrush, _greenBrush);
                }
            }
            if (aimCheats.IsNoRecoilSaveEnabled())
            {
                device.FillCircle(aimCheats.RecoilCrossX, aimCheats.RecoilCrossY, 4, _redBrush);
            }
            if (aimCheats.IsAimEnabled())
            {
                device.DrawCircle(Constants.screenWidth/2, Constants.screenHeight / 2, aimCheats.AIM_RADIUS, 2, _blueBrush);
            }
            //DrawTSkeleton(device);
            //DrawSkeletonT(device);
            //DrawCTSkeleton(device);
            // DrawTSkeleton(device);
            //DrawSkeletonT(device);
            // DrawSkeletonCT(device);
            /*for (int i = 0; i < points.Length; i++)
                device.DrawTextWithBackground(i.ToString(), points[i].X, points[i].Y, _font, _redBrush, _blackBrush);*/

            /*for (int i = 0; i+1 < bones_points.Length; i += 2)
            {
                device.DrawLine(bones_points[i].X, bones_points[i].Y, bones_points[i+1].X, bones_points[i+1].Y, 1, _redBrush);
            }*/
            //DrawText(device);

        }

        private float[] Сentering(float x, float y, float w, float h, D2DDevice device, ID2DBrush brush)
        {
            float newX = x - w / 2;
            float newY = y - h / 2;
            device.FillRectangle(newX, newY, newX + w, newY + h, brush);
            float[] newLeftRight = new float[2];
            newLeftRight[0] = newX;
            newLeftRight[1] = newY;
            return newLeftRight;
        }



    //public Vector2[] pointsT = new Vector2[Constants.pointsIndexesT.Length];
    public Vector2[] pointsCT = new Vector2[Constants.pointsIndexesCT.Length];

        public Vector2[] points = new Vector2[128];
        public Vector2[] bones_points = new Vector2[90];

        /*internal void DrawCTSkeleton(D2DDevice device)
        {
            
            device.DrawLine(bones_points[8 ].X, bones_points[8 ].Y, bones_points[39].X, bones_points[39].Y, 1, _redBrush);
            device.DrawLine(bones_points[39].X, bones_points[39].Y, bones_points[40].X, bones_points[40].Y, 1, _redBrush);
            device.DrawLine(bones_points[40].X, bones_points[40].Y, bones_points[41].X, bones_points[41].Y, 1, _redBrush);
            device.DrawLine(bones_points[41].X, bones_points[41].Y, bones_points[64].X, bones_points[64].Y, 1, _redBrush);
            device.DrawLine(bones_points[64].X, bones_points[64].Y, bones_points[96].X, bones_points[96].Y, 1, _redBrush);
            device.DrawLine(bones_points[96].X, bones_points[96].Y, bones_points[61].X, bones_points[61].Y, 1, _redBrush);
            device.DrawLine(bones_points[39].X, bones_points[39].Y, bones_points[38].X, bones_points[38].Y, 1, _redBrush);
            device.DrawLine(bones_points[38].X, bones_points[38].Y, bones_points[12].X, bones_points[12].Y, 1, _redBrush);
            device.DrawLine(bones_points[12].X, bones_points[12].Y, bones_points[35].X, bones_points[35].Y, 1, _redBrush);
            device.DrawLine(bones_points[35].X, bones_points[35].Y, bones_points[23].X, bones_points[23].Y, 1, _redBrush);
            device.DrawLine(bones_points[39].X, bones_points[39].Y, bones_points[81].X, bones_points[81].Y, 1, _redBrush);
            
            device.DrawLine(bones_points[81].X, bones_points[81].Y, bones_points[77].X, bones_points[77].Y, 1, _redBrush);
            device.DrawLine(bones_points[77].X, bones_points[77].Y, bones_points[73].X, bones_points[73].Y, 1, _redBrush);
            device.DrawLine(bones_points[73].X, bones_points[73].Y, bones_points[74].X, bones_points[74].Y, 1, _redBrush);
            device.DrawLine(bones_points[74].X, bones_points[74].Y, bones_points[75].X, bones_points[75].Y, 1, _redBrush);
            
            device.DrawLine(bones_points[81].X, bones_points[81].Y, bones_points[86].X, bones_points[86].Y, 1, _redBrush);
            device.DrawLine(bones_points[86].X, bones_points[86].Y, bones_points[82].X, bones_points[82].Y, 1, _redBrush);
            device.DrawLine(bones_points[82].X, bones_points[82].Y, bones_points[83].X, bones_points[83].Y, 1, _redBrush);
            device.DrawLine(bones_points[83].X, bones_points[83].Y, bones_points[84].X, bones_points[84].Y, 1, _redBrush);
        }*/

        /*internal void DrawTSkeleton(D2DDevice device)
        {
            
            
            device.DrawLine(pointsT[8].X, pointsT[8].Y, pointsT[7].X, pointsT[7].Y, 1, _redBrush);
            device.DrawLine(pointsT[7].X, pointsT[7].Y, pointsT[39].X, pointsT[39].Y, 1, _redBrush);
            device.DrawLine(pointsT[39].X, pointsT[39].Y, pointsT[40].X, pointsT[40].Y, 1, _redBrush);
            device.DrawLine(pointsT[40].X, pointsT[40].Y, pointsT[41].X, pointsT[41].Y, 1, _redBrush);
            device.DrawLine(pointsT[41].X, pointsT[41].Y, pointsT[60].X, pointsT[60].Y, 1, _redBrush);
            
            device.DrawLine(pointsT[7].X, pointsT[7].Y, pointsT[11].X, pointsT[11].Y, 1, _redBrush);
            device.DrawLine(pointsT[11].X, pointsT[11].Y, pointsT[12].X, pointsT[12].Y, 1, _redBrush);
            device.DrawLine(pointsT[12].X, pointsT[12].Y, pointsT[13].X, pointsT[13].Y, 1, _redBrush);
            device.DrawLine(pointsT[13].X, pointsT[13].Y, pointsT[25].X, pointsT[25].Y, 1, _redBrush);

            device.DrawLine(pointsT[7].X, pointsT[7].Y, pointsT[4].X, pointsT[4].Y, 1, _redBrush);
            device.DrawLine(pointsT[4].X, pointsT[4].Y, pointsT[0].X, pointsT[0].Y, 1, _redBrush);
            
            device.DrawLine(pointsT[0].X, pointsT[0].Y, pointsT[78].X, pointsT[78].Y, 1, _redBrush);
            device.DrawLine(pointsT[78].X, pointsT[78].Y, pointsT[79].X, pointsT[79].Y, 1, _redBrush);
            device.DrawLine(pointsT[79].X, pointsT[79].Y, pointsT[74].X, pointsT[74].Y, 1, _redBrush);
            device.DrawLine(pointsT[74].X, pointsT[74].Y, pointsT[75].X, pointsT[75].Y, 1, _redBrush);
            device.DrawLine(pointsT[75].X, pointsT[75].Y, pointsT[76].X, pointsT[76].Y, 1, _redBrush);
            
            device.DrawLine(pointsT[0].X, pointsT[0].Y, pointsT[66].X, pointsT[66].Y, 1, _redBrush);
            device.DrawLine(pointsT[66].X, pointsT[66].Y, pointsT[71].X, pointsT[71].Y, 1, _redBrush);
            device.DrawLine(pointsT[71].X, pointsT[71].Y, pointsT[67].X, pointsT[67].Y, 1, _redBrush);
            device.DrawLine(pointsT[67].X, pointsT[67].Y, pointsT[68].X, pointsT[68].Y, 1, _redBrush);
            device.DrawLine(pointsT[68].X, pointsT[68].Y, pointsT[69].X, pointsT[69].Y, 1, _redBrush);
        }*/

        /*private void DrawSkeletonT(D2DDevice device) //work
        {
            for (int i = 0; i+1 < OtherCheatsRealisation.pointsT.Length; i+=2)
            {
                device.DrawLine(OtherCheatsRealisation.pointsT[i].X, OtherCheatsRealisation.pointsT[i].Y, OtherCheatsRealisation.pointsT[i+1].X, OtherCheatsRealisation.pointsT[i+1].Y, 1, _redBrush);
            }
        }*/

        /*private void DrawSkeletonCT(D2DDevice device)
        {
            for (int i = 0; i + 1 < pointsCT.Length; i += 2)
            {
                device.DrawLine(pointsCT[i].X, pointsCT[i].Y, pointsCT[i + 1].X, pointsCT[i + 1].Y, 1, _blueBrush);
            }
        }

        internal void DrawText(D2DDevice device)
        {
            for (int i = 0; i < points.Length; i++)
                device.DrawTextWithBackground(i.ToString(), points[i].X, points[i].Y, _font, _redBrush, _blackBrush);
        }*/
    }
}
