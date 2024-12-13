﻿using SalesManagementSystem.IoC.ModuleInitializers;
using Microsoft.AspNetCore.Builder;

namespace SalesManagementSystem.IoC;

public static class DependencyResolver
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        new ApplicationModuleInitializer().Initialize(builder);
        new DomainModuleInitializer().Initialize(builder);
        new InfrastructureModuleInitializer().Initialize(builder);
        new WebApiModuleInitializer().Initialize(builder);
    }
}