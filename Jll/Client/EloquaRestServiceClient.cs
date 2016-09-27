using JLL.SP2013.Internet.Eloqua.Helpers;
using JLL.SP2013.Internet.Eloqua.Models;
using JLL.SP2013.Internet.Eloqua.Models.Form;
using JLL.SP2013.Internet.Eloqua.Models.Forms;
using JLL.SP2013.Internet.Eloqua.Models.OptionList;
using JLL.SP2013.Internet.Eloqua.Models.System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Client
{
    public class EloquaRestServiceClient
    {

        const string authenticationUrl = "https://login.eloqua.com/id";
        const string apiVersion1 = "1.0";

        private readonly AuthenticationHeaderValue _authHeader;

        private AuthenticationResponse _lastAuthResponse;

        public AuthenticationResponse LastAuthenticationResponse
        {
            get
            {
                if (_lastAuthResponse == null)
                {
                    _lastAuthResponse = Authenticate();
                }
                return _lastAuthResponse;
            }
            private set
            {
                _lastAuthResponse = value;
            }
        }
        public EloquaRestServiceClient(string company, string userName, string password)
        {
            string authenticationCode = Base64Encode(company + "\\" + userName + ":" + password);
            _authHeader = new AuthenticationHeaderValue("Basic", authenticationCode);
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private AuthenticationResponse Authenticate()
        {
            return AsyncHelpers.RunSync<AuthenticationResponse>(() => this.AuthenticateAsync());
        }

        public async Task<AuthenticationResponse> AuthenticateAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(authenticationUrl);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Empty))
                {

                    request.Headers.Authorization = _authHeader;
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApiResponseException(response.StatusCode, response.ReasonPhrase);
                        }

                        var model = await response.Content.ReadAsAsync<AuthenticationResponse>();
                        LastAuthenticationResponse = model; //update
                        return model;
                    }
                }
            }
        }

        public FormsList GetFormList()
        {
            return AsyncHelpers.RunSync<FormsList>(() => this.GetFormListAsync());
        }
        public async Task<FormsList> GetFormListAsync()
        {
            return await this.GetFormListAsync(null);
        }
        public FormsList GetFormList(FormsListOptions formListOptions)
        {
            return AsyncHelpers.RunSync<FormsList>(() => this.GetFormListAsync(formListOptions));
        }
        public async Task<FormsList> GetFormListAsync(FormsListOptions formListOptions)
        {
            FormsList resultObject = null;
            try
            {
                resultObject = await GetFormListInternalAsync(formListOptions);
            }
            catch(ApiResponseException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //try to authenticate again
                    await this.AuthenticateAsync();
                    resultObject = await GetFormListInternalAsync(formListOptions);
                }
                else
                {
                    throw;
                }
            }
            return resultObject;
        }
        private Uri GetRestApiBaseUrl()
        {
            var _authResponse = LastAuthenticationResponse;
            var apiStringFormat = _authResponse.Urls.Apis.Rest.Standard;
            var apiUrl = apiStringFormat.Replace("{version}", apiVersion1);
            return new Uri(apiUrl);

        }

        private void AddQueryParameter(StringBuilder queryString, string parameter, string value)
        {
            if (queryString.Length>0)
            {
                queryString.Append("&");
            }
            queryString.AppendFormat("{0}={1}",parameter, Uri.EscapeDataString(value));
        }

        private async Task<FormsList> GetFormListInternalAsync(FormsListOptions formListOptions)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetRestApiBaseUrl();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var queryOptions = new StringBuilder();
                if (formListOptions != null)
                {
                    if (!string.IsNullOrEmpty(formListOptions.Depth))
                    {
                        AddQueryParameter(queryOptions, "depth", formListOptions.Depth);
                    }
                    if (!string.IsNullOrEmpty(formListOptions.Search))
                    {
                        AddQueryParameter(queryOptions, "search", formListOptions.Search);
                    }
                }
                var apiUrl = "assets/forms";
                var apiUrlWithQuery = (queryOptions.Length == 0) ? apiUrl : apiUrl + "?" + queryOptions.ToString();
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrlWithQuery))
                {

                    request.Headers.Authorization = _authHeader;
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApiResponseException(response.StatusCode, response.ReasonPhrase);
                        }
                        var content = response.Content;
                        var jsonString = await content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<FormsList>(jsonString);
                        //var model = await response.Content.ReadAsAsync<FormsList>();
                        return model;
                    }
                }
            }
        }
        public Form GetForm(FormOptions formOptions)
        {
            return AsyncHelpers.RunSync<Form>(() => this.GetFormAsync(formOptions));
        }
        public async Task<Form> GetFormAsync(FormOptions formOptions)
        {
            Form resultObject = null;
            try
            {
                resultObject = await GetFormInternalAsync(formOptions);
            }
            catch (ApiResponseException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //try to authenticate again
                    await this.AuthenticateAsync();
                    resultObject = await GetFormInternalAsync(formOptions);
                }
                else
                {
                    throw;
                }
            }
            return resultObject;
        }

        private async Task<Form> GetFormInternalAsync(FormOptions formOptions)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = GetRestApiBaseUrl();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var queryOptions = new StringBuilder();
                if (formOptions != null)
                {
                    if (!string.IsNullOrEmpty(formOptions.Depth))
                    {
                        AddQueryParameter(queryOptions, "depth", formOptions.Depth);
                    }
                }
                var apiUrl = "assets/form/"+ formOptions.Id.ToString();
                var apiUrlWithQuery = (queryOptions.Length == 0) ? apiUrl : apiUrl + "?" + queryOptions.ToString();
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrlWithQuery))
                {

                    request.Headers.Authorization = _authHeader;
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApiResponseException(response.StatusCode, response.ReasonPhrase);
                        }

                        HttpContent content = response.Content;
                        string resultAsString = await content.ReadAsStringAsync();

                        var settings = new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        };

                        var model = JsonConvert.DeserializeObject<Form>(resultAsString, settings);

                        //var model = await response.Content.ReadAsAsync<FormsList>();
                        return model;
                    }
                }
            }
        }
        public OptionList GetOptionList(OptionListOptions optionListOptions)
        {
            return AsyncHelpers.RunSync<OptionList>(() => this.GetOptionListAsync(optionListOptions));
        }
        public async Task<OptionList> GetOptionListAsync(OptionListOptions optionListOptions)
        {
            OptionList resultObject = null;
            try
            {
                resultObject = await GetOptionListInternalAsync(optionListOptions);
            }
            catch (ApiResponseException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //try to authenticate again
                    await this.AuthenticateAsync();
                    resultObject = await GetOptionListInternalAsync(optionListOptions);
                }
                else
                {
                    throw;
                }
            }
            return resultObject;
        }
        private async Task<OptionList> GetOptionListInternalAsync(OptionListOptions optionListOptions)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = GetRestApiBaseUrl();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var queryOptions = new StringBuilder();
                if (optionListOptions != null)
                {
                    if (!string.IsNullOrEmpty(optionListOptions.Depth))
                    {
                        AddQueryParameter(queryOptions, "depth", optionListOptions.Depth);
                    }
                }
                var apiUrl = "assets/optionList/" + optionListOptions.Id.ToString();
                var apiUrlWithQuery = (queryOptions.Length == 0) ? apiUrl : apiUrl + "?" + queryOptions.ToString();
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrlWithQuery))
                {

                    request.Headers.Authorization = _authHeader;
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApiResponseException(response.StatusCode, response.ReasonPhrase);
                        }
                        var model = await response.Content.ReadAsAsync<OptionList>();
                        return model;
                    }
                }
            }
        }

        public FormData PostFormData(int formId, FormData formData)
        {
            return AsyncHelpers.RunSync<FormData>(() => this.PostFormDataAsync(formId, formData));
        }

        public async Task<FormData> PostFormDataAsync(int formId, FormData formData)
        {
            FormData resultObject = null;
            try
            {
                resultObject = await PostFormDataInternalAsync(formId, formData);
            }
            catch (ApiResponseException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //try to authenticate again
                    await this.AuthenticateAsync();
                    resultObject = await PostFormDataInternalAsync(formId, formData);
                }
                else
                {
                    throw;
                }
            }
            return resultObject;
        }

        private async Task<FormData> PostFormDataInternalAsync(int formId, FormData formData)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = GetRestApiBaseUrl();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = _authHeader;

                var apiUrl = "data/form/" + formId.ToString();
                var json = JsonConvert.SerializeObject(formData, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //using (HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, formData))
                using (HttpResponseMessage response = await client.PostAsync(apiUrl, content))
                {
                    if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                    {

                        var extraInfo = await response.Content.ReadAsStringAsync();

                        throw new ApiResponseException(response.StatusCode, response.ReasonPhrase);
                    }
                    var model = await response.Content.ReadAsAsync<FormData>();
                    return model;
                }
            }
        }
    }
}
