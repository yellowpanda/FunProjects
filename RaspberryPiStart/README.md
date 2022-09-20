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

The raspberry did turn on and showed the user interface. It did not connect to the wifi and after a reboot it never completed the boot process. It just showed a black screen with a blinking cursor. :( 

So I burned a new image on the MicroSD card and tried again.

This time I connected to the wifi manually and tried to [update all software](https://www.raspberrypi.com/documentation/computers/os.html) before rebooting:
```bash
sudo apt update
sudo apt full-upgrade
reboot
```

Again the back screen with a blinking cursor :(

In the boot sequence there is a point where an image is showing "Welcome to..." if I press F12 there, then it shows the boot log. Sometime if I do that, it succeeded the boot and the desktop appears. 

Then I changed to: boot to console (instead of desktop):

```bash
sudo raspi-config
```
In the menu select "1. System Options", "S5 Boot / Auto Login" and "B2 Console Autologin".
I also changed "1. System Options", "S7 Splash Screen" to "No".

That seems to work every time. Tried to enable boot to desktop again and now it work now and then. I'm [not the only one having the problem](https://forums.raspberrypi.com/viewtopic.php?t=140183). Might be a power related problem. 

That must be a problem for another day...
