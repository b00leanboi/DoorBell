using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell
{
    class ConnectionStatus
    {
        public static event EventHandler<ConnectionArgs> aliveChanged;
        public static event EventHandler<ConnectionArgs> errorChanged;
        public static event EventHandler<ConnectionArgs> ringChanged;

        public static bool alive;
        public static bool error;
        public static bool ring;

        public enum Property
        {
            alive,
            error,
            ring
        }
        public enum ChangeReasons
        {
            ringOn,
            ringOff,
            errorReceived,
            messageReceived,
            timeout,
            timerCheck
        }
        public static void Set(Property property, bool value, ChangeReasons changeReason, string message = null)
        {
            switch (property)
            {
                case Property.alive:
                    alive = value;
                    aliveChanged.Invoke(null, new ConnectionArgs(Property.alive, value, changeReason, message));
                    break;
                case Property.error:
                    error = value;
                    errorChanged.Invoke(null, new ConnectionArgs(Property.error, value, changeReason, message));
                    break;
                case Property.ring:
                    ring = value;
                    ringChanged.Invoke(null, new ConnectionArgs(Property.ring, value, changeReason, message));
                    if (!value)
                        Set(Property.alive, true, ChangeReasons.ringOff);
                    break;
                default:
                    break;
            }
        }
    }
}
