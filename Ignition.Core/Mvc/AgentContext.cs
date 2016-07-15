using System;
using System.Web.Routing;
using Glass.Mapper.Sc;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.SecurityModel;
using Version = System.Version;

namespace Ignition.Core.Mvc
{
    public class AgentContext : RequestContext
    {
        public ISitecoreService SitecoreService { get; set; }
        public ISitecoreContext SitecoreContext { get; set; }

        public AgentContext(ISitecoreContext sitecoreContext, ISitecoreService sitecoreService)
        {
            if (sitecoreContext == null) throw new ArgumentNullException(nameof(sitecoreContext));
            if (sitecoreService == null) throw new ArgumentNullException(nameof(sitecoreService));
            SitecoreContext = sitecoreContext;
            SitecoreService = sitecoreService;
        }

        private IPage _homeItem;
        public IPage HomeItem => _homeItem ?? (_homeItem = SitecoreContext.GetHomeItem<IPage>(false, true));
        public string ModuleWrapperName { get; set; }
        public IPage ContextPage { get; set; }
        public IModelBase DatasourceItem { get; set; }
        public IParamsBase RenderingParameters { get; set; }
        public string PlaceholderName { get; set; }
        public object AgentParameters { get; set; }
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
                return (TItem)SitecoreContext.GetItem<IModelBase>(id, false, true);

            var item = (TItem)SitecoreContext.GetItem<IModelBase>(id, _language, false, true);

            if (item != null) return item;
            if (!copyDefault) return default(TItem);

            item = (TItem)SitecoreContext.GetItem<IModelBase>(id, LanguageManager.DefaultLanguage, false, true);
            item.Language = _language;

            using (new SecurityDisabler())
            {
                SitecoreService.Save(item);
            }
            return item;
        }
    }
}
