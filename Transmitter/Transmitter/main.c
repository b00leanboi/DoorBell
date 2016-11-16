/*
 * Transmitter.c
 *
 * Created: 26.09.2016 18:35:50
 * Author : malek
 */ 
#define F_CPU 16000000
#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#define LED0 PB0
#include "rf.h"
#include "uart.h"
#define BAUD 115200
#define UBRR F_CPU/16/BAUD-1

char data[] = "HALO HALO\r\n\r\n";
int main(void)
{
	_delay_ms(100);

	// --- LED --- //
	DDRB = (1<<LED0);
	PORTB = (1<<LED0);

	// --- TIMER --- //
	TCCR1B = (1<<CS12); // clk/256
	TIMSK1 = (1<<TOIE1); //Overflow interrupt enable

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

	// --- UART --- //
	UART_Initlialise(UBRR);

    while (1) 
    {
		RF_TxStart(data,0);
		_delay_ms(500);
    }
}
ISR(TIMER1_OVF_vect)
{
	PORTB ^= (1<<LED0);
}