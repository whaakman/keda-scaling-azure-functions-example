using System;

namespace manageazurequeue
{
    class Program
    {
        static void Main(string[] args)
        {
                // Send message "X" for count "Y"
                int count = int.Parse(args[0]);
                var sendMessage = new QueueManager(); 
                string message = new string('A', 40000);
                
                // Call .Insert Message and send messages to queue
                sendMessage.InsertMessage(message, count);  
        }
    }
}
