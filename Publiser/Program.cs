using RabbitMQ.Client;
using System;
using System.Text;

namespace Publiser
{

    /*
 Author: Alex Mahomana
 Cell  : 072 071 1650
 Email : alex.prijojo.prince@gmail.com

 App   : This is a console App to Send Messages via RabbitMQ
     */
   class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var _Factory = new ConnectionFactory() { HostName = "localhost" };
                using (var _connection = _Factory.CreateConnection())
                {
                    using (var _channel = _connection.CreateModel())
                    {

                        string _queueName = "TestQueue1";
                        _channel.QueueDeclare(_queueName, false, false, false, null);

                        Console.WriteLine("Enter Name:"); // Prompt
                        string name = Console.ReadLine(); // Get string from user
                        string _message = String.Format("Hello my name is, {0}", name);

                        var _body = Encoding.UTF8.GetBytes(_message);

                        _channel.BasicPublish("", _queueName, null, _body);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


        }
    }
}
