﻿using UnityEngine;

namespace MLAgents
{
    [RequireComponent(typeof(Agent))]
    public class DecisionAutoRequester : MonoBehaviour
    {

        public int DecisionPeriod = 1;
        public bool RepeatAction = true;
        private Agent m_Agent;
        private Academy m_Academy;

        public void OnEnable()
        {
            DecisionPeriod = Mathf.Max(DecisionPeriod, 1);
            m_Agent = gameObject.GetComponent<Agent>();
            m_Academy = GameObject.FindObjectOfType<Academy>();
            m_Academy.AgentSetStatus += SetStatus;
        }

        void OnDisable()
        {
            m_Academy.AgentSetStatus -= SetStatus;
        }

        void SetStatus(int academyStepCounter)
        {
            if (academyStepCounter % DecisionPeriod == 0)
            {
                m_Agent.RequestDecision();
            }
            if (RepeatAction)
            {
                m_Agent.RequestAction();
            }
        }
    }
}