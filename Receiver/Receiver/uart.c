/*
 * uart.c
 *
 * Created: 11.07.2016 21:34:25
 *  Author: malek
 */ 
#include <avr/interrupt.h>
#include <avr/io.h>
#include "uart.h"
#include <stdlib.h>
#include "ESP8266.h"

volatile char buffer[100]; //Buffer for incoming data of UART
volatile uint8_t bufferIndex = 0;

void UART_Initlialise(unsigned int ubrr)
{
	//SETTING BAUD RATE
	UBRR0H = (unsigned char) (ubrr>>8);
	UBRR0L = (unsigned char) ubrr;

	//ENABLING RECEIVER (RX) AND TRANSMITER (TX)
	UCSR0B = (1<<RXEN0) | (1<<TXEN0) | (1<<RXCIE0);

	//SETTING FRAME FORMAT: 8-bit frame, 1 stop bit
	UCSR0C = (0<<USBS0) | (3<<UCSZ00);
}

/* --- SENDING --- */
void UART_SendChar(char data)
{
	while(!(UCSR0A & (1<<UDRE0))); //Waiting for empty transmit buffer

	UDR0 = data; //Putting data into buffer and sending the data
}
void UART_SendString(char *string)
{
	while(*string)
	{
		UART_SendChar(*string++);
	}
}

/* --- RECEIVING --- */
char UART_ReceiveChar(void)
{
	while(!(UCSR0A & (1<<RXC0))); //EMPTY LOOP - WAITING UNTILL DATA IS RECEIVED

	return UDR0;
}
ISR(USART_RX_vect)
{
	uint8_t receivedByte = UDR0;
	buffer[bufferIndex] = receivedByte;
	if(receivedByte == '\n')
	{
		if(buffer[0] == 'O' && buffer[1] == 'K')
		{
			ESP_Response.OK = 1;
		}
		else if(buffer[0] == 'E' && buffer[1] == 'R' && buffer[4] == 'R')
		{
			ESP_Response.ERROR = 1;
		}
		else if(buffer[1] == ',' && buffer[3] == 'O')
		{
			ESP_Connections++;
		}
		else if(buffer[1] == ',' && buffer[3] == 'L')
		{
			ESP_Connections--;
		}
		else if(buffer[0] == 'S' && buffer[5] == 'O')
			ESP_Response.OK;
		bufferIndex = 0;
	}
	else if(receivedByte == ' ')
	{
		if(buffer[0] == '>')
		{
			ESP_Response.INPUT = 1;
			bufferIndex = 0;
		}	
	}
	else
	{
		bufferIndex++;
	}
}