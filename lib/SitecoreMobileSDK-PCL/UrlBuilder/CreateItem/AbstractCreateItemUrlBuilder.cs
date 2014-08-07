﻿using Sitecore.MobileSDK.Utils;

namespace Sitecore.MobileSDK.UrlBuilder.CreateItem
{
  using System;
  using Sitecore.MobileSDK.API.Request;
  using Sitecore.MobileSDK.UrlBuilder.Rest;
  using Sitecore.MobileSDK.UrlBuilder.WebApi;
  using Sitecore.MobileSDK.UrlBuilder.UpdateItem;

  public abstract class AbstractCreateItemUrlBuilder<TRequest> : AbstractChangeItemUrlBuilder<TRequest>
    where TRequest : IBaseCreateItemRequest
  {
    public AbstractCreateItemUrlBuilder(IRestServiceGrammar restGrammar, IWebApiUrlParameters webApiGrammar)
      : base( restGrammar, webApiGrammar )
    {
    }

    protected override string GetSpecificPartForRequest(TRequest request)
    {
      string escapedTemplate = UrlBuilderUtils.EscapeDataString(request.ItemTemplate).ToLowerInvariant();
      string escapedName = UrlBuilderUtils.EscapeDataString(request.ItemName);

      string result =
          this.webApiGrammar.TemplateParameterName 
        + this.restGrammar.KeyValuePairSeparator 
        + escapedTemplate
        + this.restGrammar.FieldSeparator 
        + this.webApiGrammar.ItemNameParameterName
        + this.restGrammar.KeyValuePairSeparator 
        + escapedName;

      return result;
    }
  }
}

