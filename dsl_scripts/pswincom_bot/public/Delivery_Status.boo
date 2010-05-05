priority 10

when_message_contains 'delivery status':
	reply 'When a message is dispatched from the Gateway, it is logged with status "OK" or "FAIL". This is visible on the account web.'
	reply '"OK" means the message was successfully submitted from the Gateway to a GSM network operator.'
	reply 'In addition, there is a handset status confirming the message is received by the receiver’s handset ("DELIVRD").'
