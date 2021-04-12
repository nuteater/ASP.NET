using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using NewName.NewAbpZeroTemplate.Queries.Container;
using System;

namespace NewName.NewAbpZeroTemplate.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}