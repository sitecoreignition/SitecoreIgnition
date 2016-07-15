using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Routing;
using Glass.Mapper;
using Glass.Mapper.Pipelines.ConfigurationResolver;
using Glass.Mapper.Sc;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.SecurityModel;
using Config = Glass.Mapper.Sc.Config;
using Version = System.Version;

namespace Ignition.Core.Mvc
{
    public class AgentContext : RequestContext, ISitecoreContext
    {
        public AgentContext(
            ISitecoreService service,
            ISitecoreContext context
            )
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (context == null) throw new ArgumentNullException(nameof(context));
            Service = service;
            Context = context;
        }

        private IPage _homeItem;
        public IPage HomeItem => _homeItem ?? (_homeItem = Context.GetHomeItem<IPage>(false, true));
        public string ModuleWrapperName { get; set; }
        public IPage ContextPage { get; set; }
        public IModelBase DatasourceItem { get; set; }
        public IParamsBase RenderingParameters { get; set; }
        public string PlaceholderName { get; set; }
        public object AgentParameters { get; set; }
        private ISitecoreService Service { get; }
        private ISitecoreContext Context { get; }
        private Language _language;
        public Language Language
        {
            get { return _language; }
            set { SetLanguage(value); }
        }

       public string Translate(string key, object[] parameters = null)
        {
            return parameters != null
                ? Sitecore.Globalization.Translate.Text(key, parameters)
                : Sitecore.Globalization.Translate.Text(key);
        }

        private void SetLanguage(Language language)
        {
            _language = language ?? Language.Current;
        }

        public TItem GetItem<TItem>(string id, Version version = null, bool copyDefault = false)
            where TItem : IModelBase
        {
            Guid safe;
            if (!Guid.TryParse(id, out safe)) throw new ArgumentException("Invalid Guid");
            return GetItem<TItem>(safe, version, copyDefault);
        }

        public TItem GetItem<TItem>(Guid id, Version version = null, bool copyDefault = false)
            where TItem : IModelBase
        {
            if (_language == Language.Current)
                return (TItem)Context.GetItem<IModelBase>(id, false, true);

            var item = (TItem)Context.GetItem<IModelBase>(id, _language, false, true);

            if (item != null) return item;
            if (!copyDefault) return default(TItem);

            item = (TItem)Context.GetItem<IModelBase>(id, LanguageManager.DefaultLanguage, false, true);
            item.Language = _language;

            using (new SecurityDisabler())
            {
                Service.Save(item);
            }
            return item;
        }
        #region ISitecoreService Delegations
        public void Dispose()
        {
            Service.Dispose();
        }

        public object InstantiateObject(AbstractTypeCreationContext abstractTypeCreationContext)
        {
            return Service.InstantiateObject(abstractTypeCreationContext);
        }

        AbstractDataMappingContext ISitecoreService.CreateDataMappingContext(AbstractTypeCreationContext abstractTypeCreationContext, object obj)
        {
            return Service.CreateDataMappingContext(abstractTypeCreationContext, obj);
        }

        AbstractDataMappingContext ISitecoreService.CreateDataMappingContext(AbstractTypeSavingContext creationContext)
        {
            return Service.CreateDataMappingContext(creationContext);
        }

        public void SaveObject(AbstractTypeSavingContext abstractTypeSavingContext)
        {
            Service.SaveObject(abstractTypeSavingContext);
        }

        public Item ResolveItem(object target)
        {
            return Service.ResolveItem(target);
        }

        public Database Database => Service.Database;

        public Config Config
        {
            get { return Service.Config; }
            set { Service.Config = value; }
        }

        public T AddVersion<T>(T target) where T : class
        {
            return Service.AddVersion(target);
        }

        public T Create<T, TK>(TK parent, T newItem, bool updateStatistics = true, bool silent = false) where T : class where TK : class
        {
            return Service.Create(parent, newItem, updateStatistics, silent);
        }

        public T Create<T, TK>(TK parent, string newName, Language language = null, bool updateStatistics = true, bool silent = false) where T : class where TK : class
        {
            return Service.Create<T, TK>(parent, newName, language, updateStatistics, silent);
        }

