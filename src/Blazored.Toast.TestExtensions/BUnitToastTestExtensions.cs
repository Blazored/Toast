﻿using Blazored.Toast.Services;
using Blazored.Toast.TestExtensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bunit
{
    [ExcludeFromCodeCoverage]
    public static class BUnitToastTestExtensions
    {
        public static InMemoryToastService AddBlazoredToast(this TestContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            context.Services
                .AddSingleton<IToastService, InMemoryToastService>();

            return (InMemoryToastService)context.Services.GetService<IToastService>();
        }
    }
}
