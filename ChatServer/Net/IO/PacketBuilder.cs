using System.Text;
using System;

namespace ChatServer.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        public void WriteMessage(string msg)
        {
            var msgBytes = Encoding.ASCII.GetBytes(msg);
            var msgLength = msgBytes.Length;
            _ms.Write(BitConverter.GetBytes(msgLength));
            _ms.Write(msgBytes);
        }

        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
