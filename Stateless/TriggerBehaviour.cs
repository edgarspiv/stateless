﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stateless
{
    public partial class StateMachine<TState, TTrigger>
    {
        internal abstract class TriggerBehaviour
        {
            readonly TTrigger _trigger;
            readonly Func<bool> _guard;
            readonly string _guardDescription;

            protected TriggerBehaviour(TTrigger trigger, Func<bool> guard, string guardDescription)
            {
                _trigger = trigger;
                _guard = guard;
                _guardDescription = guardDescription;
            }

            public TTrigger Trigger { get { return _trigger; } }
            internal Func<bool> Guard { get { return _guard; } }
            internal string GuardDescription{ get { return string.IsNullOrEmpty(_guardDescription) ? _guard.Method.Name : _guardDescription ; } }

            public bool IsGuardConditionMet
            {
                get
                {
                    return _guard();
                }
            }

            public abstract bool ResultsInTransitionFrom(TState source, object[] args, out TState destination);
        }
    }
}
