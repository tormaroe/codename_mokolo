priority 2

when_message_contains_phone_number:
	
	send_mail \
		'torbjorn.maro@gmail.com', \
		'Contact request from PSWinBot', \
		"The following request is from IRC user ${user}:\n${message}"
	
	reply \
		'Thanks for your phone number! A human has been notified, and will contact you shortly!'

	return


words = ['contact', 'me']

when_message_contains_all_of words:
	reply "If you tell me your phone number (don't include any spaces in the number) I'll get someone to contact you.."
