#region .NET Base Class Namespace Imports
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
#endregion

#region License Assemblies
using Nautilus;
#endregion

#region CyUSB Assemblies
using CyUSB;
#endregion

#region Compiled Technologies Assemblies
using CompiledTechnologies.Constructs;
using CompiledTechnologies.Events;
using CompiledTechnologies.Files;
using CompiledTechnologies.Utilities;
#endregion

namespace CompiledTechnologies.Devices
{
    public class M280 : IDisposable
    {
        #region ****************************** Public Delegate Handlers ***********************************
        public delegate void ExceptionCallback();
        public delegate void ImageView();
        public delegate void DataCallback();
        #endregion

        #region *********************************** Public Events *****************************************
        public event InitializedEventHandler Initialized;
        public event CapturedEventHandler Captured;
        public event DeviceAttachedHandler DeviceAttached;
        public event DeviceDetachedHandler DeviceDetached;
        public event DataReceivedHandler ReceiveData;
        public event EventHandler CheckState;
        #endregion

        #region *********************************** Private Fields ****************************************
        private SerialReader reader;
        private string readerdata;
        private string commport;
        private readonly DLFILE dlfile;
        private readonly Dispatcher dispatcher;
        private readonly CaptureUtility captureutility;
        private readonly ExceptionCallback handleException;
        private readonly ImageView imageview;
        private readonly System.Timers.Timer checkstatus;
        private readonly System.Timers.Timer capture;
        private USBDeviceList usbdevices;
        private CyUSBDevice usbdevice;
        private CyBulkEndPoint bulkendpoint;
        private CyControlEndPoint controlendpoint;
        private Bitmap image;
        private Thread startcapture;
        private readonly PixelFormat pixelformat;
        private int totalpixelsize;
        private readonly int buffernum;
        private int buffersize;
        private int queuesize;
        private int successes;
        private int failures;
        private double transferbytes;
        private bool scannerconnected;
        private bool systemready;
        private bool systembusy;
        private bool deviceready;
        private bool devicebusy;
        private bool running;
        // WIN10 UPDATE (VER:1803) -->
        private bool release;
        // <-- WIN10 UPDATE (VER:1803)
        private byte[][] databuffer;
        private byte[] m280status;
        private int datumpos_x;
        private int datumpos_y;
        private int cropsize_x;
        private int cropsize_y;
        private int angleinfo;
        private bool deskew;
        private bool disposed;
        #endregion

        #region ********************************* Public Initialize ***************************************
        public M280(string commPort = "")
        {
            readerdata = string.Empty;
            commport = commPort;
            dlfile = new DLFILE();
            dispatcher = Dispatcher.CurrentDispatcher;
            dispatcher.Thread.Priority = ThreadPriority.Highest;
            captureutility = new CaptureUtility();
            Initialized = null;
            Captured = null;
            DeviceAttached = null;
            DeviceDetached = null;
            ReceiveData = null;
            handleException = Thread_Exception;
            imageview = Image_Captured;
            checkstatus = new System.Timers.Timer();
            checkstatus.AutoReset = false;
            checkstatus.Elapsed += CheckState_Tick;
            checkstatus.Interval = M280DEF.StatusGetInterval;
            capture = new System.Timers.Timer();
            capture.AutoReset = false;
            capture.Elapsed += Capture_Tick;
            capture.Interval = 500;
            bulkendpoint = null;
            controlendpoint = null;
            deviceready = false;
            release = true;
            running = false;
            scannerconnected = false;
            devicebusy = true;
            deskew = true;
            m280status = new byte[M280DEF.STATUS_SIZE];
            pixelformat = PixelFormat.Format16bppRgb565;
            totalpixelsize = 0;
            InitializePixelSize();
            buffernum = totalpixelsize / (512 * M280DEF.Packet_Xfer);
            buffersize = 0;
            queuesize = 0;
            successes = 0;
            failures = 0;
            transferbytes = 0;
            disposed = false;
            GetUsbDevices();
            InitializeScanner();
            InitializeReader();
            onInitialized();
        }
        public void Start()
        {
            Open();
        }
        public void Stop()
        {
            Close();
        }
        public void Resume()
        {
           Open();
        }
        public void Suspend()
        {
            Close();
        }
        #endregion

