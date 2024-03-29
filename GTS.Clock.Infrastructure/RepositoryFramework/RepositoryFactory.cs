using System;
using System.Collections.Generic;
using GTS.Clock.Infrastructure;
using GTS.Clock.Infrastructure.RepositoryFramework.Configuration;
using System.Configuration;
using GTS.Clock.Infrastructure.RepositoryFramework;

namespace GTS.Clock.Infrastructure.RepositoryFramework
{
    public static class RepositoryFactory
    {
        /// <summary>
        /// creates an instance of the requested interface.
        /// </summary>
        /// <typeparam name="TRepository">The interface of the repository 
        /// to create.</typeparam>
        /// <typeparam name="TEntity">The type of the Entity that the 
        /// repository is for.</typeparam>
        /// <returns>An instance of the interface requested.</returns>
        public static TRepository GetRepository<TRepository, TEntity>(bool Disconnectedly)
            where TRepository : class, IRepository<TEntity>
        {
            // Initialize the provider's default value
            TRepository repository = default(TRepository);

            string interfaceShortName = typeof(TRepository).Name;

            // Get the repositoryMappingsConfiguration config section
            RepositorySettings settings = (RepositorySettings)ConfigurationManager.GetSection(RepositoryMappingConstants.RepositoryMappingsConfigurationSectionName);

            // Get the type to be created
            Type repositoryType = null;

            // See if a valid interfaceShortName was passed in
            if (settings.RepositoryMappings.ContainsKey(interfaceShortName))
            {
                repositoryType = Type.GetType(settings.RepositoryMappings[interfaceShortName].RepositoryFullTypeName);
                if (repositoryType == null)
                {
                    throw new ArgumentNullException("خطا در ایجاد انباره. نوع انباره ی درخواست شده در فایل تنظیمات یافت نشد" + " Requested Repository Name: " + interfaceShortName);
                }
                if (repositoryType.ContainsGenericParameters)
                    repositoryType = repositoryType.MakeGenericType(typeof(TEntity));
            }

            // Throw an exception if the right Repository 
            // Mapping Element could not be found and the resulting 
            // Repository Type could not be created
            if (repositoryType == null)
            {
                throw new ArgumentNullException("خطا در ایجاد انباره. نوع انباره ی درخواست شده در فایل تنظیمات یافت نشد" + " Requested Repository Name: " + interfaceShortName);
            }

            // Create the repository, and cast it to the interface specified
            repository = Activator.CreateInstance(repositoryType, new object[] { Disconnectedly }) as TRepository;

            return repository;
        }

    }
}
