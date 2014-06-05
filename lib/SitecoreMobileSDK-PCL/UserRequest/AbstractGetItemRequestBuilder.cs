﻿
namespace Sitecore.MobileSDK
{
    using System;
    using Sitecore.MobileSDK.Items;


    public abstract class AbstractGetItemRequestBuilder<T> : IGetItemRequestParametersBuilder<T>
        where T : class
    {
        public IGetItemRequestParametersBuilder<T> Database (string sitecoreDatabase)
        {
            this.itemSourceAccumulator = new ItemSourcePOD (
                sitecoreDatabase, 
                this.itemSourceAccumulator.Language, 
                this.itemSourceAccumulator.Version);

            return this;
        }

        public IGetItemRequestParametersBuilder<T> Language (string itemLanguage)
        {
            this.itemSourceAccumulator = new ItemSourcePOD (
                this.itemSourceAccumulator.Database, 
                itemLanguage, 
                this.itemSourceAccumulator.Version);

            return this;
        }

        public IGetItemRequestParametersBuilder<T> Version (string itemVersion)
        {
            this.itemSourceAccumulator = new ItemSourcePOD (
                this.itemSourceAccumulator.Database, 
                this.itemSourceAccumulator.Language,
                itemVersion);

            return this;
        }

        public abstract T Build();

        protected ItemSourcePOD itemSourceAccumulator = new ItemSourcePOD( null, null, null );
    }
}
