# Raspberry Pi Start

## Install Raspberry PI OS 

I follow this [guide](https://projects.raspberrypi.org/en/projects/raspberry-pi-setting-up/4).

Install the Raspberry Pi Imager on Windows:
```powershell
 Invoke-WebRequest https://downloads.raspberrypi.org/imager/imager_latest.exe -OutFile imager_latest.exe
 .\imager_latest.exe /S 
 ```

At first it failed when I tried to write the image to the SD card: 
![](./images/2022-09-16%2019_29_46-Window.png)

I took another PC and then it worked.

I choose `Raspberry PI OS (32bit)` and under advanced options I choose:

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

It would have been nice if there was a command line interface for the Imager, but I would not find one that accepted the same information as the graphical user interface.

# Black screen after reboot

I have a Raspberry PI 3 Model B+ with a Raspberry Pi Touchscreen Display. 

The raspberry did turn on and showed the user interface. It did not connect to the wifi and after a reboot it never completed the boot process but showed a black screen with a blinking cursor. :( 

It turnes out it is power issue. The screen and pi shares a 5V 2.5A power supply. If I use two power supplies - one for the screen and one for the pi then it starts every time. 
