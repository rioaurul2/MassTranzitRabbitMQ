﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqProducer
{
    public static class FanoutExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            //ttl stands for time to leave

            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl", 30000 }
            };

            channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout, arguments: ttl);

            var count = 0;

                var message = new { Name = "Producer fanout", Message = $"Hello! Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties();
                properties.Headers = new Dictionary<string, object>() { { "account", "new" } };

                channel.BasicPublish("demo-fanout-exchange", "account.new", properties, body);
                count++;

                Thread.Sleep(1000);
        }
    }
}
