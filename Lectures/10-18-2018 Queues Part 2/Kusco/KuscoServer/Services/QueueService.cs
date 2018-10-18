using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuscoServer.Services
{ 

    public class QueueService
    {

        private static BasicAWSCredentials credentials;
        private static AmazonSQSClient sqs;


        public QueueService() {
            credentials = new BasicAWSCredentials("keyid", "key");
            sqs = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);
        }

        public async Task QueueMessagesAsync(string message)
        {
            var sendMessageRequest = new SendMessageRequest();
            sendMessageRequest.QueueUrl = "https://sqs.us-east-1.amazonaws.com/570108184261/webprogramminglecture";
            sendMessageRequest.MessageBody = $"This is a message from my controller: {message}";

            await sqs.SendMessageAsync(sendMessageRequest);
        }
    }
}
