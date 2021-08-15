using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "State Machine/ Keys Data/ Player", fileName = "PlayerKeys")]
public class PlayerStateKeys : StateMachineKeys
{
    public readonly string animations = "Animations";
    public readonly string playerTransform = "PlayerTransform";
    public readonly string navAgent = "NavAgent";


    public override void CreatKeys(StateMachineData stateMachineData)
    {
        var playerTransform = stateMachineData.GetComponent<Transform>();
        var animations = stateMachineData.GetComponent<PlayerAnimations>();
        var navAgent = stateMachineData.GetComponent<NavMeshAgent>();

        stateMachineData.CacheData(this.animations, animations);
        stateMachineData.CacheData(this.playerTransform, playerTransform);
        stateMachineData.CacheData(this.navAgent, navAgent);
    }
}