        #region ****************************** Private Device Methods *************************************
        private void Open()
        {
            checkstatus.Start();
            readerdata = string.Empty;
            dlfile.Record.Initialize();
            reader?.OpenPort();
        }
        private void Close()
        {
            RemoveEvents();
            checkstatus.Stop();
            readerdata = string.Empty;
            dlfile.Record.Initialize();
            reader?.ClosePort();
        }
        #endregion

        #region ******************************** Private Initialize ***************************************
        private void GetUsbDevices()
        {
            try
            {
                usbdevices = new USBDeviceList(CyConst.DEVICES_CYUSB);
            }
            catch
            {
                usbdevices = null;
            }
            if (usbdevices == null || usbdevices.Count == 0)
            {
                devicebusy = false;
                bulkendpoint = null;
                controlendpoint = null;
                return;
            }
            usbdevices.DeviceAttached += usbdevices_DeviceAttached;
            usbdevices.DeviceRemoved += usbdevices_DeviceRemoved;
        }
        private void InitializeScanner()
        {
            if (usbdevices == null || usbdevices.Count == 0) { return; }
            usbdevice = usbdevices[M280DEF.USB_VID, M280DEF.USB_PID] as CyUSBDevice;
            if (usbdevice == null)
            {
                devicebusy = false;
                bulkendpoint = null;
                controlendpoint = null;
                return;
            }
            if (bulkendpoint == null)
            {
                bulkendpoint = usbdevice.EndPointOf(0x86) as CyBulkEndPoint;
                if (bulkendpoint == null) { return; }
                bulkendpoint.TimeOut = M280DEF.TRANSFER_TIMEOUT;
                controlendpoint = usbdevice.ControlEndPt;
                if (controlendpoint == null) { return; }
                controlendpoint.TimeOut = M280DEF.TRANSFER_TIMEOUT;
                InitializeImageInfo();
                SendCommand(M280DEF.CMD_INIT_CAMERA, 0, 0);
                scannerconnected = true;
                deviceready = true;
                devicebusy = false;
                checkstatus.Start();
            }
        }
        private void InitializePixelSize()
        {
            switch (pixelformat)
            {
                case PixelFormat.Format16bppRgb565:
                    totalpixelsize = M280DEF.Image_Xsize * M280DEF.Image_Ysize * 2;
                    break;
                case PixelFormat.Format24bppRgb:
                    totalpixelsize = M280DEF.Image_Xsize * M280DEF.Image_Ysize * 3;
                    break;
                default:
                    totalpixelsize = M280DEF.Image_Xsize * M280DEF.Image_Ysize * 2;
                    break;
            }
        }
        private void InitializeImageInfo()
        {
            if (usbdevice == null || controlendpoint == null) { return; }
            int len = M280DEF.IMGINFO_SIZE;
            byte[] dta = new byte[len];
            if (ReadCommand(M280DEF.CMD_GET_IMGINFO, ref dta, ref len, 0, 0))
            {
                Array.Reverse(dta, 0, 2);
                Array.Reverse(dta, 2, 2);
                Array.Reverse(dta, 4, 2);
                Array.Reverse(dta, 6, 2);
                Array.Reverse(dta, 14, 2);
                datumpos_x = BitConverter.ToUInt16(dta, 0);
                datumpos_y = BitConverter.ToUInt16(dta, 2);
                cropsize_x = BitConverter.ToUInt16(dta, 4);
                cropsize_y = BitConverter.ToUInt16(dta, 6);
                angleinfo = dta[13];
            }
            else
            {
                MessageBox.Show(@"Cannot find image information please check firmware version!");
                datumpos_x = (M280DEF.Image_Xsize - M280IMGDEF.IMG_CARDSZ_X) / 2;
                datumpos_y = (M280DEF.Image_Ysize - M280IMGDEF.IMG_CARDSZ_Y) / 2;
                cropsize_x = M280IMGDEF.IMG_CARDSZ_X;
                cropsize_y = M280IMGDEF.IMG_CARDSZ_Y;
                angleinfo = M280IMGDEF.IMG_ANGLE;
            }
        }
        private void InitializeReader()
        {
            if (usbdevices == null || usbdevices.Count == 0) { return; }
            readerdata = string.Empty;
            reader = new SerialReader(this);
        }
        #endregion

