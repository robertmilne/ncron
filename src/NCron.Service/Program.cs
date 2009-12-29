﻿/*
 * Copyright 2008, 2009 Joern Schou-Rode
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ServiceProcess;
using NCron.Framework;
using NCron.Service.Scheduling;
using NCrontab;

namespace NCron.Service
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var service = new CronService();
                ServiceBase.Run(service);
            }
            else
            {
                //log4net.Config.BasicConfigurator.Configure();

                //var builder = new ContainerBuilder(); ;
                //builder.RegisterModule(new ConfigurationSettingsReader("autofac"));

                //var container = builder.Build();

                switch (args[0].ToLower())
                {
                    case "debug":
                        //var scheduler = new Scheduler(container);
                        //scheduler.Enqueue(new QueueEntry(CrontabSchedule.Parse("* * * * *"), "foo"));
                        //scheduler.Run();

                        var cfg = Configuration.NCronSection.GetConfiguration();
                        Console.WriteLine(cfg.JobFactory.Type);

                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Uknown command: " + args[0]);
                        Environment.Exit(1);
                        break;
                }
            }
        }
    }
}

public class TestJob : CronJob
{
    public override void Execute()
    {
        Log.Info(() => GetHashCode().ToString());
    }
}