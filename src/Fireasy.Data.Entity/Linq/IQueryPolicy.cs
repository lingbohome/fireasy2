﻿// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Fireasy.Data.Entity.Linq
{
    /// <summary>
    /// 查询的辅助策略。
    /// </summary>
    public interface IQueryPolicy
    {
        /// <summary>
        /// 判断是否包含指定的成员。
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        bool IsIncluded(MemberInfo member);

        /// <summary>
        /// 对表达式应用策略。
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        Expression ApplyPolicy(Expression expression, MemberInfo member);

        void IncludeWith<TEntity>(Expression<Func<TEntity, object>> fnMember) where TEntity : IEntity;

        void AssociateWith<TEntity>(Expression<Func<TEntity, IEnumerable>> memberQuery) where TEntity : IEntity;

        void Apply<TEntity>(Expression<Func<IEnumerable<TEntity>, IEnumerable<TEntity>>> fnApply) where TEntity : IEntity;

        void Apply(Type entityType, LambdaExpression fnApply);
    }
}
