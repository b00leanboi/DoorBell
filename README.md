# DoorBell
Have you ever missed a postman because you played music too loud? That's what that project's for!
Once someone rings your door bell, data is sent firstly through radio *(although this can be simplified)* to another module that is closer to the WiFi router. Then it uses WiFi to broadcast message across the network.

## Chips used
### Transmitter (Door Bell) Module
* ATMEGA328P
* RFM12B-433MHz Transciever

### Receiver Module
* ATMEGA328P
* RFM12B-433MHz Transciever
* ESP8266 (WiFi)
