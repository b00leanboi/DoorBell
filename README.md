# DoorBell
Have you ever missed a postman because you played music too loud? That's what that project's for!
Once someone rings your door bell, data is sent firstly through radio to another module that is closer to the WiFi router. Then it uses WiFi to broadcast message across the network.
Receiver module has also possibility of ringing physical door bell, that is putting a high state on port PB1 and changing it back to low state after one second. 

## Chips used
### Transmitter (Door Bell) Module
* ATMEGA328P
* RFM12B-433MHz Transciever

### Receiver Module
* ATMEGA328P
* RFM12B-433MHz Transciever
* ESP8266 (WiFi)

### Desktop
Just now the only desktop app is made in Windows Forms. In future I will try to make one for Windows 10 (UWP).
