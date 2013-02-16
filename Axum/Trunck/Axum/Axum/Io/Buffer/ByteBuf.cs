namespace Axum.Io.Buffer
{
    public interface IByteBuf   :IBuf

    {
        int Capacity();
        IByteBuf Capacity(int newCapacity);
        int  MaxCapacity();
        IByteBufAllocator Alloc();
        IByteBuf Order();
        IByteBuf Order(ByteOrder endiannes);
        IByteBuf Unwrap();
        bool IsDirect();
        int ReaderIndex();
        IByteBuf ReaderIndex(int ReaderIndex);
        int WriteIndex();
        IByteBuf WriteIndex(int writeIndex);
        IByteBuf SetIndex(int readerIndex, int writeIndex);
        int ReadableBytes();
        int WritableBytes();
        int MaxWritableBytes();
        bool IsReadable();
        bool Readable();
        bool IsWritable();
        bool Writable();
        IByteBuf Clear();
        IByteBuf ResetReaderIndex();
        IByteBuf MarkWriterIndex();
        IByteBuf ResetWriterIndex();
        IByteBuf DiscardReadBytes();
        IByteBuf DiscardSomeReadBytes();
        IByteBuf EnsureWritableBytes(int minWritableBytes);
        int EnsureWritableBytes(int minWritableBytes, bool force);
        bool GetBoolean(int index);
        byte GetByte(int index);
        ushort GetUnsignedByte(int index);
        short GetShort(int index);
        ushort GetUnsignedShort(int index);
        int GetMedium(int index);
        uint GetUnsignedMedium(int index);
        int GetInt(int index);
        int GetUnsignedInt(int index);
        long GetLong(int index);
        char GetChar(int index);
        float GetFloat(int index);
        double GetDouble(int index);
        IByteBuf GetBytes(int index, IByteBuf dst);
        IByteBuf GetBytes(int index, IByteBuf dst, int length);
        IByteBuf GetBytes(int index, IByteBuf dst,int dstIndex, int length);
        IByteBuf GetBytes(int index, byte[] dst);
        IByteBuf GetBytes(int index, byte[] dst, int dstIndex, int length);
        IByteBuf GetBytes(int index, ByteBuffer dst);
        IByteBuf GetBytes(int index, OutputStream  @out, int length);
        IByteBuf GetBytes(int index, IGatheringByteChannel @out, int length);
        IByteBuf SetBoolean(int index, bool value);
        IByteBuf SetByte(int index, byte value);
        IByteBuf SetMedium(int index, int value);
        IByteBuf SetInt(int index, long value);
        IByteBuf SetLong(int index, long value);
        IByteBuf SetChar(int index, char value);
        IByteBuf SetFloat(int index, float value);
        IByteBuf SetDouble(int index, double value);
        IByteBuf SetBytes(int index, IByteBuf value);
        IByteBuf SetBytes(int index, IByteBuf src, int length );
        IByteBuf SetBytes(int index, IByteBuf src,int srcIndex, int length );
        IByteBuf SetBytes(int index, byte[] src );
        IByteBuf SetBytes(int index, byte[] src, int srcIndex, int length);
        IByteBuf SetBytes(int index, ByteBuffer src);
        IByteBuf SetBytes(int index, InputStream @in, int length);
        IByteBuf SetBytes(int index, IScatteringByteChannel @in, int length);
        IByteBuf SetZeros(int index, int length);
        IByteBuf ReadBoolean();
        byte ReadByte();
        ushort ReadUnsignedByte();
        short ReadShort();
        ushort ReadUnsignedShort();
        int ReadMedium();
        int ReadUnsignedMedium();
        int ReadInt();
        uint ReadUnsignedInt();
        long ReadLong();
        float ReadFloat();
        double ReadDouble();
        IByteBuf ReadBytes(int length);
        IByteBuf ReadSlice(int length);

    }
}