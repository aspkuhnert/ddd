﻿namespace Cto.Tutorial.CleanArchitecture.BuildingBlocks.Application.Queries
{
   public abstract class QueryBase<TResult> :
      IQuery<TResult>
   {
      public Guid Id { get; }

      protected QueryBase()
      {
         Id = Guid.NewGuid();
      }

      protected QueryBase(Guid id)
      {
         Id = id;
      }
   }
}