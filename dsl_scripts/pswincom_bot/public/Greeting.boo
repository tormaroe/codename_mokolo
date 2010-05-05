priority 100

greetings = ["hi", "hello"]
replies = ["hello ${user}!", "Hi there!"]

when_message_contains_one_of greetings:
	reply_with_one_of replies
