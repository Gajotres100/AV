﻿using ComProvis.CSP.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ComProvis.Csp.API.Configuration
{
    public static class HandlerRegistration
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            var handlerTypes = typeof(ICommand).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => IsHandlerInterface(y)))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (Type type in handlerTypes)
            {
                AddHandler(services, type);
            }
        }

        private static void AddHandler(IServiceCollection services, Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            var pipeline = attributes
                .Select(x => ToDecorator(x))
                .Concat(new[] { type })
                .Reverse()
                .ToList();

            var interfaceType = type.GetInterfaces().Single(y => IsHandlerInterface(y));
            var factory = BuildPipeline(pipeline, interfaceType);

            services.AddTransient(interfaceType, factory);
        }

        private static Func<IServiceProvider, object> BuildPipeline(List<Type> pipeline, Type interfaceType)
        {
            var ctors = pipeline
                .Select(x =>
                {
                    var type = x.IsGenericType ? x.MakeGenericType(interfaceType.GenericTypeArguments) : x;
                    return type.GetConstructors().Single();
                })
                .ToList();

            Func<IServiceProvider, object> func = provider =>
            {
                object current = null;

                foreach (ConstructorInfo ctor in ctors)
                {
                    var parameterInfos = ctor.GetParameters().ToList();

                    var parameters = GetParameters(parameterInfos, current, provider);

                    current = ctor.Invoke(parameters);
                }

                return current;
            };

            return func;
        }

        private static object[] GetParameters(List<ParameterInfo> parameterInfos, object current, IServiceProvider provider)
        {
            var result = new object[parameterInfos.Count];

            for (int i = 0; i < parameterInfos.Count; i++)
            {
                result[i] = GetParameter(parameterInfos[i], current, provider);
            }

            return result;
        }

        private static object GetParameter(ParameterInfo parameterInfo, object current, IServiceProvider provider)
        {
            var parameterType = parameterInfo.ParameterType;

            if (IsHandlerInterface(parameterType))
                return current;

            var service = provider.GetService(parameterType);
            if (service != null)
                return service;

            throw new ArgumentException($"Type {parameterType} not found");
        }

        private static Type ToDecorator(object attribute)
        {
            return attribute.GetType();
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }
    }
}
