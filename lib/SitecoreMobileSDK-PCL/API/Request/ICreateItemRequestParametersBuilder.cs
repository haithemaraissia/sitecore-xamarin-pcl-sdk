namespace Sitecore.MobileSDK.API.Request
{
  using System.Collections.Generic;
  using Sitecore.MobileSDK.API.Request.Parameters;

  public interface ICreateItemRequestParametersBuilder<T> : IChangeItemRequestParametersBuilder<T>
  where T : class
  {
    ICreateItemRequestParametersBuilder<T> ItemTemplate(string template);
    ICreateItemRequestParametersBuilder<T> ItemName(string template);
    new ICreateItemRequestParametersBuilder<T> AddFieldsRawValuesByName(IDictionary<string, string> fieldsRawValuesByName);
    new ICreateItemRequestParametersBuilder<T> AddFieldsRawValuesByName(string fieldKey, string fieldValue);

    new ICreateItemRequestParametersBuilder<T> Database(string sitecoreDatabase);
    new ICreateItemRequestParametersBuilder<T> Language(string itemLanguage);
    new ICreateItemRequestParametersBuilder<T> Payload(PayloadType payload);

    new ICreateItemRequestParametersBuilder<T> AddFields(IEnumerable<string> fields);
    new ICreateItemRequestParametersBuilder<T> AddFields(params string[] fieldParams);
  }
}

