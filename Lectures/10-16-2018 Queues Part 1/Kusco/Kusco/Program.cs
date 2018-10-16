using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Threading.Tasks;

namespace Kusco
{
    class Program
    {
        private static BasicAWSCredentials credentials;
        private static AmazonSQSClient sqs;


        static void Main(string[] args)
        {
            Console.WriteLine("Starting to read messages...");

            credentials = new BasicAWSCredentials("keyid", "key");
            sqs = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);

            ReadMessagesAsync().Wait();
        }

        public async static Task ReadMessagesAsync()
        {
            var request = new ReceiveMessageRequest();
            request.MaxNumberOfMessages = 10;
            request.WaitTimeSeconds = 10;
            request.QueueUrl = "https://sqs.us-east-1.amazonaws.com/570108184261/webprogramminglecture";

            while (true) {
                var messages = await sqs.ReceiveMessageAsync(request);

                foreach (var message in messages.Messages)
                {
                    Console.WriteLine(message.Body);

                    await sqs.DeleteMessageAsync(new DeleteMessageRequest()
                    {
                        QueueUrl = "https://sqs.us-east-1.amazonaws.com/570108184261/webprogramminglecture",
                        ReceiptHandle = message.ReceiptHandle
                    });
                }
            }
        }
    }
}
