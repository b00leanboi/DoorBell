/*
 * uart.h
 *
 * Created: 11.07.2016 21:30:35
 *  Author: malek
 */ 


#ifndef UART_H_
#define UART_H_

/* --- INITIALISATION --- */
void UART_Initlialise(unsigned int ubrr);

/* --- SENDING --- */
void UART_SendChar(char data);
void UART_SendString(char *string);
void UART_Send16Bit(uint16_t data);

/* --- RECEIVING --- */
char UART_ReceiveChar(void);
char* UART_ReceiveString(void);


#endif /* UART_H_ */