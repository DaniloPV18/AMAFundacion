﻿using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.SwaggerGen;

using System.ComponentModel;
using System.Reflection;

namespace FundacionAMA.Domain.Shared.Extensions.Configurations
{
    public static class ConfigurationTools
    {
        /// <summary>
        /// Metodo que registra todas las implementaciones de las interfaces en el contenedor de dependencias
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyBase"></param>
        public static void RegisterAllImplementations(this IServiceCollection services, Assembly assemblyBase)
        {
            var assemblies = GetFilteredReferencedAssemblies(assemblyBase);
            services.AddAutoMapper(assemblies);

            RegisterAllImplementationsByAssembly(services, assemblies);
        }
        /// <summary>
        /// Metodo que registra todas las implementaciones de las interfaces en el contenedor de dependencias
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>

        private static void RegisterAllImplementationsByAssembly(IServiceCollection services, List<Assembly> assemblies)
        {
            foreach (var (type, interfaceType) in from assembly in assemblies
                                                  let allTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract)
                                                  from type in allTypes
                                                  let interfaces = type.GetInterfaces()
                                                  from interfaceType in interfaces
                                                  select (type, interfaceType))
            {
                if (interfaceType.IsGenericTypeDefinition)
                {
                    var matchingInterfaces = GetMatchingGenericInterfaces(interfaceType, type);
                    foreach (var matchingInterface in matchingInterfaces)
                    {
                        if (IsOptimalRegistration(type))
                        {
                            services.AddTransient(matchingInterface, type);
                        }
                    }
                }
                else if (CanRegisterType(interfaceType, type) && IsOptimalRegistration(type))
                {
                    services.AddTransient(interfaceType, type);
                }
            }
        }

        public static bool IsInjectable(Type type)
        {
            return type.IsInterface || (!type.IsSealed && !type.IsAbstract);
        }

        private static bool IsOptimalRegistration(Type type)
        {
            var constructors = type.GetConstructors();

            if (constructors.Length == 0 || !constructors.Any(c => c.IsPublic || c.IsFamily))
            {
                return false;
            }

            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();

                foreach (var parameter in parameters)
                {
                    if (!IsInjectable(parameter.ParameterType))
                    {
                        return false;
                    }
                }

                if (HasCircularDependency(type, new HashSet<Type>()))
                {
                    return false;
                }


            }

            return true;
        }


        private static bool HasCircularDependency(Type type, HashSet<Type> visitedTypes)
        {
            if (visitedTypes.Contains(type))
            {
                return true;
            }

            visitedTypes.Add(type);

            var constructor = type.GetConstructors().FirstOrDefault();
            if (constructor != null)
            {
                var parameters = constructor.GetParameters();
                foreach (var param in parameters)
                {
                    if (HasCircularDependency(param.ParameterType, new HashSet<Type>(visitedTypes)))
                    {
                        return true;
                    }
                }
            }

            visitedTypes.Remove(type);
            return false;
        }

        public static List<Assembly> GetFilteredReferencedAssemblies(this Assembly assembly)
        {
            var referencedAssemblies = assembly.GetReferencedAssemblies().Distinct();
            var filteredAssemblies = referencedAssemblies
                .Where(IsAssemblyAllowed)
                .Select(LoadAssembly)
                .ToList();

            filteredAssemblies.Add(assembly);
            return filteredAssemblies;
        }

        private static bool IsAssemblyAllowed(AssemblyName assemblyName)
        {
            var forbiddenPrefixes = new[] { "System.", "Microsoft.", "AutoMapper", "Newtonsoft", "MediatR", "Swashbuckle" };

            return !forbiddenPrefixes.ToList().Exists(prefix =>
                assemblyName.FullName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
        }

        private static Assembly LoadAssembly(AssemblyName assemblyName)
        {
            return Assembly.Load(assemblyName);
        }

        private static bool CanRegisterType(Type interfaceType, Type implementationType)
        {
            return !interfaceType.IsGenericTypeDefinition &&
                   !implementationType.IsGenericTypeDefinition &&
                   interfaceType.IsAssignableFrom(implementationType);
        }

        private static IEnumerable<Type> GetMatchingGenericInterfaces(Type interfaceType, Type implementationType)
        {
            var implementationInterfaces = implementationType.GetInterfaces();

            return implementationInterfaces.Where(inter =>
                inter.IsGenericType &&
                inter.GetGenericTypeDefinition() == interfaceType);
        }

        public static string JoinStrings(this List<string> errores)
        {
            return string.Join(", \n\n", errores.Distinct().ToList());
        }

        public static object? GetPropertyValue(this object obj, string description)
        {
            var property = obj.GetType()
                .GetProperties().ToList()
                .Find(p => p.GetCustomAttribute<DescriptionAttribute>()?.Description == description);

            return property?.GetValue(obj);
        }
        public static List<string> GetPathcDocument(this List<Assembly> assemblies)
        {
            if (assemblies != null & assemblies.Any())
            {
                List<string> oatchdco = new();
                foreach (var Assembly in assemblies)
                {
                    var document = Assembly.GetPathDocument();
                    if (!string.IsNullOrEmpty(document))
                    {
                        oatchdco.Add(document);
                    }

                }
                return oatchdco;
            }

            return null;
        }
        public static string GetPathDocument(this Assembly assemblyName)
        {
            // Generar la ruta del archivo XML de comentarios de documentación de Swagger
            if (assemblyName != null && !string.IsNullOrEmpty(assemblyName.GetName().Name))
            {
                var xmlFile = $"{assemblyName.GetName().Name}.xml";
                return Path.Combine(AppContext.BaseDirectory, xmlFile);
            }
            return null;
        }
        public static void InsertPath(this SwaggerGenOptions swagger, List<string> pathsDoc = null)
        {
            if (pathsDoc != null && pathsDoc.Any())
            {
                pathsDoc.ForEach(xmlPath =>
                {
                    if (!string.IsNullOrEmpty(xmlPath) && File.Exists(xmlPath))
                    {
                        swagger.IncludeXmlComments(xmlPath);

                        // El archivo existe en la ruta especificada
                    }
                });
            }
        }
        public static List<string> GetPropertyDescriptions<T>()
        {
            var propertyDescriptions = new List<string>();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property != null)
                {
                    var descriptionAttribute = Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    var description = descriptionAttribute?.Description ?? property.Name;
                    propertyDescriptions.Add(description);
                }
            }

            return propertyDescriptions;
        }
    }
}
