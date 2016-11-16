/*
 * uart.c
 *
 * Created: 11.07.2016 21:34:25
 *  Author: malek
 */ 

#include <avr/io.h>
#include "uart.h"
#include <stdlib.h>

void UART_Initlialise(unsigned int ubrr)
{
	//SETTING BAUD RATE
	UBRR0H = (unsigned char) (ubrr>>8);
	UBRR0L = (unsigned char) ubrr;

	//ENABLING RECEIVER (RX) AND TRANSMITER (TX)
	UCSR0B = (1<<RXEN0) | (1<<TXEN0);

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
void UART_Send16Bit(uint16_t data)
{
	uint8_t dataMS = ((data >> 8) & 0xFF);
	uint8_t dataLS = (data & 0xFF);

	UART_SendChar(dataMS);
	UART_SendChar(dataLS);
}

/* --- RECEIVING --- */
char UART_ReceiveChar(void)
{
	while(!(UCSR0A & (1<<RXC0))); //EMPTY LOOP - WAITING UNTILL DATA IS RECEIVED

	return UDR0;
}
char * UART_ReceiveString(void)
{
	int maximumSize = 20;
	char receivedString[maximumSize];
	char lastChar;
	/*
	 *Fixed loop or conditional
	 */
	int i = 0; 
	lastChar = '\0';
	for(int j = 0; j < maximumSize; j++)
	{
		receivedString[j] = '\0';
	}
	while (i < maximumSize && lastChar != '\n')
	{
		lastChar = UART_ReceiveChar();
		//UART_SendChar(lastChar);
		receivedString[i] = lastChar;
		i++;
	}
	return receivedString;
}