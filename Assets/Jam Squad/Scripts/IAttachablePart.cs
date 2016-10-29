using UnityEngine;
using System.Collections;

public interface IAttachablePart
{
    void Initalize(KeyCode keyToActivate);
    void ActivatePart();
    void DeactivatePart();
}
