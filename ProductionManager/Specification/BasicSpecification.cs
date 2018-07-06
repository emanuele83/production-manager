using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Specification
{
    public abstract class BasicSpecification<T>
    {
        private List<Expression<Func<T, object>>> _includes;

        public static readonly BasicSpecification<T> All = new GeneralSpecification<T>();
        public ReadOnlyCollection<Expression<Func<T, object>>> Includes
        {
            get
            {
                return _includes.AsReadOnly();
            }
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public BasicSpecification()
        {
            _includes = new List<Expression<Func<T, object>>>();
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            _includes.Add(includeExpression);
        }

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public BasicSpecification<T> And(BasicSpecification<T> specification)
        {
            if (this == All)
                return specification;
            if (specification == All)
                return this;

            return new AndSpecification<T>(this, specification);
        }

        public BasicSpecification<T> Or(BasicSpecification<T> specification)
        {
            if (this == All || specification == All)
                return All;

            return new OrSpecification<T>(this, specification);
        }

        public BasicSpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }


    internal sealed class AndSpecification<T> : BasicSpecification<T>
    {
        private readonly BasicSpecification<T> _left;
        private readonly BasicSpecification<T> _right;

        public AndSpecification(BasicSpecification<T> left, BasicSpecification<T> right) : base()
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }


    internal sealed class OrSpecification<T> : BasicSpecification<T>
    {
        private readonly BasicSpecification<T> _left;
        private readonly BasicSpecification<T> _right;

        public OrSpecification(BasicSpecification<T> left, BasicSpecification<T> right) : base()
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
        }
    }


    internal sealed class NotSpecification<T> : BasicSpecification<T>
    {
        private readonly BasicSpecification<T> _specification;

        public NotSpecification(BasicSpecification<T> specification) : base()
        {
            _specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> expression = _specification.ToExpression();
            UnaryExpression notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }
    
    internal sealed class GeneralSpecification<T> : BasicSpecification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
