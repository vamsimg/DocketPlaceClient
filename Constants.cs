

namespace SerialPortSnifferAx
{
	public class Constants 
	{
		public const int SERIAL_DTR_CONTROL     = 0x01; 
		public const int SERIAL_DTR_HANDSHAKE   = 0x02;
		public const int SERIAL_CTS_HANDSHAKE   = 0x08; 
		public const int SERIAL_DCD_HANDSHAKE   = 0x20;
		public const int SERIAL_DSR_HANDSHAKE   = 0x10; 
		public const int SERIAL_DSR_SENSITIVITY = 0x40; 
		public const int SERIAL_ERROR_ABORT     = 0x8000000; 

		public const int SERIAL_AUTO_TRANSMIT  = 0x01; 
		public const int SERIAL_AUTO_RECEIVE   = 0x02; 
		public const int SERIAL_ERROR_CHAR     = 0x04; 
		public const int SERIAL_NULL_STRIPPING = 0x08; 
		public const int SERIAL_BREAK_CHAR     = 0x10; 
		public const int SERIAL_RTS_CONTROL    = 0x40; 
		public const int SERIAL_RTS_HANDSHAKE  = 0x80; 
	}
}
