using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoreCms.Net.Model.Entities.Expression
{
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static System.Linq.Expressions.Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, System.Linq.Expressions.Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override System.Linq.Expressions.Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
