using System;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Advanced;

/// <summary>
/// https://simpleinjector.readthedocs.io/en/latest/extensibility.html#overriding-constructor-resolution-behavior
/// </summary>


namespace Ignition.Foundation.Core.SimpleInjector
{
    public class MostResolvableConstructorBehavior : IConstructorResolutionBehavior
    {
        private readonly Container container;

        public MostResolvableConstructorBehavior(Container container)
        {
            this.container = container;
        }

        private bool IsCalledDuringRegistrationPhase => !this.container.IsLocked();

        public ConstructorInfo GetConstructor(Type service, Type implementation)
        {
            var constructors = implementation.GetConstructors();

            if (!constructors.Any())
                return null;

            return (
                from ctor in constructors
                let parameters = ctor.GetParameters()
                where this.IsCalledDuringRegistrationPhase
                      || constructors.Length == 1
                      || parameters.All(p => this.CanBeResolved(p, service, implementation))
                orderby parameters.Length descending
                select ctor)
                .First();
        }

        private bool CanBeResolved(ParameterInfo p, Type service, Type implementation)
        {
            return this.container.GetRegistration(p.ParameterType) != null ||
                   this.CanBuildType(p, service, implementation);
        }

        private bool CanBuildType(ParameterInfo p, Type service, Type implementation)
        {
            try
            {
                this.container.Options.DependencyInjectionBehavior.BuildExpression(
                    new InjectionConsumerInfo(service, implementation, p));
                return true;
            }
            catch (ActivationException)
            {
                return false;
            }
        }
    }
}