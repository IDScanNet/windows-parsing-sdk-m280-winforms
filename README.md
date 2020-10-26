# Project Setup

1. Clone the repo to your local development environment

```
https://github.com/IDScanNet/windows-parsing-sdk-m280-winforms.git
```

2. Install the drivers needed to the M280 in the windows environment you are developing inside of. They can be found here <https://idscan.net/support/driversfirmware/>

3. The two DLLs that are needed to run this solution are in the `lib` folder and the **dlplib.dll** may need to be updated to the newest version if you are not able to parse the latest version of a document. The latest Windows SDK can be downloaded here <https://idscan.net/support/sdkdownloads>

4. A Windows SDK license file will need to requested from <support@idscan.net> the **dlplib.lic** file will need to be placed in the same folder that the `.exe` file is running from. For example, the following path is where the application file was located when i tested this sample app `windows-parsing-sdk-m280-winforms\WinformM280\bin\Debug`

