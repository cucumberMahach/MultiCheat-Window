using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using MultiCheat_Window.Utils.Maths;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCheat_Window.CSGOApi
{
    public class CSGOFunctions
    {
        private readonly Memory memory;
        private Process csgoProcess;
        private readonly int player, flashAddress, attackEventAddress, myTeamAddress, inCrossIdAddress, entitiesArrayAddress, glowObjectAddress, clientState, dll_client_address, dll_engine_address;
        public readonly int PlayerEntityID = -1;
        public CSGOFunctions(int dll_client_address, int dll_engine_address)
        {
            this.dll_client_address = dll_client_address;
            this.dll_engine_address = dll_engine_address;
            csgoProcess = Process.GetProcessesByName("csgo")[0];

            memory = new Memory(csgoProcess.Handle, Addresses.process);

            //int clientState = memory.ReadInt32((IntPtr)(dll_engine_address + Addresses.dwClientState));
            //int localPlayer = memory.ReadInt32((IntPtr)(clientState + Addresses.dwClientState_GetLocalPlayer));
            player = memory.ReadInt32((IntPtr)(dll_client_address + Addresses.dwLocalPlayer));
            flashAddress = player + Addresses.m_flFlashMaxAlpha;
            attackEventAddress = dll_client_address + Addresses.dwForceAttack;
            myTeamAddress = player + Addresses.m_iTeamNum;
            inCrossIdAddress = player + Addresses.m_iCrosshairId;
            entitiesArrayAddress = dll_client_address + Addresses.dwEntityList;
            glowObjectAddress = memory.ReadInt32((IntPtr)(dll_client_address + Addresses.dwGlowObjectManager)); //обновление
            clientState = memory.ReadInt32((IntPtr)(dll_engine_address + Addresses.dwClientState));

            for (int i = 0; i < 64; i++)
            {
                if (CalcPtrToEntity(i) == player)
                {
                    PlayerEntityID = i;
                    break;
                }
            }
            
        }

        public bool IsEntityValid(int id)
        {
            bool dormant = IsEntityDormant(id);
            return !dormant && IsEntityAlive(id) && IsEnemy(id);
        }

        public bool IsEnemy(int id)
        {
            return GetMyTeam() != GetEntityTeam(id);
        }

        public bool IsEntityAlive(int id)
        {
            int hp = GetEntityHealth(id);
            return hp > 0 && hp <= 100;
        }

        public void GetEntityEyePos(int id, Vector3 pos)
        {
            int prtToEntity = CalcPtrToEntity(id);
            pos.X = memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecOrigin)) + memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecViewOffset));
            pos.Y = memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecOrigin + 4)) + memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecViewOffset + 4));
            pos.Z = memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecOrigin + 4 * 2)) + memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecViewOffset + 4 * 2));
        }

        public void GetEntityBonePos(int id, int bone, Vector3 toOut)
        {
            //Matrix qm = new Matrix(3, 4);
            int boneMatrix = memory.ReadInt32((IntPtr)(CalcPtrToEntity(id) + Addresses.m_dwBoneMatrix));
            int address = boneMatrix + (0x30 * bone);

            toOut.X = memory.ReadFloat((IntPtr)(address + 4 * 3));
            toOut.Y = memory.ReadFloat((IntPtr)(address + 4 * 7));
            toOut.Z = memory.ReadFloat((IntPtr)(address + 4 * 11));

            /*toOut.X = qm[0, 3];
            toOut.Y = qm[1, 3];
            toOut.Z = qm[2, 3];*/
        }

        private Vector3[] ReadVectors(IntPtr Address, int count)
        {
            Vector3[] vecs = new Vector3[count];
            for (int i = 0; i < count; i++)
            {
                vecs[i] = ReadVector3(Address);
            }
            return vecs;
        }

        public void GetViewMatrix(Matrix m)
        {
            ReadMatrix(dll_client_address + Addresses.dwViewMatrix, m, 4, 4);
        }

        public Vector3 GetPlayerRecoilAngles(Vector3 vec)
        {
            vec.Y = memory.ReadFloat((IntPtr)(player + Addresses.m_aimPunchAngle));
            vec.X = memory.ReadFloat((IntPtr)(player + Addresses.m_aimPunchAngle + 4));
            vec.Z = memory.ReadFloat((IntPtr)(player + Addresses.m_aimPunchAngle + 4 * 2));
            return vec;
        }

        public Vector3 GetPlayerViewAngles(Vector3 vec)
        {
            vec.Y = memory.ReadFloat((IntPtr)(clientState + Addresses.m_viewPunchAngle));
            vec.X = memory.ReadFloat((IntPtr)(clientState + Addresses.m_viewPunchAngle + 4));
            vec.Z = memory.ReadFloat((IntPtr)(clientState + Addresses.m_viewPunchAngle + 4 * 2));
            return vec;
        }

        public void GetPlayerPosition(Vector3 vec)
        {
            vec.X = memory.ReadFloat((IntPtr)(player + Addresses.m_vecOrigin));
            vec.Y = memory.ReadFloat((IntPtr)(player + Addresses.m_vecOrigin + 4));
            vec.Z = memory.ReadFloat((IntPtr)(player + Addresses.m_vecOrigin + 4 * 2));
        }

        public void GetEntityPosition(int id, Vector3 vec)
        {
            int prtToEntity = CalcPtrToEntity(id);
            vec.X = memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecOrigin));
            vec.Y = memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecOrigin + 4));
            vec.Z = memory.ReadFloat((IntPtr)(prtToEntity + Addresses.m_vecOrigin + 4 * 2));
        }

        public void DrawEntityGlow(int id, GlowColor color)
        {
            int glowIndex = memory.ReadInt32((IntPtr)(CalcPtrToEntity(id) + Addresses.m_iGlowIndex));
            int current = glowObjectAddress + glowIndex * 0x38 + 0x4;
            memory.WriteFloat((IntPtr)current, color.r);

            current = glowObjectAddress + glowIndex * 0x38 + 0x8;
            memory.WriteFloat((IntPtr)current, color.g);

            current = glowObjectAddress + glowIndex * 0x38 + 0xC;
            memory.WriteFloat((IntPtr)current, color.b);

            current = glowObjectAddress + glowIndex * 0x38 + 0x10;
            memory.WriteFloat((IntPtr)current, color.a);

            current = glowObjectAddress + glowIndex * 0x38 + 0x24;
            memory.WriteBoolean((IntPtr)current, color.rwo);

            current = glowObjectAddress + glowIndex * 0x38 + 0x25;
            memory.WriteBoolean((IntPtr)current, color.rwuo);
        }

        public void PlayerForceJump(int millisDelay)
        {
            memory.WriteInt32((IntPtr)(dll_client_address + Addresses.dwForceJump), 1);
            Thread.Sleep(millisDelay);
            memory.WriteInt32((IntPtr)(dll_client_address + Addresses.dwForceJump), 0);
        }

        public int GetPlayerFlags(int id)
        {
            return memory.ReadInt32((IntPtr)(CalcPtrToEntity(id) + Addresses.m_fFlags));
        }

        public int GetMyFlags()
        {
            return memory.ReadInt32((IntPtr)(player + Addresses.m_fFlags));
        }

        public bool SetSpotted(int id, bool value)
        {
            return memory.WriteBoolean((IntPtr)(CalcPtrToEntity(id) + Addresses.m_bSpotted), value);
        }

        public bool IsSpotted(int id)
        {
            return memory.ReadBoolean((IntPtr)(CalcPtrToEntity(id) + Addresses.m_bSpotted));
        }

        public bool IsEntityDormant(int id)
        {
            //return memory.ReadBoolean((IntPtr)(CalcPtrToEntity(id) + Addresses.oDormant));
            return false;
        }

        public int GetEntityTeam(int id)
        {
            return memory.ReadInt32((IntPtr)(CalcPtrToEntity(id) + Addresses.m_iTeamNum));
        }

        public int GetEntityHealth(int id)
        {
            return memory.ReadInt32((IntPtr)(CalcPtrToEntity(id) + Addresses.m_iHealth));
        }

        public int GetInCrossID()
        {
            return memory.ReadInt32((IntPtr)inCrossIdAddress);
        }

        public int GetMyTeam()
        {
            return memory.ReadInt32((IntPtr)myTeamAddress);
        }

        public void AttackEvent(int mode)
        {
            memory.WriteInt32((IntPtr)attackEventAddress, mode);
        }

        public float GetFlashAlpha()
        {
            return memory.ReadFloat((IntPtr)flashAddress);
        }

        public void SetFlashAlpha(float value)
        {
            memory.WriteFloat((IntPtr)flashAddress, value);
        }

        private int CalcPtrToEntity(int id)
        {
            return memory.ReadInt32((IntPtr)(entitiesArrayAddress + (id - 1) * Addresses.oEntityLoopDistance)); // -1 для триггера
        }

        private void ReadMatrix(int address, Matrix m, int rows, int columns)
        {
            int size = rows * columns;
            for (int i = 0; i < size; i++)
            {
                m[i] = memory.ReadFloat((IntPtr)(address + 4 * i));
            }
        }

        private Vector3 ReadVector3(IntPtr address, int offsetBetween = 0)
        {
            Vector3 vec = new Vector3();
            vec.X = memory.ReadFloat(address + offsetBetween);
            vec.Y = memory.ReadFloat(address + 4 + offsetBetween);
            vec.Z = memory.ReadFloat(address + 8);
            return vec;
        }

        public static void InitVars(DumperData vars)
        {
            Addresses.dwLocalPlayer = vars.signatures["dwLocalPlayer"];
            Addresses.dwEntityList = vars.signatures["dwEntityList"];
            Addresses.m_iCrosshairId = vars.netvars["m_iCrosshairId"];
            Addresses.m_iTeamNum = vars.netvars["m_iTeamNum"];
            Addresses.m_iHealth = vars.netvars["m_iHealth"];
            Addresses.dwForceAttack = vars.signatures["dwForceAttack"];
            Addresses.m_flFlashMaxAlpha = vars.netvars["m_flFlashMaxAlpha"];
            Addresses.dwGlowObjectManager = vars.signatures["dwGlowObjectManager"];
            Addresses.m_iGlowIndex = vars.netvars["m_iGlowIndex"];
            Addresses.m_bSpotted = vars.netvars["m_bSpotted"];
            Addresses.m_dwBoneMatrix = vars.netvars["m_dwBoneMatrix"];
            Addresses.dwClientState = vars.signatures["dwClientState"];
            Addresses.m_iShotsFired = vars.netvars["m_iShotsFired"];
            Addresses.m_aimPunchAngle = vars.netvars["m_aimPunchAngle"];
            Addresses.m_viewPunchAngle = vars.netvars["m_viewPunchAngle"];
            Addresses.m_fFlags = vars.netvars["m_fFlags"];
            Addresses.dwForceJump = vars.signatures["dwForceJump"];
            Addresses.dwViewMatrix = vars.signatures["dwViewMatrix"];
            Addresses.m_vecOrigin = vars.netvars["m_vecOrigin"];
            Addresses.m_vecViewOffset = vars.netvars["m_vecViewOffset"];
            Addresses.dwClientState_GetLocalPlayer = vars.signatures["dwClientState_GetLocalPlayer"];
        }

        public enum LocalFlags
        {
             FL_ON_GROUND = 257,
             FL_ON_GROUND_CROUCHED = 263,
             FL_IN_AIR_STAND = 256,
             FL_IN_AIR_MOVING_TO_STAND = 258,
             FL_ON_GROUND_MOVING_TO_STAND = 259,
             FL_IN_AIR_MOVING_TO_CROUCH = 260,
             FL_ON_GROUND_MOVING_TO_CROUCH = 261,
             FL_IN_AIR_CROUCHED = 262,
             FL_IN_WATER = 1280,
             FL_IN_PUDDLE = 1281,
             FL_IN_WATER_CROUCHED = 1286,
             FL_IN_PUDDLE_CROUCHED = 1287,
             FL_PARTIALGROUND = (1 << 18)
        }

        public enum TeamTypes
        {
            TEAM_ID_GOTV = 1,
            TEAM_ID_T = 2,
            TEAM_ID_CT = 3
        }
    }
    static class Addresses
    {
        public static string process = "csgo";

        public static int dwLocalPlayer;
        public static int dwEntityList;
        public static int m_iCrosshairId;
        public static int m_iTeamNum;
        public static int m_iHealth;
        public static int dwForceAttack;
        public static int oEntityLoopDistance = 0x10;
        public static int m_flFlashMaxAlpha;
        public static int dwGlowObjectManager;
        public static int m_iGlowIndex;
        public static int oDormant = 0xED;
        public static int m_bSpotted;
        public static int m_dwBoneMatrix;
        public static int dwClientState;
        public static int dwClientState_GetLocalPlayer;
        public static int m_iShotsFired;
        public static int m_aimPunchAngle;
        public static int m_viewPunchAngle;
        public static int m_fFlags;
        public static int dwForceJump;
        public static int dwViewMatrix;
        public static int m_vecOrigin;
        public static int m_vecViewOffset;
    }
    public class GlowColor
    {
        public float r;
        public float g;
        public float b;
        public float a = 1;
        public bool rwo = true;
        public bool rwuo = true;

        public void RestoreTeam()
        {
            r = 0;
            g = 0;
            b = 1;
        }

        public void RestoreEnemyAndCalc(int i_hp)
        {
            float hp = i_hp / 100f;
            r = 1 - hp;
            g = hp;
            b = 0;
        }
    }
}
