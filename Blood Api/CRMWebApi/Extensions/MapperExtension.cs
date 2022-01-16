namespace NashWebApi.Extensions
{
    using AutoMapper;
    using System;
    using System.Runtime.CompilerServices;

    public static class MapperExtension
    {
        public static TDestination Map<TSource, TDestination>(this TSource source)
        {
            MapperConfiguration configuration = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<TSource, TDestination>().MaxDepth(1);
            });
            return configuration.CreateMapper().Map<TDestination>(source);
        }

        public static TDestination Map<TSource, TDestination>(this TSource source, Action<IMapperConfigurationExpression> configure)
        {
            MapperConfiguration configuration = new MapperConfiguration(configure);
            return configuration.CreateMapper().Map<TDestination>(source);
        }

        public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination)
        {
            MapperConfiguration configuration = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<TSource, TDestination>().MaxDepth(1);
            });
            return configuration.CreateMapper().Map<TSource, TDestination>(source, destination);
        }
    }
}

