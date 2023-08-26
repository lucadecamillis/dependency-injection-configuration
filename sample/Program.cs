﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LdC.DependencyInjection.Configuration;
using LdC.DependencyInjection.Configuration.Sample.Interfaces;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .Build();

IServiceCollection services = new ServiceCollection();

services.FromConfiguration(configuration);

IServiceProvider serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<IService>();

Console.WriteLine("Service created");