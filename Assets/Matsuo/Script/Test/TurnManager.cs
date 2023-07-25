using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel.Design;

public class TurnManager : MonoBehaviour
{

    public bool startLoopOnStart;

    // �o�^���ꂽCommander
    readonly List<Commander> m_Commanders = new List<Commander>();

    // �ۗ�����Commander
    readonly HashSet<Commander> m_PendingCommanders = new HashSet<Commander>();

    void Start()
    {
        if (startLoopOnStart)
        {
            StartLoop();
        }
    }

    public void StartLoop()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            // �ۗ�����Commander�����[�v�ɒǉ�����
            if (m_PendingCommanders.Count > 0)
            {
                foreach (Commander commander in m_PendingCommanders.ToArray())
                {
                    if (commander)
                    {
                        m_Commanders.Add(commander);
                    }
                }
                m_PendingCommanders.Clear();
            }

            // �^�[������
            foreach (Commander commander in OrderedCommanders().ToArray())
            {
                if (commander == null)
                {
                    m_Commanders.Remove(commander);
                    continue;
                }

                if (commander.BeginTurn())
                {
                    while ((commander != null) && commander.IsTurn.Value)
                    {
                        yield return null;
                    }
                }
            }
            yield return null;
        }
    }

    // �o�^���ꂽCommander��D��x���ɕ��ёւ��V�[�P���X��Ԃ�
    IEnumerable<Commander> OrderedCommanders()
    {
        return m_Commanders
            .Where(c => c != null)
            .OrderByDescending(c => c.Priority);
    }

    // Commander�����o�^����
    public bool AddCommander(Commander commander)
    {
        if (commander == null)
        {
            throw new ArgumentNullException(nameof(commander));
        }
        return m_PendingCommanders.Add(commander);
    }

    // Commander�����[�v����폜����
    public bool RemoveCommander(Commander commander)
    {
        m_Commanders.Remove(commander);
        return m_PendingCommanders.Remove(commander);
    }
}
