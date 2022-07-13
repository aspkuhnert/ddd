﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cto.Tutorial.CleanArchitecture.Domain.BuildingBlocks
{
   public abstract class EntityBase
   {
      private List<IDomainEvent> _domainEvents;

      public EntityBase()
      {
         _domainEvents = new List<IDomainEvent>();
      }

      /// <summary>
      /// Domain events occurred.
      /// </summary>
      public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

      public short Version { get; protected set; }

      public void ClearDomainEvents()
      {
         _domainEvents?.Clear();
      }

      /// <summary>
      /// Add domain event.
      /// </summary>
      /// <param name="domainEvent">Domain event.</param>
      protected void AddDomainEvent(IDomainEvent domainEvent)
      {
         this._domainEvents.Add(domainEvent);
      }

      protected abstract void Apply(IDomainEvent @event);

      protected void CheckRule(IBusinessRule rule)
      {
         if (rule.IsBroken())
         {
            throw new BusinessRuleValidationException(rule);
         }
      }
   }
}