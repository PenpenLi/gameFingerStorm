using UnityEngine;

public class ActorPathManager 
{
	#region Static Fields

    private static readonly object _lock = new object();

    private static ActorPathManager instance;

    #endregion

    #region Constructors and Destructors

    private ActorPathManager()
    {
    }

    #endregion

    #region Public Methods and Operators

    public static ActorPathManager GetInstance()
    {
        if (instance == null)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new ActorPathManager();
                }
            }
        }
        return instance;
    }
	
	private Vector3[] firstPathLeftNodes = new Vector3[3]{new Vector3(295,530,0), new Vector3(295, 490, 0), new Vector3(295,450,0)};
    private Vector3[] firstPathRightNodes = new Vector3[3] { new Vector3(665, 530, 0), new Vector3(665, 490, 0), new Vector3(665, 450, 0) };
    private Vector3[] secondPathLeftNodes = new Vector3[3] { new Vector3(295, 200, 0), new Vector3(295, 240, 0), new Vector3(295, 280, 0) };
	private Vector3[] secondPathRightNodes = new Vector3[3]{new Vector3(665,200,0), new Vector3(665, 240, 0), new Vector3(665,280,0)};
	
	public ActorPath GenerateNewPath(Vector3 startPos, Vector3 endPos)
	{
		Vector3[] pathNodes;
		if(endPos.x <= 665 && startPos.x < endPos.x || endPos.x >= 295 && startPos.x > endPos.x)
			pathNodes = new Vector3[3];
		else
			pathNodes = new Vector3[4];
		pathNodes[0] = startPos;
		
		ActorPathType pathType;
		if(startPos.y > 400)
			pathType = ActorPathType.FirstPath;
		else if(startPos.y < 400)
			pathType = ActorPathType.SecondPath;
		else
		{
			pathType = (ActorPathType)Random.Range(0,2);
		}
		
		if(pathType == ActorPathType.FirstPath)
		{
			if(startPos.x < endPos.x)
			{
				pathNodes[1] = this.NearestPointInY(startPos, this.firstPathLeftNodes);
				pathNodes[2] = this.NearestPointInY(startPos, this.firstPathRightNodes);
			}
			else
			{
				pathNodes[1] = this.NearestPointInY(startPos, this.firstPathRightNodes);
				pathNodes[2] = this.NearestPointInY(startPos, this.firstPathLeftNodes);
			}
		}
		else
		{
			if(startPos.x < endPos.x)
			{
				pathNodes[1] = this.NearestPointInY(startPos, this.secondPathLeftNodes);
				pathNodes[2] = this.NearestPointInY(startPos, this.secondPathRightNodes);
			}
			else
			{
				pathNodes[1] = this.NearestPointInY(startPos, this.secondPathRightNodes);
				pathNodes[2] = this.NearestPointInY(startPos, this.secondPathLeftNodes);
			}
		}
		pathNodes[pathNodes.Length-1] = endPos;
        return new ActorPath(pathNodes, pathType);
	}
	
	private Vector3 NearestPointInY(Vector3 pos, Vector3[] points)
	{
		Vector3 result = Vector3.zero;
		if(points != null && points.Length != 0)
		{
			float dValue = 9999f;
			for(int i = 0; i < points.Length; i ++)
			{
				Vector3 point = points[i];
				if(Mathf.Abs(point.y - pos.y) < dValue)
				{
					result = point;
					dValue = Mathf.Abs(point.y - pos.y);
				}
			}
		}
		return result;
	}
	
}
#endregion