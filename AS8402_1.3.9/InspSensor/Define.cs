using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspSensor
{
    public class Define
    {
    }
    public enum InspectionType
    {
        Undefined = 0,
        Tray = 1,
        Panel = 2,
        Blob = 3
    };
    public enum ConnectStatus
    {
        /// <summary>
        /// Device is disconnected.
        /// </summary>
        Disconnected = 0,
        /// <summary>
        /// Device is being connected.
        /// </summary>
        Connecting = 1,
        /// <summary>
        /// Device is connected.
        /// </summary>
        Connected = 2,
        /// <summary>
        /// Device is being disconnected.
        /// </summary>
        Disconnecting = 3,
        /// <summary>
        /// Not available.
        /// </summary>
        NA = 4,
    };
    public enum RunState
    {
        Stopped,
        RunningContinuous,
        RunningOnce,
        RunningLive
    };
    public enum AccessLevel { Operator, Supervisor, Administrator }

    public class AccessLevelChangedEventArgs : EventArgs
    {
        public AccessLevel Level { get; internal set; }
        public AccessLevelChangedEventArgs(AccessLevel level)
        {
            Level = level;
        }
    }
}
