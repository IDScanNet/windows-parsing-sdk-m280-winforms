namespace CompiledTechnologies.Constructs
{
    public class M280DEF
    {
        #region ********************************* Public Constructors *************************************
        public const string SWver = "3.02.00";
        public const string ProName = "M280 DLL";
        public const ushort USB_PID = 0x0280;
        public const ushort USB3_PID = 0x0282;

        public const ushort USB_VID = 0x28A6;
        public const byte CMD_ST_CAP = 0xDA;
        public const byte CMD_SET_ILLUMIN = 0xE0;
        public const byte CMD_INIT_CAMERA = 0xE1;
        public const byte CMD_GET_STATE = 0xEA;
        public const byte CMD_GET_VERSION = 0xEB;
        public const byte CMD_GET_IMGINFO = 0xEE;
        public const ushort SysInfo_FWVer = 1;
        public const ushort SysInfo_SNNum = 2;
        public const byte EEP_MAGIC_CODE = 0x55;
        public const ushort EEP_ADDR_DATAINFO = 15000;
        public const byte MAX_CNUM_APP1 = 10;
        public const int SN_LENG = 10;
        public const byte IMGINFO_SIZE = 20;
        public const int Packet_Xfer = 24;
        public const int Image_Xsize = 1024;
        public const int Image_Ysize = 768;
        public const int DefaultJpgQty = 70;
        public const float DPI = 272f;
        public const int STATUS_SIZE = 2;
        public const ushort stat_ReadyLED = 1 << 0;
        public const ushort stat_BusyLED = 1 << 1;
        public const ushort stat_CardDet = 1 << 2;
        public const ushort stat_CapDet = 1 << 3;
        public const ushort stat_CamInit = 1 << 4;
        public const ushort stat_SysBusy = 1 << 5;
        public const ushort stat_EngineEr = 1 << 7;
        public const ushort stat_EepromEr = 1 << 8;
        public const ushort stat_FPGAEr = 1 << 9;
        public const ushort StatusGetInterval = 100;
        public const ushort ON = 1;
        public const ushort OFF = 0;
        public const int TRANSFER_TIMEOUT = 1500;
        #endregion
    }
   
    public class M280IMGDEF
    {
        #region ********************************* Public Constructors *************************************
        public const int IMG_CARDSZ_X = 892;
        public const int IMG_CARDSZ_Y = 564;
        public const byte IMG_ANGLE = 0xFF / 2;
        #endregion
    }
}
