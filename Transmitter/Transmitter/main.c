/*
 * Transmitter.c
 *
 * Created: 26.09.2016 18:35:50
 * Author : malek
 */ 
#define F_CPU 8000000
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#define PWR	PB1 //If high the ATMEGA will be powered.
#include "rf.h"

char data[] = "---RING---";
int main(void)
{
	DDRB = (1<<PWR);
	PORTB |= (1<<PWR);

	// --- RF --- //
	RF_Initialize();
	sei(); //Global interrupt enable
	RF_SetRange(RANGE_433MHZ);
	RF_SetFrequency(RFFREQ433(432.74));
	RF_SetBaudRate(9600);
	RF_SetBandwith(RxBW200, LNA_6, RSSI_79);
	RF_SetPower(PWRdB_0, TxBW120);
	RF_DisableWakeUpTimer();
	RF_Transmit(0x0000);
	RF_Transmit(0xCC77);

	// --- TRANSMITTING RING MESSAGE --- //
	RF_TxStart(data,0);
	_delay_ms(50);
	while(RF_status.Tx != 0);
	_delay_ms(500);
	PORTB &= ~(1<<PWR);
}