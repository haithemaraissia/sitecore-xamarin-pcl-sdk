﻿namespace Sitecore.MobileSDK.UrlBuilder.DeleteItem
{
  public interface IDeleteItemsUrlBuilder<in T> where T : IBaseDeleteItemRequest
  {
    string GetUrlForRequest(T request);
  }
}