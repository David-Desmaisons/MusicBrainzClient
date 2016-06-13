﻿using RestSharp;
using System;
using System.ComponentModel;

namespace RestSharpHelper
{
    public static class RequestExtension
    {
        public static IRestRequest AddAsParameter(this IRestRequest request, object parameter, ParameterType type = ParameterType.QueryString)
        {
            if (parameter == null)
                return request;

            foreach (var property in parameter.GetType().GetProperties())
            {
                var value = property.GetValue(parameter, null);
                if (value == null)
                    continue;

                var key = property.Name;
                var desc = Attribute.GetCustomAttributes(property, typeof(DescriptionAttribute));
                if ((desc.Length > 0))
                    key = ((DescriptionAttribute)desc[0]).Description;

                request.AddParameter(key, value, type);
            }
            return request;
        }
    }
}