        #region ********************************* Public Properties ***************************************
        public DLFILE DLFILE
        {
            get { return dlfile; }
        }
        public Bitmap Image
        {
            get { return image; }
        }
        public bool Running
        {
            get { return running; }
        }
        public string CommPort
        {
            get { return commport; }
            set { commport = value; }
        }
        public string ReaderData
        {
            get { return readerdata; }
        }
        public bool ScannerConnected
        {
            get { return scannerconnected; }
        }
        public bool SystemReady
        {
            get { return systemready; }
        }
        public bool SystemBusy
        {
            get { return systembusy; }
        }
        public bool DeviceReady
        {
            get { return deviceready; }
        }
        public bool DeviceBusy
        {
            get { return devicebusy; }
        }
        public bool Deskew
        {
            get { return deskew; }
            set { deskew = value; }
        }
        #endregion

        #region ********************************** Public Methods *****************************************
        public void CaptureImage()
        {
            if (usbdevice == null || controlendpoint == null || bulkendpoint == null)
            {
                MessageBox.Show(@"USB device not found!", "M280", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!scannerconnected || running || devicebusy || systembusy || !deviceready) { return; }
            // WIN10 UPDATE (VER:1803) -->
            if (release == false) { return; }
            release = false;
            // <-- WIN10 UPDATE (VER:1803)
            reader.ClosePort();
            running = true;
            buffersize = bulkendpoint.MaxPktSize * M280DEF.Packet_Xfer;
            queuesize = buffernum;
            bulkendpoint.XferSize = buffersize;
            databuffer = new byte[totalpixelsize / buffersize][];
            for (int i = 0; i < (totalpixelsize / buffersize); i++)
            {
                databuffer[i] = new byte[buffersize];
            }
            startcapture = new Thread(XferThread);
            startcapture.IsBackground = false;
            startcapture.Priority = ThreadPriority.Highest;
            startcapture.Start();
            SendCommand(M280DEF.CMD_ST_CAP, 0, 0);
        }
        #endregion

        #region ****************************** Private Internal Events ************************************
        private void usbdevices_DeviceRemoved(object sender, EventArgs e)
        {
            Suspend();
            usbdevices = null;
            onDeviceDetached(e);
        }
        private void usbdevices_DeviceAttached(object sender, EventArgs e)
        {
            GetUsbDevices();
            InitializeReader();
            InitializeScanner();
            Resume();
            onDeviceAttched(e);
        }
        #endregion

        #region ****************************** Private Event Handlers *************************************
        private void RemoveEvents()
        {
            if (Captured != null)
            {
                foreach (Delegate d in Captured.GetInvocationList())
                {
                    Captured -= (CapturedEventHandler)d;
                }
            }
            if (ReceiveData != null)
            {
                foreach (Delegate d in ReceiveData.GetInvocationList())
                {
                    ReceiveData -= (DataReceivedHandler)d;
                }
            }
        }
        private void onDataReceived()
        {
            dispatcher.Invoke(onDataCallback);
        }
        private void onDataCallback()
        {
            if (ReceiveData == null) { return; }
            ReceiveData.Invoke(this, new DataReceivedArgs { DL = dlfile });
            capture.Start();
        }
        private void onDeviceAttched(EventArgs e)
        {
            DeviceAttached?.Invoke(this, e);
        }
        private void onDeviceDetached(EventArgs e)
        {
            DeviceDetached?.Invoke(this, e);
        }
        private void onCapture()
        {
            Captured?.Invoke(this, new CapturedEventArgs { Bitmap = image });
        }
        private void onInitialized()
        {
            Initialized?.Invoke(this, null);
        }
        private void onCheckState(EventArgs e)
        {
            CheckState?.Invoke(this, e);
        }
        private void Image_Captured()
        {
            Bitmap SourceImage = CreateBitmap(M280DEF.Image_Xsize, M280DEF.Image_Ysize, pixelformat);
            if (deskew)
            {
                SourceImage = captureutility.RotateImage(SourceImage, pixelformat, new PointF((datumpos_x + cropsize_x / 2), (datumpos_y + cropsize_y / 2)), (byte)angleinfo);
            }
            Rectangle CropRect = new Rectangle(datumpos_x, datumpos_y, cropsize_x, cropsize_y);
            image = SourceImage.Clone(CropRect, pixelformat);
            SourceImage.Dispose();
            onCapture();
            reader.OpenPort();
        }
        private void Thread_Exception()
        {
            running = false;
            startcapture = null;
            checkstatus.Stop();
            checkstatus.Dispose();
        }
        #endregion

        #region ******************************* Private Timer Events **************************************
        private void CheckState_Tick(object sender, EventArgs e)
        {
            checkstatus.Stop();
            int len = M280DEF.STATUS_SIZE;
            if (usbdevice == null || controlendpoint == null) return;
            ReadCommand(M280DEF.CMD_GET_STATE, ref m280status, ref len, 0, 0);
            UInt16 statusValue = BitConverter.ToUInt16(m280status, 0);
            if ((statusValue & M280DEF.stat_CapDet) == M280DEF.stat_CapDet && running == false) { CaptureImage(); }
            scannerconnected = (statusValue & M280DEF.stat_CamInit) == M280DEF.stat_CamInit;
            systemready = (statusValue & M280DEF.stat_CamInit) == M280DEF.stat_CamInit;
            systembusy = (statusValue & M280DEF.stat_SysBusy) == M280DEF.stat_SysBusy;
            devicebusy = (statusValue & M280DEF.stat_BusyLED) == M280DEF.stat_BusyLED;
            deviceready = (statusValue & M280DEF.stat_ReadyLED) == M280DEF.stat_ReadyLED;
            onCheckState(e);
            checkstatus.Start();
        }
        private void Capture_Tick(object sender, EventArgs e)
        {
            capture.Stop();
            CaptureImage();
        }
        #endregion

        #region ********************************* Private Methods *****************************************
        private bool SendCommand(byte Cmd, ushort val, ushort index)
        {
            if (usbdevice == null || controlendpoint == null) return false;
            controlendpoint.Target = CyConst.TGT_DEVICE;
            controlendpoint.ReqType = CyConst.REQ_VENDOR;
            controlendpoint.Direction = CyConst.DIR_TO_DEVICE;
            controlendpoint.ReqCode = Cmd;
            controlendpoint.Value = val;
            controlendpoint.Index = index;
            int len = 0;
            byte[] buf = new byte[1];
            return controlendpoint.XferData(ref buf, ref len);
        }
        private bool ReadCommand(byte Cmd, ref byte[] Read, ref int Len, ushort val, ushort index)
        {
            if (usbdevice == null || controlendpoint == null) return false;
            controlendpoint.Target = CyConst.TGT_DEVICE;
            controlendpoint.ReqType = CyConst.REQ_VENDOR;
            controlendpoint.Value = val;
            controlendpoint.Index = index;
            controlendpoint.ReqCode = Cmd;
            return controlendpoint.Read(ref Read, ref Len);
        }
        private Bitmap CreateBitmap(int Width, int Height, PixelFormat Pfmt)
        {
            switch (Pfmt)
            {
                case PixelFormat.Format24bppRgb:
                    if ((Width * Height * 3) != (totalpixelsize)) { return null; }
                    break;
                case PixelFormat.Format16bppRgb565:
                    if ((Width * Height * 2) != (totalpixelsize)) { return null; }
                    break;
                default:
                    return null;
            }
            try
            {
                Bitmap Canvas = new Bitmap(Width, Height, Pfmt);
                BitmapData CanvasData = Canvas.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, Pfmt);
                unsafe
                {
                    byte* Ptr = (byte*)CanvasData.Scan0.ToPointer();
                    for (int Y = 0; Y < totalpixelsize / buffersize; Y++)
                    {
                        for (int X = 0; X < buffersize; X++)
                        {
                            if (X % 2 == 1)
                            {
                                *Ptr = databuffer[Y][X];
                                Ptr++;
                                *Ptr = databuffer[Y][X - 1];
                                Ptr++;
                            }
                        }
                    }
                }
                Canvas.UnlockBits(CanvasData);
                return Canvas;
            }
            catch (Exception) { return null; }
        }
        #endregion

