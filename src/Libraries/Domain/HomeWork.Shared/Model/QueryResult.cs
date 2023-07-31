using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Shared.Model;

public class QueryResult<T>
{
	public QueryResult() { }
	public QueryResult(T? result, QueryResultTypeEnum type = QueryResultTypeEnum.Success)
	{
		Result = result;
		Type = type;
	}
	public T? Result { get; set; }
	public QueryResultTypeEnum Type { get; set; }


}