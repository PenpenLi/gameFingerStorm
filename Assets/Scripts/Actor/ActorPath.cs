using UnityEngine;

public class ActorPath
{
    public ActorPathType pathType;
	private Vector3[] pathNodes;
	public int CurrentIndex {get;set;}
	
	public ActorPath(Vector3[] nodes, ActorPathType actorPathType)
	{ 
		this.pathNodes = nodes;
	    this.pathType = actorPathType;
		this.CurrentIndex = 1;
	}
	
	public bool HasNext()
	{
		return this.CurrentIndex < this.NodesCount() - 1;
	}
	
	public Vector3 NextNode()
	{
		this.CurrentIndex ++;
		return this.pathNodes[this.CurrentIndex]; 
	}
	
	public int NodesCount()
	{
		return this.pathNodes.Length;
	}
	
	public Vector3 CurrentNode()
	{
		return this.pathNodes[this.CurrentIndex];
	}
}