        #region ****************************** Private Unsafe Methods *************************************
        private void XferThread()
        {
            byte[][] cmdBufs = new byte[queuesize][];
            byte[][] xferBufs = new byte[queuesize][];
            byte[][] ovLaps = new byte[queuesize][];
            ISO_PKT_INFO[][] pktsInfo = new ISO_PKT_INFO[queuesize][];
            int xStart = 0;
            try
            {
                LockNLoad(ref xStart, cmdBufs, xferBufs, ovLaps, pktsInfo);
            }
            catch (NullReferenceException e)
            {
                e.GetBaseException();
                dispatcher.Invoke(handleException);
            }
            catch(Exception ex)
            {
                System.Console.Out.WriteLine(ex.ToString());
            }
        }
        private unsafe void LockNLoad(ref int j, byte[][] cBufs, byte[][] xBufs, byte[][] oLaps, ISO_PKT_INFO[][] pktsInfo)
        {

            CyIsocEndPoint InEndpt = usbdevice.IsocInEndPt;


            cBufs[j] = new byte[CyConst.SINGLE_XFER_LEN + bulkendpoint.MaxPktSize + ((bulkendpoint.XferMode == XMODE.BUFFERED) ? buffersize : 0) ];

            xBufs[j] = new byte[buffersize];
            oLaps[j] = new byte[20];
            pktsInfo[j] = new ISO_PKT_INFO[M280DEF.Packet_Xfer];

            fixed (byte* tL0 = oLaps[j], tc0 = cBufs[j], tb0 = xBufs[j])
            {
                OVERLAPPED* ovLapStatus = (OVERLAPPED*)tL0;
                ovLapStatus->hEvent = PInvoke.CreateEvent(0, 0, 0, 0);
                int len = buffersize;
                bulkendpoint.BeginDataXfer(ref cBufs[j], ref xBufs[j], ref len, ref oLaps[j]);
                j++;
                if (j < queuesize)
                {
                    LockNLoad(ref j, cBufs, xBufs, oLaps, pktsInfo);
                }
                else
                {
                    XferData(cBufs, xBufs, oLaps, pktsInfo);
                }
            }
        }
        private unsafe void XferData(byte[][] cBufs, byte[][] xBufs, byte[][] oLaps, ISO_PKT_INFO[][] pktsInfo)
        {
            int k = 0;
            int len = 0;
            int pDataBF = 0;
            successes = 0;
            failures = 0;
            transferbytes = 0;
            for (; running;)
            {
                fixed (byte* tmpOvlap = oLaps[k])
                {
                    OVERLAPPED* ovLapStatus = (OVERLAPPED*)tmpOvlap;
                    if (!bulkendpoint.WaitForXfer(ovLapStatus->hEvent, 500))
                    {
                        bulkendpoint.Abort();
                        PInvoke.WaitForSingleObject(ovLapStatus->hEvent, 500);
                    }
                }
                if (bulkendpoint.FinishDataXfer(ref cBufs[k], ref xBufs[k], ref len, ref oLaps[k]))
                {
                    transferbytes += len;
                    successes++;
                    Array.Copy(xBufs[k], 0, databuffer[pDataBF], 0, len);
                    pDataBF++;
                }
                else
                {
                    failures++;
                }
                // WIN10 UPDATE (VER:1803) -->
                // Re-submit this buffer into the queue
                len = buffersize;
                bulkendpoint.BeginDataXfer(ref cBufs[k], ref xBufs[k], ref len, ref oLaps[k]);
                // <-- WIN10 UPDATE (VER:1803)
                k++;
                if (k == queuesize)
                {
                    k = 0;
                    Thread.Sleep(1);
                    if (failures == 0)
                    {
                        dispatcher.Invoke(imageview);
                    }
                    else if (successes == 0)
                    {
                        len = 1024 * 4;
                        byte[] buf = new byte[len];
                        bulkendpoint.Abort();
                        bulkendpoint.Reset();
                        bulkendpoint.XferData(ref buf, ref len);
                        Thread.Sleep(100);
                    }
                    else
                    {
                        MessageBox.Show(@"Scanner is busy please wait a few seconds and try again!", "M280", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        len = 1024 * 4;
                        byte[] buf = new byte[len];
                        bulkendpoint.Abort();
                        bulkendpoint.Reset();
                        bulkendpoint.XferData(ref buf, ref len);
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(100);
                    running = false;
                }
            }
            // WIN10 UPDATE (VER:1803) -->
            bulkendpoint.Abort();
            release = true;
            // <-- WIN10 UPDATE (VER:1803)
        }
        #endregion

        #region ********************************** Dispose Methods ****************************************
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposed) { return; }
            if (disposing)
            {
                reader?.Dispose();
                checkstatus?.Dispose();
                capture?.Dispose();
                usbdevices?.Dispose();
                image?.Dispose();
            }
            disposed = true;
        }
        #endregion