        public object CreateType(Type type, Item item, bool isLazy, bool inferType, Dictionary<string, object> parameters,
            params object[] constructorParameters)
        {
            return Service.CreateType(type, item, isLazy, inferType, parameters, constructorParameters);
        }

        public T CreateType<T>(Item item, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.Cast<T>(item, isLazy, inferType);
        }

        public T Cast<T>(Item item, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.Cast<T>(item, isLazy, inferType);
        }

        public T CreateType<T, TK>(Item item, TK param1, bool isLazy = false, bool inferType = false)
        {
            return Service.CreateType<T, TK>(item, param1, isLazy, inferType);
        }

        public T CreateType<T, TK, TL>(Item item, TK param1, TL param2, bool isLazy = false, bool inferType = false)
        {
            return Service.CreateType<T, TK, TL>(item, param1, param2, isLazy, inferType);
        }

        public T CreateType<T, TK, TL, TM>(Item item, TK param1, TL param2, TM param3, bool isLazy = false, bool inferType = false)
        {
            return Service.CreateType<T, TK, TL, TM>(item, param1, param2, param3, isLazy, inferType);
        }

        public T CreateType<T, TK, TL, TM, TN>(Item item, TK param1, TL param2, TM param3, TN param4, bool isLazy = false,
            bool inferType = false)
        {
            return Service.CreateType<T, TK, TL, TM, TN>(item, param1, param2, param3, param4, isLazy, inferType);
        }

        public T CreateType<T, TK, TL, TM, TN, TO>(Item item, TK param1, TL param2, TM param3, TN param4, TO param5,
            bool isLazy = false, bool inferType = false)
        {
            return Service.CreateType<T, TK, TL, TM, TN, TO>(item, param1, param2, param3, param4, param5, isLazy, inferType);
        }

        public T CreateType<T>(Item item, bool isLazy = false, bool inferType = false, params object[] constructorParameters)
        {
            return Service.CreateType<T>(item, isLazy, inferType, constructorParameters);
        }

        public IEnumerable CreateTypes(Type type, Func<IEnumerable<Item>> getItems, bool isLazy = false, bool inferType = false)
        {
            return Service.CreateTypes(type, getItems, isLazy, inferType);
        }

        public void Delete<T>(T item) where T : class
        {
            Service.Delete(item);
        }

        public dynamic GetDynamicItem(Guid id)
        {
            return Service.GetDynamicItem(id);
        }

        public dynamic GetDynamicItem(string path)
        {
            return Service.GetDynamicItem(path);
        }

        public dynamic GetDynamicItem(Item item)
        {
            return Service.GetDynamicItem(item);
        }

        public T GetItem<T>(string path, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T>(path, isLazy, inferType);
        }

