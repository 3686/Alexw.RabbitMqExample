# Alexw.RabbitMqExample
Basic publisher and client in C# using the [RabbitMq.Client nuget](https://www.nuget.org/packages/RabbitMQ.Client)
Inspired by some work on a client - more detail in this [walkthrough](http://alexw.co.uk/2017/08/experimenting-with-rabbitmq/)
# Pre-Requisites
* [RabbitMq installed locally](https://www.rabbitmq.com/install-windows.html)

# Getting started
1.  Installed RabbitMq
1a. Installed Erlang so RabbitMq runs
2.  Enable the [HTTP RabbitMq Management Plugin](https://www.rabbitmq.com/management.html#getting-started)
    ```powershell
	rabbitmq-plugins enable rabbitmq_management
	```
3.  Navigate to http://localhost:15672 to see the queues
4.  Start the `Alexw.RabbitMqExample.Client` console app. Watch it for messages.
5.  Run the `Alexw.RabbitMqExample.Publisher` to send a message.

Messages will be sent to the default (blank) topic. The `Client` will create a queue if it does not exist and subscribe to all messages.

# Learnings
* By default `guest` user cannot create a queue on the default (blank) exchange - you'll get a permissions error if you try it.
