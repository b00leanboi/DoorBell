using System;
using static DoorBell.ConnectionStatus;

namespace DoorBell
{
    public class ByteValueArg : EventArgs
    {
        public byte value;

        public ByteValueArg(byte value)
        {
            this.value = value;
        }
    }
    public class StringValueArg : EventArgs
    {
        public string value;

        public StringValueArg(string value)
        {
            this.value = value;
        }
    }
    public class IntValueArg : EventArgs
    {
        public int value;

        public IntValueArg(int value)
        {
            this.value = value;
        }
    }
    public class BoolValueArg : EventArgs
    {
        public bool value;

        public BoolValueArg(bool value)
        {
            this.value = value;
        }
    }
    class ConnectionArgs : EventArgs
    {
        public Property property;
        public bool newState;
        public ChangeReasons changeReason;
        public string message;

        public ConnectionArgs(Property property, bool newState, ChangeReasons changeReason, string message)
        {
            this.property = property;
            this.newState = newState;
            this.changeReason = changeReason;
            this.message = message;
        }
    }
}
