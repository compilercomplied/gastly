using System;

namespace domain.extensions.Core.Result
{
  public class OperationException : Exception
  {

    public OperationException(BaseError error) 
      : base (error.Message) { }

    public OperationException(string error) 
      : base (error) { }

  }

}