        public class SerialReader : IDisposable
        {
            #region ********************************* Private Contructors *************************************
            private const int TIMEOUT = 500;
            #endregion

            #region *********************************** Private Fields ****************************************
            private readonly M280 m280;
            private readonly DriverLicense driverlicense;
            private SerialPort serialPort;
            private readonly StringBuilder data;
            private readonly System.Threading.Timer timer;
            private bool connected;
            private bool disposed;
            #endregion

            #region ********************************* Public Properties ***************************************
            public SerialPort SerialPort
            {
                get { return serialPort; }
                set { serialPort = value; }
            }
            public bool Connected
            {
                get { return connected; }
                set { connected = value; }
            }
            #endregion

            #region ********************************* Public Initialize ***************************************
            public SerialReader(M280 M280)
            {
                m280 = M280;
                driverlicense = new DriverLicense();
                data = new StringBuilder();
                timer = new System.Threading.Timer(TimerExpired, this, Timeout.Infinite, Timeout.Infinite);
                Initialize();
                disposed = false;
            }
            public void Initialize()
            {
                InitializePort();
            }
            public void OpenPort()
            {
                try
                {
                    serialPort.Open();
                }
                catch
                {
                    return;
                }
                serialPort.DataReceived += serialPort_DataReceived;
            }
            public void ClosePort()
            {
                if (!connected) return;
                serialPort.Close();
                serialPort.DataReceived -= serialPort_DataReceived;
            }
            #endregion

