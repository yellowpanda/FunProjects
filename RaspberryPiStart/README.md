# Raspberry Pi Start

## Install Raspberry PI OS 

Documentation: https://projects.raspberrypi.org/en/projects/raspberry-pi-setting-up/4

Install the Raspberry Pi Imager on Windows:

```powershell
 Invoke-WebRequest https://downloads.raspberrypi.org/imager/imager_latest.exe -OutFile imager_latest.exe
 .\imager_latest.exe /S 
 ```

At first it failed when I tried to write the image to the SD card: 
![](./images/2022-09-16%2019_29_46-Window.png)


But I took another PC and then it worked.

I choose `Raspberry PI OS (32bit)` and under advanced options did I choose:

* Hostname: raspberry.local
* Enable SSH = yes
    * Use password authentication
* Set username and password = yes
    * Username: pi
    * Password: ***
* Configure wireless LAN = yes
    * SSID: ***
    * Password: ***
    * Wireless LAN country: DK
* Set locale settings = yes
    * Time zone: Europe/Copenhagen
    * Keyboard layout: dk