        public T GetItem<T, TK, TL>(string path, TK param1, TL param2, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL>(path, param1, param2, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM>(string path, TK param1, TL param2, TM param3, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM>(path, param1, param2, param3, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM, TN>(string path, TK param1, TL param2, TM param3, TN param4, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM, TN>(path, param1, param2, param3, param4, isLazy, inferType);
        }

        public T GetItem<T, TK>(string path, TK param1, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK>(path, param1, isLazy, inferType);
        }

        public T GetItem<T>(string path, Language language, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T>(path, language, isLazy, inferType);
        }

        public T GetItem<T, TK>(string path, Language language, TK param1, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK>(path, language, param1, isLazy, inferType);
        }

        public T GetItem<T, TK, TL>(string path, Language language, TK param1, TL param2, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL>(path, language, param1, param2, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM>(string path, Language language, TK param1, TL param2, TM param3, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM>(path, language, param1, param2, param3, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM, TN>(string path, Language language, TK param1, TL param2, TM param3, TN param4,
            bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM, TN>(path, language, param1, param2, param3, param4, isLazy, inferType);
        }

        public T GetItem<T>(string path, Language language, Sitecore.Data.Version version, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T>(path, language, version, isLazy, inferType);
        }

        public T GetItem<T, TK>(string path, Language language, Sitecore.Data.Version version, TK param1, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK>(path, language, version, param1, isLazy, inferType);
        }

        public T GetItem<T, TK, TL>(string path, Language language, Sitecore.Data.Version version, TK param1, TL param2, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL>(path, language, version, param1, param2, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM>(string path, Language language, Sitecore.Data.Version version, TK param1, TL param2, TM param3,
            bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM>(path, language, version, param1, param2, param3, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM, TN>(string path, Language language, Sitecore.Data.Version version, TK param1, TL param2, TM param3, TN param4,
            bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM, TN>(path, language, version, param1, param2, param3, param4, isLazy, inferType);
        }

        public T GetItem<T>(Guid id, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T>(id, isLazy, inferType);
        }

        public T GetItem<T, TK>(Guid id, TK param1, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK>(id, param1, isLazy, inferType);
        }

        public T GetItem<T, TK, TL>(Guid id, TK param1, TL param2, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL>(id, param1, param2, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM>(Guid id, TK param1, TL param2, TM param3, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM>(id, param1, param2, param3, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM, TN>(Guid id, TK param1, TL param2, TM param3, TN param4, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM, TN>(id, param1, param2, param3, param4, isLazy, inferType);
        }

        public T GetItem<T>(Guid id, Language language, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T>(id, language, isLazy, inferType);
        }

        public T GetItem<T, TK>(Guid id, Language language, TK param1, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK>(id, language, param1, isLazy, inferType);
        }

        public T GetItem<T, TK, TL>(Guid id, Language language, TK param1, TL param2, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL>(id, language, param1, param2, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM>(Guid id, Language language, TK param1, TL param2, TM param3, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM>(id, language, param1, param2, param3, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM, TN>(Guid id, Language language, TK param1, TL param2, TM param3, TN param4, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM, TN>(id, language, param1, param2, param3, param4, isLazy, inferType);
        }

        public T GetItem<T>(Guid id, Language language, Sitecore.Data.Version version, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T>(id, language, version, isLazy, inferType);
        }

        public T GetItem<T, TK>(Guid id, Language language, Sitecore.Data.Version version, TK param1, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK>(id, language, version, param1, isLazy, inferType);
        }

        public T GetItem<T, TK, TL>(Guid id, Language language, Sitecore.Data.Version version, TK param1, TL param2, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL>(id, language, version, param1, param2, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM>(Guid id, Language language, Sitecore.Data.Version version, TK param1, TL param2, TM param3,
            bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM>(id, language, version, param1, param2, param3, isLazy, inferType);
        }

        public T GetItem<T, TK, TL, TM, TN>(Guid id, Language language, Sitecore.Data.Version version, TK param1, TL param2, TM param3, TN param4,
            bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.GetItem<T, TK, TL, TM, TN>(id, language, version, param1, param2, param3, param4, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK, TL, TM, TN>(Guid id, Language language = null, Sitecore.Data.Version version = null,
            bool isLazy = false, bool inferType = false) where T : class where TK : class where TL : class where TM : class where TN : class
        {
            return Service.GetItemWithInterfaces<T, TK, TL, TM, TN>(id, language, version, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK, TL, TM>(Guid id, Language language = null, Sitecore.Data.Version version = null, bool isLazy = false,
            bool inferType = false) where T : class where TK : class where TL : class where TM : class
        {
            return Service.GetItemWithInterfaces<T, TK, TL, TM>(id, language, version, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK, TL>(Guid id, Language language = null, Sitecore.Data.Version version = null, bool isLazy = false,
            bool inferType = false) where T : class where TK : class where TL : class
        {
            return Service.GetItemWithInterfaces<T, TK, TL>(id, language, version, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK>(Guid id, Language language = null, Sitecore.Data.Version version = null, bool isLazy = false,
            bool inferType = false) where T : class where TK : class
        {
            return Service.GetItemWithInterfaces<T, TK>(id, language, version, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK, TL, TM, TN>(string path, Language language = null, Sitecore.Data.Version version = null,
            bool isLazy = false, bool inferType = false) where T : class where TK : class where TL : class where TM : class where TN : class
        {
            return Service.GetItemWithInterfaces<T, TK, TL, TM, TN>(path, language, version, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK, TL, TM>(string path, Language language = null, Sitecore.Data.Version version = null,
            bool isLazy = false, bool inferType = false) where T : class where TK : class where TL : class where TM : class
        {
            return Service.GetItemWithInterfaces<T, TK, TL, TM>(path, language, version, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK, TL>(string path, Language language = null, Sitecore.Data.Version version = null, bool isLazy = false,
            bool inferType = false) where T : class where TK : class where TL : class
        {
            return Service.GetItemWithInterfaces<T, TK, TL>(path, language, version, isLazy, inferType);
        }

        public T GetItemWithInterfaces<T, TK>(string path, Language language = null, Sitecore.Data.Version version = null, bool isLazy = false,
            bool inferType = false) where T : class where TK : class
        {
            return Service.GetItemWithInterfaces<T, TK>(path, language, version, isLazy, inferType);
        }

        public void Move<T, TK>(T item, TK newParent)
        {
            Service.Move(item, newParent);
        }

        public IEnumerable<T> Query<T>(string query, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.Query<T>(query, isLazy, inferType);
        }

        public IEnumerable<T> Query<T>(string query, Language language, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.Query<T>(query, language, isLazy, inferType);
        }

        public T QuerySingle<T>(string query, bool isLazy = false, bool inferType = false) where T : class
        {
            return Service.QuerySingle<T>(query, isLazy, inferType);
        }

        public void Save<T>(T target, bool updateStatistics = true, bool silent = false)
        {
            Service.Save(target, updateStatistics, silent);
        }

        public void WriteToItem<T>(T target, Item item, bool updateStatistics = true, bool silent = false)
        {
            Service.WriteToItem(target, item, updateStatistics, silent);
        }

        public void Map<T>(T target)
        {
            Service.Map(target);
        }

        AbstractDataMappingContext IAbstractService.CreateDataMappingContext(AbstractTypeCreationContext creationContext, object obj)
        {
            return ((IAbstractService) Service).CreateDataMappingContext(creationContext, obj);
        }

        AbstractDataMappingContext IAbstractService.CreateDataMappingContext(AbstractTypeSavingContext creationContext)
        {
            return ((IAbstractService) Service).CreateDataMappingContext(creationContext);
        }

        public ConfigurationResolverArgs RunConfigurationPipeline(AbstractTypeCreationContext abstractTypeCreationContext)
        {
            return Service.RunConfigurationPipeline(abstractTypeCreationContext);
        }

        public Context GlassContext => Service.GlassContext;

        public bool CacheEnabled
        {
            get { return Service.CacheEnabled; }
            set { Service.CacheEnabled = value; }
        }
#endregion
        #region ISitecoreContext Delegations
        public T GetCurrentItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.GetCurrentItem<T>(isLazy, inferType);
        }

        public T GetCurrentItem<T, TK>(TK param1, bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.GetCurrentItem<T, TK>(param1, isLazy, inferType);
        }

        public T GetCurrentItem<T, TK, TL>(TK param1, TL param2, bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.GetCurrentItem<T, TK, TL>(param1, param2, isLazy, inferType);
        }

        public T GetCurrentItem<T, TK, TL, TM>(TK param1, TL param2, TM param3, bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.GetCurrentItem<T, TK, TL, TM>(param1, param2, param3, isLazy, inferType);
        }

        public T GetCurrentItem<T, TK, TL, TM, TN>(TK param1, TL param2, TM param3, TN param4, bool isLazy = false,
            bool inferType = false) where T : class
        {
            return Context.GetCurrentItem<T, TK, TL, TM, TN>(param1, param2, param3, param4, isLazy, inferType);
        }

        public object GetCurrentItem(Type type, bool isLazy = false, bool inferType = false)
        {
            return Context.GetCurrentItem(type, isLazy, inferType);
        }

        public IEnumerable<T> QueryRelative<T>(string query, bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.QueryRelative<T>(query, isLazy, inferType);
        }

        public T QuerySingleRelative<T>(string query, bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.QuerySingleRelative<T>(query, isLazy, inferType);
        }

        public T GetHomeItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.GetHomeItem<T>(isLazy, inferType);
        }

        public T GetRootItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return Context.GetRootItem<T>(isLazy, inferType);
        }
#endregion
    }
}