            #region ****************************** Private Internal Events ************************************
            private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                data.Append(serialPort.ReadExisting());
                Restart();
            }
            #endregion

            #region ****************************** Private Event Handlers *************************************
            private void OnDataReceived(string licensedata)
            {
                driverlicense.ExtractInfo(licensedata);
                string[] firstname = System.Text.RegularExpressions.Regex.Split(driverlicense.FirstName, @"\s+");
                m280.dlfile.Record.Address1 = driverlicense.Address1;
                m280.dlfile.Record.Address2 = driverlicense.Address2;
                m280.dlfile.Record.Birthdate = driverlicense.Birthdate;
                m280.dlfile.Record.CardRevisionDate = driverlicense.CardRevisionDate;
                m280.dlfile.Record.City = driverlicense.City;
                m280.dlfile.Record.ClassificationCode = driverlicense.VehicleClassCode;
                m280.dlfile.Record.ComplianceType = driverlicense.ComplianceType;
                m280.dlfile.Record.Country = driverlicense.Country;
                m280.dlfile.Record.DocumentType = driverlicense.DocumentType;
                m280.dlfile.Record.EndorsementCodeDescription = driverlicense.EndorsementCodeDescription;
                m280.dlfile.Record.EndorsementsCode = driverlicense.EndorsementsCode;
                //m280.dlfile.Record.ExceptionMessage = driverlicense.ExceptionMessage;
                m280.dlfile.Record.ExpirationDate = driverlicense.ExpirationDate;
                m280.dlfile.Record.EyeColor = driverlicense.EyeColor;
                m280.dlfile.Record.FirstName = firstname.Length > 0 ? firstname[0] : driverlicense.FirstName;
                m280.dlfile.Record.FullName = driverlicense.FullName;
                m280.dlfile.Record.Gender = driverlicense.Gender;
                m280.dlfile.Record.HairColor = driverlicense.HairColor;
                m280.dlfile.Record.HAZMATExpDate = driverlicense.HAZMATExpDate;
                m280.dlfile.Record.Height = driverlicense.Height;
                m280.dlfile.Record.IIN = driverlicense.IIN;
                m280.dlfile.Record.IssueDate = driverlicense.IssueDate;
                m280.dlfile.Record.IssuedBy = driverlicense.IssuedBy;
                m280.dlfile.Record.JurisdictionCode = driverlicense.JurisdictionCode;
                m280.dlfile.Record.LastName = driverlicense.LastName;
                m280.dlfile.Record.LicenseNumber = driverlicense.LicenseNumber;
                m280.dlfile.Record.LimitedDurationDocument = driverlicense.LimitedDurationDocument;
                m280.dlfile.Record.MiddleName = firstname.Length > 1 ? firstname[1] : driverlicense.MiddleName;
                m280.dlfile.Record.NamePrefix = driverlicense.NamePrefix;
                m280.dlfile.Record.NameSuffix = driverlicense.NameSuffix;
                m280.dlfile.Record.OrganDonor = driverlicense.OrganDonor;
                m280.dlfile.Record.PostalCode = driverlicense.PostalCode;
                m280.dlfile.Record.Race = driverlicense.Race;
                m280.dlfile.Record.RestrictionCode = driverlicense.RestrictionCode;
                m280.dlfile.Record.RestrictionCodeDescription = driverlicense.RestrictionCodeDescription;
                m280.dlfile.Record.Specification = driverlicense.Specification;
                m280.dlfile.Record.VehicleClassCode = driverlicense.VehicleClassCode;
                m280.dlfile.Record.VehicleClassCodeDescription = driverlicense.VehicleClassCodeDescription;
                m280.dlfile.Record.Veteran = driverlicense.Veteran;
                m280.dlfile.Record.WeightKG = driverlicense.WeightKG;
                m280.dlfile.Record.WeightLBS = driverlicense.WeightLBS;
                m280.readerdata = licensedata;
                m280.onDataReceived();
            }
            #endregion

