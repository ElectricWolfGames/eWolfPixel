﻿using System;
using System.Collections.Generic;

namespace eWolfPixelStandard.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance = null;

        private readonly IDictionary<Type, object> _services;

        private ServiceLocator()
        {
            _services = new Dictionary<Type, object>
            {
                { typeof(OptionsHolder), new OptionsHolder() },
            };
        }

        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceLocator();
                }
                return _instance;
            }
        }

        public T GetService<T>()
        {
            try
            {
                return (T)_services[typeof(T)];
            }
            catch
            {
                // Fail safe
            }
            return default(T);
        }

        public void InjectService<T>(object service)
        {
            Type t2 = typeof(T);
            _services[t2] = service;
        }
    }
}
