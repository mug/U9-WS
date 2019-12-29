using System;
using System.Collections.Generic;
using UFIDA.U9.Cust.Pub.WS.U9Action.Action;

namespace UFIDA.U9.Cust.Pub.WS.U9Action
{
    /// <summary>
    ///     U9动作相关状态对象
    /// </summary>
    public class U9ActionCorrelationState
    {
        private readonly Dictionary<IU9BehaviorAction, object> _actionCorrelationStateDict =
            new Dictionary<IU9BehaviorAction, object>();

        private readonly List<IU9BehaviorAction> _actions = new List<IU9BehaviorAction>();

        public List<IU9BehaviorAction> Actions
        {
            get { return _actions; }
        }

        /// <summary>
        ///     添加动作
        /// </summary>
        /// <param name="action"></param>
        /// <param name="correlationState"></param>
        public void AddAction(IU9BehaviorAction action, object correlationState)
        {
            if (_actions.Contains(action))
                throw new Exception("action cannot be repeated");
            _actions.Add(action);
            _actionCorrelationStateDict.Add(action, correlationState);
        }

        /// <summary>
        ///     获取动作的状态
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public object GetActionCorrelationState(IU9BehaviorAction action)
        {
            if (!_actionCorrelationStateDict.ContainsKey(action))
                throw new Exception("action correlationState does not exist");
            return _actionCorrelationStateDict[action];
        }
    }
}