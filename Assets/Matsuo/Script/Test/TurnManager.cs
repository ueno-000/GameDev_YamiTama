using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel.Design;

public class TurnManager : MonoBehaviour
{

    public bool startLoopOnStart;

    // “o˜^‚³‚ê‚½Commander
    readonly List<Commander> m_Commanders = new List<Commander>();

    // •Û—¯’†‚ÌCommander
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
            // •Û—¯’†‚ÌCommander‚ğƒ‹[ƒv‚É’Ç‰Á‚·‚é
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

            // ƒ^[ƒ“‚ğ‰ñ‚·
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

    // “o˜^‚³‚ê‚½Commander‚ğ—Dæ“x‡‚É•À‚Ñ‘Ö‚½ƒV[ƒPƒ“ƒX‚ğ•Ô‚·
    IEnumerable<Commander> OrderedCommanders()
    {
        return m_Commanders
            .Where(c => c != null)
            .OrderByDescending(c => c.Priority);
    }

    // Commander‚ğ‰¼“o˜^‚·‚é
    public bool AddCommander(Commander commander)
    {
        if (commander == null)
        {
            throw new ArgumentNullException(nameof(commander));
        }
        return m_PendingCommanders.Add(commander);
    }

    // Commander‚ğƒ‹[ƒv‚©‚çíœ‚·‚é
    public bool RemoveCommander(Commander commander)
    {
        m_Commanders.Remove(commander);
        return m_PendingCommanders.Remove(commander);
    }
}