            #region ********************************* Private Methods *****************************************
            private void TimerExpired(object instance)
            {
                var reader = (SerialReader)instance;
                if (reader.data.Length == 0) return;
                var str = reader.data.ToString();
                reader.data.Remove(0, reader.data.Length);
                reader.OnDataReceived(str);
            }
            private void Restart()
            {
                timer.Change(TIMEOUT, Timeout.Infinite);
            }
            private void InitializePort()
            {
                connected = false;
                if (m280.commport == string.Empty) { FindPort(); }
                if (m280.commport != string.Empty) { SetPort(); }
            }
            private void FindPort()
            {
                var ports = SerialPort.GetPortNames();
                switch (ports.Length)
                {
                    case 1:
                        serialPort = new SerialPort(ports[0]);
                        m280.commport = ports[0];
                        connected = true;
                        break;
                    case 2:
                        serialPort = new SerialPort(ports[1]);
                        m280.commport = ports[1];
                        connected = true;
                        break;
                    case 3:
                        serialPort = new SerialPort(ports[2]);
                        m280.commport = ports[2];
                        connected = true;
                        break;
                    case 4:
                        serialPort = new SerialPort(ports[3]);
                        m280.commport = ports[3];
                        connected = true;
                        break;
                    case 5:
                        serialPort = new SerialPort(ports[4]);
                        m280.commport = ports[4];
                        connected = true;
                        break;
                    default:
                        serialPort = null;
                        m280.commport = string.Empty;
                        connected = false;
                        break;
                }
            }
            private void SetPort()
            {
                try
                {
                    serialPort = new SerialPort(m280.commport);
                    connected = true;
                }
                catch
                {
                    connected = false;
                    FindPort();
                }
            }
            #endregion

            #region ********************************** Dispose Methods ****************************************
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            private void Dispose(bool disposing)
            {
                if (disposed) { return; }
                if (disposing)
                {
                    timer?.Dispose();
                    serialPort?.Dispose();
                }
                disposed = true;
            }
            #endregion
        }
    }
}