using AutoMapper;

namespace FundacionAMA.Domain.Shared.Extensions.Mapping
{
    public static class MapperExtensions
    {


        public static TDestination Map<TDestination>(this IMapper mapper, params object[] sources) where TDestination : new()
        {

            return Map(mapper, new TDestination(), sources);
        }

        public static TDestination Map<TDestination>(this IMapper mapper, TDestination destination, params object[] sources) where TDestination : new()
        {


            if (!sources.Any())
                return destination;

            foreach (var src in sources.Where(e => e != null).ToList())
            {

                destination = mapper.Map(src, destination);


            }

            return destination;
        }

        public static IMappingExpression<TSource, TDestination> IgnoreIfEmpty<TSource, TDestination>(
          this IMappingExpression<TSource, TDestination> expression)
        {
            IgnoreMembers(expression);
            var newExpresion = expression.ReverseMap();
            IgnoreMembers(newExpresion);
            return expression;
        }
        public static IMappingExpression IgnoreIfEmpty(
    this IMappingExpression expression)
        {
            IgnoreMembers(expression);
            var newExpression = expression.ReverseMap();
            IgnoreMembers(newExpression);
            return expression;
        }
        public static IMappingExpression Includes(this IMappingExpression typeMapExpression, TypeMap typeMapConfiguration)
        {
            foreach (var propertyMap in typeMapConfiguration.PropertyMaps)
            {
                if (propertyMap.SourceMember != null)
                {
                    typeMapExpression.ForMember(propertyMap.DestinationMember.Name, opt =>
                    {
                        opt.MapFrom(propertyMap.SourceMember.Name);


                    });
                }
            }

            return typeMapExpression;
        }
        private static void IgnoreMembers(IMappingExpression expression)
        {
            expression.ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember, context) =>
            {
                if (srcMember == null) return false;

                if (srcMember is int || srcMember is decimal)
                {
                    return Convert.ToDecimal(srcMember) != 0;
                }

                return true;
            }));
        }
        private static void IgnoreMembers<TSource, TDestination>(IMappingExpression<TSource, TDestination> expression)
        {
            expression.ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember, context) =>
            {
                if (srcMember == null) return false;

                if (srcMember is int || srcMember is decimal)
                {
                    return Convert.ToDecimal(srcMember) != 0;
                }

                return true;
            }));
        }
    }
}
