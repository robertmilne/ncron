﻿/*
 * Copyright 2009 Joern Schou-Rode
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

using Autofac;
using Autofac.Builder;
using Autofac.Configuration;
using NCron.Framework;

namespace NCron.Integration.Autofac
{
    public class XmlConfiguredJobFactory : IJobFactory
    {
        private readonly IContainer _container;
        
        public XmlConfiguredJobFactory()
        {
            var builder = new ContainerBuilder(); ;
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            _container = builder.Build();
        }

        public ICronJob GetJobByName(string name)
        {
            return new ScopeNestingJobWrapper(_container, name);
        }
    }
}